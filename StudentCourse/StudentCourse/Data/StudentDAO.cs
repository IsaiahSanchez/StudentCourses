using StudentCourse.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentCourse.Data
{
    internal class StudentDAO
    {
        //does all operations on the database involving the student.

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentCourseDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<StudentModel> FetchAll()
        {
            List<StudentModel> returnList = new List<StudentModel>();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "Select * from dbo.Students";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create student and fill information
                        StudentModel student = new StudentModel();
                        student.ID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);

                        returnList.Add(student);
                    }
                }
            }

            return returnList;
        }


        public StudentModel FetchOne(int id)
        {
            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * from [dbo].[Students] WHERE ID = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                StudentModel student = new StudentModel();
                if (reader.HasRows)
                {
                    //create student and fill information
                    reader.Read();
                    student.ID = reader.GetInt32(0);
                    student.FirstName = reader.GetString(1);
                    student.LastName = reader.GetString(2);

                }
                return student;
            }

            
        }

        public int CreateOrUpdate(StudentModel newStudent)
        {



            //StudentModel student = new StudentModel();
            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "";

                if (newStudent.ID <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Students Values(@FirstName, @LastName)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Students SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = newStudent.ID;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 1000).Value = newStudent.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 1000).Value = newStudent.LastName;

                connection.Open();
                int newID = command.ExecuteNonQuery();
                return newID;
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.Students WHERE Id = @Id ";
               
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;
                connection.Open();
                int newID = command.ExecuteNonQuery();
                
            }

        }
    }
}

    

