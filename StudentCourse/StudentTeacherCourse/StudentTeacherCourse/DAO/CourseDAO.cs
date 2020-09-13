using StudentTeacherCourse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.DAO
{
    public class CourseDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-StudentTeacherCourse-20200901043005;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<CourseModel> FetchAll()
        {
            List<CourseModel> returnList = new List<CourseModel>();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "Select * from dbo.Courses";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create student and fill information
                        CourseModel course = new CourseModel();
                        course.CourseId = reader.GetInt32(0);
                        course.Name = reader.GetString(1);
                        course.Desc = reader.GetString(2);
                        course.MaxNumberOfStudents = reader.GetInt32(3);
                        course.NumberOfStudents = reader.GetInt32(4);
                        course.ListOfStudents = reader.GetString(5);

                        returnList.Add(course);
                    }
                }
            }

            return returnList;
        }
    }


}