using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string LogInID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public TeacherModel(string logInID, string firstName, string lastName)
        {
            LogInID = logInID;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}