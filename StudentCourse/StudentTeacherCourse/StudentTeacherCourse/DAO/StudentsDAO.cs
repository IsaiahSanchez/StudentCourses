using StudentTeacherCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.DAO
{
    public class StudentsDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-StudentTeacherCourse-20200901043005;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        //create
        public void createStudent(StudentModel student)
        {
            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "INSERT INTO dbo.Students Values(@UserID, @FirstName, @LastName, @CollegeYearsCompleted)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@UserID", System.Data.SqlDbType.VarChar, 1000).Value = student.LogInID;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 1000).Value = student.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 1000).Value = student.LastName;
                command.Parameters.Add("@CollegeYearsCompleted", System.Data.SqlDbType.VarChar, 1000).Value = student.CollegeYearsCompleted;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        //delete

        //edit



    }
}