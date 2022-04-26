using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SignUp_MVC.Models
{
    public class UserManagment
    {
        static string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MVC_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static bool SaveLoginInfo(UserBO user)
        {
            SqlConnection conn = new SqlConnection(constr);

            string query = $"insert into Users values ('{user.Username}', '{user.Password}', '{user.Email}')";
            
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            int n = cmd.ExecuteNonQuery();

            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UserAlreadyExist(UserBO user)
        {
            SqlConnection conn = new SqlConnection(constr);

            string query =$"select * from Users where email='{user.Email}'";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
