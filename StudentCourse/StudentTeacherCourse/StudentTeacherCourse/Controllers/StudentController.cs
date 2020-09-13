using StudentTeacherCourse.DAO;
using StudentTeacherCourse.Models;
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

            return View("StudentCourseView", Courses);
        }
    }
}