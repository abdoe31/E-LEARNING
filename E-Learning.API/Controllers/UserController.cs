using E_Learning.BL;
using E_Learning.BL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  readonly IUserManger _UserManger;

        public UserController (IUserManger studentManger)
        {
            _UserManger = studentManger;
        }


        [HttpPost]
        [Route("AddStudent")]

        public IActionResult AddStudent(  AddStudentDto addStudentDto)
        {
            if (addStudentDto == null)
            {

                return BadRequest("NO DATA TO ENTER");


            }
          var state = _UserManger.AddStudent(addStudentDto);
            if (state == null)
            {

                return BadRequest("server error");
            }

            return Ok(state);

        }

        [HttpPost]
        [Route("GetStudents")]

        public IActionResult GetStudents(Filter filter)
        {
            if (filter.Classid != null)
            {
                return  Ok (_UserManger.GetALLStudentsByClass((int)filter.Classid));

            }

            if (filter.Active != null)
            {
              
                return Ok(_UserManger.GetALLStudents((bool)filter.Active));

            }

            return BadRequest();
        }




        [HttpPut]
        [Route("ChangeStudentStatu")]

        public IActionResult ChangeStudentStatu(changeUserStatu  changeUserStatu)
        {
            if (changeUserStatu == null)
            {

                return BadRequest();
            }


            return Ok(_UserManger.ChangeStudentStatu(changeUserStatu));
        }







        [HttpPut]
        [Route("ChangePassword")]

        public IActionResult ChangePassword(ChangePassoworddto changePassoworddto)
        {



            var state = _UserManger.ChangePassword(changePassoworddto);
            if (state < 0)
            {
                return BadRequest("data are wrong ");
            }
            if (state == 0)
            {
                return Ok("nothing change  ");
            }
            return Ok(state);

        }


        [HttpPut]
        [Route("UpdateUser")]

        public IActionResult UpdateUser(GetUserDto  getUserDto)
        {



            var state = _UserManger.UpdateUser(getUserDto);
            if (state < 0)
            {
                return BadRequest("data are wrong ");
            }
            if (state == 0)
            {
                return Ok("nothing change  ");
            }
            return Ok(state);

        }

        [HttpGet]
        [Route("GetAdmins")]

        public IActionResult GetAdmins()
        {

            var Admins = _UserManger.GetAllAdmins();
            
            return Ok(Admins);

        }

        [HttpGet("userHome")]
        public IActionResult userHome(string userid)
        {


            return Ok(_UserManger.userHome(userid));



        }

        [HttpDelete("DeleteUser/{userid}")]
        public IActionResult DeleteUser(string userid)
        {


            return Ok(_UserManger.DeleteUser(userid));



        }




    }
}
