using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.Models
{
    public class SingleCourseViewModel
    {
        public CourseModel course;
        public List<StudentModel> students = new List<StudentModel>();
    }
}