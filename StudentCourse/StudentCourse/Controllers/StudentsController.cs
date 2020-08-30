using StudentCourse.Data;
using StudentCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCourse.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            List<StudentModel> students = new List<StudentModel>();

            StudentDAO studentDAO = new StudentDAO();

            students = studentDAO.FetchAll();
            return View("Index", students);
        }

        public ActionResult Details(int id)
        {
            StudentDAO studentDAO = new StudentDAO();
            StudentModel student = studentDAO.FetchOne(id);

            return View("Details", student);
        }

        public ActionResult Create()
        {
            return View("StudentCreateForm");
        }

        public ActionResult ProcessCreate(StudentModel student)
        {
            StudentDAO studentDao = new StudentDAO();

            int id = studentDao.Create(student);

            return View("Details", student);
        }
    }
}