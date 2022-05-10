using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SignUp_MVC.Models.ViewModels;

namespace SignUp_MVC.Models
{
    public class UserManagment
    {
        static string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MVC_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<UserBO> users;
        public static List<Address> addresses;
        public static List<UserInfo> infos;


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
        public static List<UserInfo> GetAllUsersInfo()
        {
            infos=new List<UserInfo>();

            SqlConnection conn = new SqlConnection(constr);

            string query = $"select u.username,u.password,u.email,a.area,a.city,a.country from Users u inner join Addresses a on u.email=a.userEmail";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserInfo info = new UserInfo();

                info.UserIds = new UserBO();
                info.UserAddress = new Address();

                info.UserIds.Username= dr[0].ToString();
                info.UserIds.Password= dr[1].ToString();
                info.UserIds.Email= dr[2].ToString();
                info.UserAddress.Area= dr[3].ToString();
                info.UserAddress.City= dr[4].ToString();
                info.UserAddress.Country= dr[5].ToString();

                infos.Add(info);
            }
            conn.Close();
            return infos;
        }
        public static List<UserBO> GetAllUsers()
        {
            users = new List<UserBO>();

            SqlConnection conn = new SqlConnection(constr);

            string query = $"select * from Users";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserBO user = new UserBO();

                user.Username = dr[0].ToString();
                user.Email = (string)dr[1];
                user.Password = (string)dr[2];
               
                users.Add(user);
            }
            conn.Close();
            return users;
        }
        public static List<Address> GetAllAddresses()
        {
            addresses=new List<Address>();

            SqlConnection conn = new SqlConnection(constr);

            string query = $"select * from Addresses";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Address ad=new Address();

                ad.Area = dr[1].ToString();
                ad.City = dr[2].ToString();
                ad.Country= dr[3].ToString();

                addresses.Add(ad);
            }
            conn.Close();
            return addresses;
        }
    }
}
