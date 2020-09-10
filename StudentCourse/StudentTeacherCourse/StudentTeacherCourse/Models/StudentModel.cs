using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public int LogInID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CollegeYearsCompleted { get; set; }

    }
}