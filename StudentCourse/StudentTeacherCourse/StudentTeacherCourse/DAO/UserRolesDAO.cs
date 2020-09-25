using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.DAO
{
    public class UserRolesDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-StudentTeacherCourse-20200901043005;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void SetUserRole(string Id, bool shouldBeInstructor)
        {

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                

                string sqlQuery = "INSERT INTO dbo.AspNetUserRoles Values(@Id, @RoleId)";
                string roleId = "";
                if (shouldBeInstructor == false)
                {
                    roleId = "1";
                }
                else
                {
                    roleId = "2";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = Id;
                command.Parameters.Add("@RoleId", System.Data.SqlDbType.VarChar, 1000).Value = roleId;

                connection.Open();
                int newID = command.ExecuteNonQuery();

            }
        }
    }
}