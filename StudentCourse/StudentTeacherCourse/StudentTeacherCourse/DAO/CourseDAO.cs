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

        public void addStudentToCourse(int StudentId, string CourseID)
        {
            CourseModel course = getCourse(CourseID);
            if (checkIfStudentIsInCourse(course, StudentId))
            {
                //not supposed to already be part of it so fail
            }
            else
            {
                //add student
                List<int> studentIds = OpenStudentList(course);
                studentIds.Add(StudentId);
                SaveStudentList(course, studentIds);
            }

        }

        public void removeStudentFromCourse(int StudentId, string CourseID)
        {
            CourseModel course = getCourse(CourseID);
            if (checkIfStudentIsInCourse(course, StudentId))
            {
                //remove student
                List<int> studentIds = OpenStudentList(course);
                studentIds.Remove(StudentId);
                SaveStudentList(course, studentIds);
            }
            else
            {
                //fail because somehow we got here but the student isn't already part of the course
            }
            
            
        }

        public CourseModel getCourse(string CourseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "Select * from dbo.Courses WHERE Id = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = CourseId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    CourseModel course = new CourseModel();
                    reader.Read();
                    course.CourseId = reader.GetInt32(0);
                    course.Name = reader.GetString(1);
                    course.Desc = reader.GetString(2);
                    course.MaxNumberOfStudents = reader.GetInt32(3);
                    course.NumberOfStudents = reader.GetInt32(4);
                    course.ListOfStudents = reader.GetString(5);
                    return course;
                }
                else
                {
                    CourseModel course = new CourseModel();
                    course.Name = "Failed";
                    course.Desc = "Search Failed. Couldn't find one with that id.";
                    return course;
                }

            }


        }


        private List<int> OpenStudentList(CourseModel course)
        {
            List<string> UnConvertedList = new List<string>();
            char[] array = course.ListOfStudents.ToCharArray();

            string currentNumber = "";
            for (int index = 0; index < array.Length; index++)
            {
                if (array[index].Equals(','))
                {
                    UnConvertedList.Add(currentNumber);
                    currentNumber = "";
                }
                else
                {
                    currentNumber = currentNumber + array[index];
                }
            }


            List<int> StudentIds = new List<int>();
            for (int index = 0; index < UnConvertedList.Count; index++)
            {
                StudentIds.Add(int.Parse(UnConvertedList[index]));
            }

            return StudentIds;
        }

        private void SaveStudentList(CourseModel course, List<int> StudentIds)
        {
            string finalString = "";

            for (int index = 0; index < StudentIds.Count; index++)
            {
                finalString = finalString + StudentIds[index];
                finalString = finalString + ",";
            }

            course.ListOfStudents = finalString;
            course.NumberOfStudents = StudentIds.Count + 1;
            //save to database


        }

        public bool checkIfStudentIsInCourse(CourseModel course, int studentId)
        {
            List<int> studentIds = OpenStudentList(course);
            foreach (int i in studentIds)
            {
                if (i == studentId)
                {
                    return true;
                }
            }
            return false;
        }
    }


}