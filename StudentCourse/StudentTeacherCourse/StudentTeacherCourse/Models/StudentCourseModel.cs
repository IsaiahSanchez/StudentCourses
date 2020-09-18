using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.Models
{
    public class StudentCourseModel
    {
        public List<CourseModel> courses;
        public List<int> EnrolledCourseIds;

        public StudentCourseModel(List<CourseModel> courses, List<int> enrolledCourseIds)
        {
            this.courses = courses;
            EnrolledCourseIds = enrolledCourseIds;
        }
    }
}