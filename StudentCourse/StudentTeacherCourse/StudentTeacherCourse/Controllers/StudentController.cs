using StudentTeacherCourse.DAO;
using StudentTeacherCourse.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentTeacherCourse.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses()
        {
            CourseDAO courseDAO = new CourseDAO();
            List<CourseModel> Courses = new List<CourseModel>();
            Courses = courseDAO.FetchAll();

            //string userId = User.Identity.GetUserId();

            StudentsDAO studentsDAO = new StudentsDAO();
            StudentModel student = studentsDAO.getStudentByUserId(User.Identity.GetUserId());

            List<int> courseIds = new List<int>();
            foreach (CourseModel course in Courses)
            {
                if (courseDAO.checkIfStudentIsInCourse(course, student.Id))
                {
                    courseIds.Add(course.CourseId);
                }
            }

            //checkIfStudentIsEnrolled(Courses);
            StudentCourseModel model = new StudentCourseModel(Courses, courseIds);
            return View("StudentCourseView", model);
        }

        
    }
}