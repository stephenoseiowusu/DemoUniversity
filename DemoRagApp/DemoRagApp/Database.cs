using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DemoRagApp
{


    public class Database
    {
        private static SqlConnection conn;
        public Database()
        {

        }
       
        private static String GetConnectionString()
        {
            return "Data Source=throwawaydb.cacbbedpgsnb.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RagApp;Persist Security Info=True;User ID=master;Password=lolmaster";
        }
        /// <summary>
        /// returns 0 if success 
        /// returns 1 if failue 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Boolean login(String username, String password, int which)
        {
            String query = which == 1 ? "Select username from students where username = @username and password = @password" : "select username from admin where username = @username and password = @password";
            Initialize();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add(new SqlParameter("username", username));
            command.Parameters.Add(new SqlParameter("password", password));
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
            return (reader.Read()) == true ? true : false;

        }
        public static int registerForClass(String username)
        {

          //  return false;
        }
        public static Boolean registerAdmin(string username, string password)
        {
            String query = "Insert into Users(emailaddress,passwords,usertype) values (@emailaddress,@passwords, 0)";
            Initialize();
         
            int result = 0;
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add(new SqlParameter("emailaddress", username));
            command.Parameters.Add(new SqlParameter("passwords", password));
          //  command.Parameters.Add(new SqlParameter("type",0));
            int i = command.ExecuteNonQuery();
            conn.Close();
            return i == 1? true : false;
           
        }
        public static void Initialize()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = GetConnectionString();
                conn.Open();
            }
            catch (Exception e)
            {

            }
        }
    }
}
