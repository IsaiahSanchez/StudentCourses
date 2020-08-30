using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourse.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        public StudentModel()
        {
            ID = -1;
            FirstName = "no";
            LastName = "one";
        }

        public StudentModel(int iD, string firstName, string lastName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }
    }


}