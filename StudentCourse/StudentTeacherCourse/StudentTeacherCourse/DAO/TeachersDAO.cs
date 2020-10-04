using StudentTeacherCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.DAO
{
    public class TeachersDAO
    {
        private string connectionString = @"Data Source=198.71.225.113;Initial Catalog=StudentCourseDb;Integrated Security=False;User ID=User;Password=ffffff1!;Connect Timeout=15;Encrypt=False;Packet Size=4096;";


        //create
        public void CreateTeacher(TeacherModel teacher)
        {
            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "INSERT INTO dbo.Teachers Values(@UserID, @FirstName, @LastName)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@UserID", System.Data.SqlDbType.VarChar, 1000).Value = teacher.LogInID;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 1000).Value = teacher.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 1000).Value = teacher.LastName;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}