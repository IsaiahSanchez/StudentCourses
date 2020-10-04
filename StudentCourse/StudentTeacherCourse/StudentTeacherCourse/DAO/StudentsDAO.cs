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
        private string connectionString = @"Data Source=198.71.225.113;Initial Catalog=StudentCourseDb;Integrated Security=False;User ID=User;Password=ffffff1!;Connect Timeout=15;Encrypt=False;Packet Size=4096;";


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

        public StudentModel getStudentByStudentId(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * from [dbo].[Students] WHERE Id = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar).Value = studentId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                StudentModel student = new StudentModel("", "", "", 0);
                if (reader.HasRows)
                {
                    //create student and fill information
                    reader.Read();
                    student.Id = reader.GetInt32(0);
                    student.FirstName = reader.GetString(2);
                    student.LastName = reader.GetString(3);
                    student.CollegeYearsCompleted = reader.GetInt32(4);

                }
                return student;
            }
        }

        public StudentModel getStudentByUserId(string userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * from [dbo].[Students] WHERE StudentUserId = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar).Value = userId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                StudentModel student = new StudentModel("", "", "", 0);
                if (reader.HasRows)
                {
                    //create student and fill information
                    reader.Read();
                    student.Id = reader.GetInt32(0);
                    student.FirstName = reader.GetString(2);
                    student.LastName = reader.GetString(3);
                    student.CollegeYearsCompleted = reader.GetInt32(4);

                }
                return student;
            }
        }
        //delete

        //edit



    }
}