using StudentTeacherCourse.DAO;
using StudentTeacherCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentTeacherCourse.Controllers
{
    [Authorize (Roles = "TeacherRole")]
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
       
        }

        public ActionResult Courses()
        {
            return View("TeacherCourseView", getListOfCourses());
        }

        public ActionResult CreateCourse()
        {
            CourseModel course = new CourseModel("","",0);

            return View(course);
        }

        public ActionResult CreateCourseProcess(CourseModel course)
        {
            CourseDAO courseDAO = new CourseDAO();
            courseDAO.CreateCourse(course);
            return View("TeacherCourseView", courseDAO.FetchAll());
        }

        public ActionResult DeleteCourse(int Id)
        {
            CourseDAO courseDAO = new CourseDAO();
            courseDAO.DeleteCourse(Id);

            return View("TeacherCourseView", getListOfCourses());
        }

        public ActionResult ViewSingleCourse(int Id)
        {
            CourseDAO courseDAO = new CourseDAO();
            StudentsDAO studentsDAO = new StudentsDAO();

            SingleCourseViewModel singleCourse = new SingleCourseViewModel();
            singleCourse.course = courseDAO.getCourse(Id);


            List<int> studentIds = courseDAO.OpenStudentList(singleCourse.course);
            List<StudentModel> students = new List<StudentModel>();
            foreach (int studId in studentIds)
            {
                students.Add(studentsDAO.getStudentByStudentId(studId));
            }
            singleCourse.students = students;

            return View("ViewSingleCourseView",singleCourse);
        }

        public ActionResult RemoveStudentFromCourse(int courseId, int studentId)
        {
            CourseDAO courseDAO = new CourseDAO();
            StudentsDAO studentsDAO = new StudentsDAO();

            courseDAO.removeStudentFromCourse(studentId, courseId);
             
            SingleCourseViewModel singleCourse = new SingleCourseViewModel();
            singleCourse.course = courseDAO.getCourse(courseId);


            List<int> studentIds = courseDAO.OpenStudentList(singleCourse.course);
            List<StudentModel> students = new List<StudentModel>();
            foreach (int studId in studentIds)
            {
                students.Add(studentsDAO.getStudentByStudentId(studId));
            }
            singleCourse.students = students;

            return View("ViewSingleCourseView", singleCourse);
        }

        public List<Models.CourseModel> getListOfCourses()
        {
            CourseDAO courseDAO = new CourseDAO();
            return courseDAO.FetchAll();
        }
    }
}