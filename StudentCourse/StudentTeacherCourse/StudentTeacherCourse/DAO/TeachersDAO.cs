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
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-StudentTeacherCourse-20200901043005;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


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