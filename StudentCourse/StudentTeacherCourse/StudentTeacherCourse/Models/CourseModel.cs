using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int MaxNumberOfStudents { get; set; }

        public int NumberOfStudents { get; set; }

        public string ListOfStudents { get; set; }

    }
}