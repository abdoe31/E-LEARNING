﻿// <auto-generated />
using System;
using E_Learning.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    [DbContext(typeof(ELearningContext))]
    partial class ELearningContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Learning.DAL.Answer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Questionid")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Questionid" }, "IX_Answers_Questionid");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("E_Learning.DAL.Assighment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("AnswerFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Classid")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Assighment", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.Class", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Yearid")
                        .HasColumnType("int")
                        .HasColumnName("yearid");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Yearid" }, "IX_Classes_yearid");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("E_Learning.DAL.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Assighnmentid")
                        .HasColumnType("int");

                    b.Property<int?>("Classid")
                        .HasColumnType("int");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quizid")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.Property<int?>("number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Assighnmentid" }, "IX_Lecture_Assighnmentid");

                    b.HasIndex(new[] { "Classid" }, "IX_Lecture_Classid");

                    b.HasIndex(new[] { "Quizid" }, "IX_Lecture_Quizid");

                    b.ToTable("Lecture", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.LectureCode", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GeneratedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeneratedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lectureid")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Used")
                        .HasColumnType("bit")
                        .HasColumnName("used");

                    b.Property<DateTime?>("Usedate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Lectureid" }, "IX_LectureCode_Lectureid");

                    b.HasIndex(new[] { "StudentId" }, "IX_LectureCode_StudentId");

                    b.ToTable("LectureCode", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.Notification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Classid")
                        .HasColumnType("int");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("Classid");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("E_Learning.DAL.Question", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Answerid")
                        .HasColumnType("int");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuizId")
                        .HasColumnType("int");

                    b.Property<int?>("RightAnswerid")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasMaxLength(1)
                        .HasColumnType("nchar(1)")
                        .IsFixedLength();

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RightAnswerid")
                        .IsUnique()
                        .HasFilter("[RightAnswerid] IS NOT NULL");

                    b.HasIndex(new[] { "QuizId" }, "IX_Questions_QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("E_Learning.DAL.Quize", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Classid")
                        .HasColumnType("int");

                    b.Property<int?>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("header");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Quizes");
                });

            modelBuilder.Entity("E_Learning.DAL.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("bit")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ParentPhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pasword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Yearid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Yearid" }, "IX_User_Yearid");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.UserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Answerid")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool?>("Right")
                        .HasColumnType("bit")
                        .HasColumnName("right");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.Property<int?>("UserQuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Answerid");

                    b.HasIndex(new[] { "QuestionId" }, "IX_UserAnswer_QuestionId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserAnswer_UserID");

                    b.HasIndex(new[] { "UserQuizId" }, "IX_UserAnswer_UserQuizId");

                    b.ToTable("UserAnswer", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.UserAssighment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Assighmentid")
                        .HasColumnType("int");

                    b.Property<bool?>("Checked")
                        .HasColumnType("bit")
                        .HasColumnName("checked");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Solved")
                        .HasColumnType("bit")
                        .HasColumnName("solved");

                    b.Property<string>("Studentid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Assighmentid" }, "IX_UserAssighment_Assighmentid");

                    b.HasIndex(new[] { "Studentid" }, "IX_UserAssighment_Studentid");

                    b.ToTable("UserAssighment", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.UserClassRequists", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("Classid")
                        .HasColumnType("int");

                    b.Property<string>("Userid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("Classid");

                    b.HasIndex("Userid");

                    b.ToTable("UserClassRequists");
                });

            modelBuilder.Entity("E_Learning.DAL.UserLecture", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("AcessType")
                        .HasColumnType("int");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime")
                        .HasColumnName("end");

                    b.Property<int?>("Lectureid")
                        .HasColumnType("int");

                    b.Property<bool>("QuizRequired")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Lectureid" }, "IX_UserLecture_Lectureid");

                    b.HasIndex(new[] { "StudentId" }, "IX_UserLecture_StudentId");

                    b.ToTable("UserLecture", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.UserQuiz", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int?>("Quizid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime");

                    b.Property<string>("Studentid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Quizid" }, "IX_UserQuiz_Quizid");

                    b.HasIndex(new[] { "Studentid" }, "IX_UserQuiz_Studentid");

                    b.ToTable("UserQuiz", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.VideoPart", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Leactureid")
                        .HasColumnType("int");

                    b.Property<string>("PartHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Leactureid" }, "IX_videoParts_Leactureid");

                    b.ToTable("videoParts", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.Year", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<DateTime?>("Updatedat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Year", (string)null);
                });

            modelBuilder.Entity("UserClass", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex(new[] { "ClassId" }, "IX_UserClasses_ClassId");

                    b.ToTable("UserClasses", (string)null);
                });

            modelBuilder.Entity("E_Learning.DAL.Answer", b =>
                {
                    b.HasOne("E_Learning.DAL.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("Questionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Answers_Questions");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("E_Learning.DAL.Class", b =>
                {
                    b.HasOne("E_Learning.DAL.Year", "Year")
                        .WithMany("Classes")
                        .HasForeignKey("Yearid")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Classes_Year");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("E_Learning.DAL.Lecture", b =>
                {
                    b.HasOne("E_Learning.DAL.Assighment", "Assighnment")
                        .WithMany("Lectures")
                        .HasForeignKey("Assighnmentid")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Lecture_Assighment");

                    b.HasOne("E_Learning.DAL.Class", "Class")
                        .WithMany("Lectures")
                        .HasForeignKey("Classid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Lecture_Classes");

                    b.HasOne("E_Learning.DAL.Quize", "Quiz")
                        .WithMany("Lectures")
                        .HasForeignKey("Quizid")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Lecture_Quizes");

                    b.Navigation("Assighnment");

                    b.Navigation("Class");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("E_Learning.DAL.LectureCode", b =>
                {
                    b.HasOne("E_Learning.DAL.Lecture", "Lecture")
                        .WithMany("LectureCodes")
                        .HasForeignKey("Lectureid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_LectureCode_Lecture");

                    b.HasOne("E_Learning.DAL.User", "Student")
                        .WithMany("LectureCodes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_LectureCode_User");

                    b.Navigation("Lecture");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_Learning.DAL.Notification", b =>
                {
                    b.HasOne("E_Learning.DAL.Class", "Class")
                        .WithMany("Notifications")
                        .HasForeignKey("Classid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("E_Learning.DAL.Question", b =>
                {
                    b.HasOne("E_Learning.DAL.Quize", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Questions_Quizes");

                    b.HasOne("E_Learning.DAL.Answer", "RightAnswer")
                        .WithOne("RQuestion")
                        .HasForeignKey("E_Learning.DAL.Question", "RightAnswerid")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Quiz");

                    b.Navigation("RightAnswer");
                });

            modelBuilder.Entity("E_Learning.DAL.User", b =>
                {
                    b.HasOne("E_Learning.DAL.Year", "Year")
                        .WithMany("Users")
                        .HasForeignKey("Yearid")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Year");
                });

            modelBuilder.Entity("E_Learning.DAL.UserAnswer", b =>
                {
                    b.HasOne("E_Learning.DAL.Answer", "answer")
                        .WithMany()
                        .HasForeignKey("Answerid");

                    b.HasOne("E_Learning.DAL.Question", "Question")
                        .WithMany("UserAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_UserAnswer_Questions");

                    b.HasOne("E_Learning.DAL.User", "User")
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_UserAnswer_User");

                    b.HasOne("E_Learning.DAL.UserQuiz", "UserQuiz")
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserQuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserAnswer_UserQuiz");

                    b.Navigation("Question");

                    b.Navigation("User");

                    b.Navigation("UserQuiz");

                    b.Navigation("answer");
                });

            modelBuilder.Entity("E_Learning.DAL.UserAssighment", b =>
                {
                    b.HasOne("E_Learning.DAL.Assighment", "Assighment")
                        .WithMany("UserAssighments")
                        .HasForeignKey("Assighmentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserAssighment_Assighment");

                    b.HasOne("E_Learning.DAL.User", "Student")
                        .WithMany("UserAssighments")
                        .HasForeignKey("Studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserAssighment_User");

                    b.Navigation("Assighment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_Learning.DAL.UserClassRequists", b =>
                {
                    b.HasOne("E_Learning.DAL.Class", "Class")
                        .WithMany("UserClassRequists")
                        .HasForeignKey("Classid");

                    b.HasOne("E_Learning.DAL.User", "user")
                        .WithMany("UserClassRequists")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("user");
                });

            modelBuilder.Entity("E_Learning.DAL.UserLecture", b =>
                {
                    b.HasOne("E_Learning.DAL.Lecture", "Lecture")
                        .WithMany("UserLectures")
                        .HasForeignKey("Lectureid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserLecture_Lecture");

                    b.HasOne("E_Learning.DAL.User", "Student")
                        .WithMany("UserLectures")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserLecture_User");

                    b.Navigation("Lecture");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_Learning.DAL.UserQuiz", b =>
                {
                    b.HasOne("E_Learning.DAL.Quize", "Quiz")
                        .WithMany("UserQuizzes")
                        .HasForeignKey("Quizid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserQuiz_Quizes");

                    b.HasOne("E_Learning.DAL.User", "Student")
                        .WithMany("UserQuizzes")
                        .HasForeignKey("Studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_UserQuiz_User");

                    b.Navigation("Quiz");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_Learning.DAL.VideoPart", b =>
                {
                    b.HasOne("E_Learning.DAL.Lecture", "Leacture")
                        .WithMany("VideoParts")
                        .HasForeignKey("Leactureid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_videoParts_Lecture");

                    b.Navigation("Leacture");
                });

            modelBuilder.Entity("UserClass", b =>
                {
                    b.HasOne("E_Learning.DAL.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserClasses_Classes");

                    b.HasOne("E_Learning.DAL.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserClasses_User");
                });

            modelBuilder.Entity("E_Learning.DAL.Answer", b =>
                {
                    b.Navigation("RQuestion");
                });

            modelBuilder.Entity("E_Learning.DAL.Assighment", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("UserAssighments");
                });

            modelBuilder.Entity("E_Learning.DAL.Class", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Notifications");

                    b.Navigation("UserClassRequists");
                });

            modelBuilder.Entity("E_Learning.DAL.Lecture", b =>
                {
                    b.Navigation("LectureCodes");

                    b.Navigation("UserLectures");

                    b.Navigation("VideoParts");
                });

            modelBuilder.Entity("E_Learning.DAL.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("UserAnswers");
                });

            modelBuilder.Entity("E_Learning.DAL.Quize", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Questions");

                    b.Navigation("UserQuizzes");
                });

            modelBuilder.Entity("E_Learning.DAL.User", b =>
                {
                    b.Navigation("LectureCodes");

                    b.Navigation("UserAnswers");

                    b.Navigation("UserAssighments");

                    b.Navigation("UserClassRequists");

                    b.Navigation("UserLectures");

                    b.Navigation("UserQuizzes");
                });

            modelBuilder.Entity("E_Learning.DAL.UserQuiz", b =>
                {
                    b.Navigation("UserAnswers");
                });

            modelBuilder.Entity("E_Learning.DAL.Year", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
