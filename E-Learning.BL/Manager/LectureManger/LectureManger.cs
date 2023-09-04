﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using E_Learning.BL.DTO;
using E_Learning.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;

namespace E_Learning.BL;

public class LectureManger : ILectureManger
{
private readonly    IUnitOfWork _UnitOfWork;
    private readonly ELearningContext _eLearningContext;

    public LectureManger(IUnitOfWork unitOfWork  , ELearningContext _eLearningContext )
    {
        _UnitOfWork = unitOfWork;
        this._eLearningContext= _eLearningContext;

    }

    public int AddAcessToUser(List<AddLectureAcessDto> addLectureAcessDtos)
    {
        if(addLectureAcessDtos.IsNullOrEmpty())
        {
            return -1;
        }

        List<UserLecture> UserLectures = new List<UserLecture>();

        foreach (var item in addLectureAcessDtos)
        {

            UserLecture userLecture = new UserLecture 
            { Lectureid = item.Lectureid, AcessType = item.AcessType,
                StudentId = item.UserId, 
                QuizRequired = item.quizrequird, Duration = item.Duration };

            UserLectures.Add(userLecture);
        }


        _UnitOfWork._UserLecturerepository.AddALL(UserLectures);
      return  _UnitOfWork.SaveChanges();
    }

    public int addLecture(AddLectureDTO addlecturedto)

    {


        Lecture lecture = new Lecture
        {
            Header = addlecturedto.Header,
            Assighnmentid = addlecturedto.Assighnmentid,
            Quizid = addlecturedto.Quizid
        ,
            Classid = addlecturedto.Classid,
            number = addlecturedto.number, VideoParts= addlecturedto.addvideos.Select(x=> new VideoPart { number = x.number  ,  Url=x.link, PartHeader= x.PartHeader}).ToList()
        };
        _UnitOfWork.lecturerepository.Add(lecture);
        return _UnitOfWork.SaveChanges();
    }



    public int DeleteLecture(Deletedto deletedto)
    {

        var lecture = _eLearningContext.Lectures.Where(x => x.Id == deletedto.id).FirstOrDefault();
        if (lecture == null || lecture.Header != deletedto.name)
        {

            return -1;
        }


        _UnitOfWork.lecturerepository.Delete(lecture);
        return _UnitOfWork.SaveChanges();
    }

    public List<Codegenerateddto> GenerateCodes(PostCodegenerateddto postCodegenerateddto)
    {
        int l = 6;

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        var codes = new List<LectureCode>(postCodegenerateddto.NumberofCode);

        foreach (var item in codes)
        {

            var code = new string(Enumerable.Repeat(chars, l).Select(s => s[random.Next(s.Length)]).ToArray());
            item.Lectureid = postCodegenerateddto.Lectureid;
            item.Code = code;

        }

        _eLearningContext.LectureCodes.AddRange(codes);
         _UnitOfWork.SaveChanges();

        return codes.Select(x => new Codegenerateddto { LectureName = x.Lecture.Header, Code = x.Code }).ToList();

    }

    public List<GetCodesDTO> GetCodes(int Lectureid)


    {

        var codes = _eLearningContext.LectureCodes.Where(x => x.Lectureid == Lectureid);

        if (codes.IsNullOrEmpty())
        {
            return null;
        }

        return codes.Select(x => new GetCodesDTO { Code = x.Code, CodeId = x.Id, Used = x.Used, Usedate = (DateTime)x.Usedate,

            UserName = $"{x.Student.FirstName}  {x.Student.SecondName}  {x.Student.LastName}"
        }).ToList();



    }


    public LectureAttendanceDTO GetLectureAttendance(int lectureId)
    {


        var lecture = _eLearningContext.UserLectures.Where(x => x.Lectureid== lectureId);
        if (lecture == null)
        {

            return null;
        }


        return new LectureAttendanceDTO
        {
            LectureName = lecture.FirstOrDefault().Lecture.Header,
            userLectureAttendances = lecture.Select(x =>
        new UserLectureAttendance
        {
            UserName = $"{x.Student.FirstName}  {x.Student.SecondName}  {x.Student.LastName}",
            start = (DateTime)x.Start,
            end = (DateTime)x.End

        }

        ).ToList()
        };

    }

    public List<LectureDetailsDto> GetLectureList(int Classid)
    {
        var Lectures = _eLearningContext.Lectures.Where(x => x.Classid == Classid);


        if (Lectures.IsNullOrEmpty())
        {


            return null;
        }


        return Lectures.Select(x => new LectureDetailsDto { Header = x.Header, Assighnmentid=x.Assighnmentid, AssighnmentName=x.Assighnment.Header,
            ClassName=x.Class.Name, LectureId=x.Id, Quizid=x.Quizid, QuizName=x.Quiz.Header }).ToList();
    }

    public UsersCLass GetLectureWithUsers(int Lectureid)
    {

        var lecture = _eLearningContext.Lectures.Where(x => x.Id == Lectureid).FirstOrDefault();
        if(lecture is null)
        {
            return null;
        }
        var users = _UnitOfWork._Userrepository.GetStudentsByClass((int)lecture.Classid).Users;
        if (users.IsNullOrEmpty())
        {


            return null;
        }
        UsersCLass U = new UsersCLass { LectureId = Lectureid, LectureName = lecture.Header, users = users.Select(x => new Users {   id=x.Id,
             userName = $"{x.FirstName}  {x.SecondName}  {x.LastName}",   ParentPhone= x.ParentPhoneNumber , Phone= x.PhoneNumber

        }).ToList() };

        return U; 

    }

    public UserLecturedto GetStudentLectureAttendence(string Studentid)
    {
        var user = _UnitOfWork._Userrepository.GetUser(Studentid);

        if(user == null)
        {
            return null;
        }

        var userattend = new UserLecturedto { StudentName = $"{user.FirstName}  {user.SecondName}  {user.LastName}",

            lectureuserAcessds = user.UserLectures.Select(x=> new lectureuserAcessd { Lectureid = x.Id, AcessType= x.AcessType.ToString() , Start=x.Start
            
            , End=x.End
             , LectureName= x.Lecture.Header}).ToList()
        };


        return userattend;
    }

    public int UpdateLecture(UpdateLectureDto updateLectureDto)
    {
        var lecture = _eLearningContext.Lectures.Where(x =>x.Id == updateLectureDto.LectureId).FirstOrDefault();

        if(lecture == null) { return -1;  }

        lecture.Classid = updateLectureDto.Classid;
        lecture.Header= updateLectureDto.Header;
        lecture.Quizid = updateLectureDto.Quizid;
        lecture.Assighnmentid = updateLectureDto.Assighnmentid;
        return _UnitOfWork.SaveChanges();

    }





}