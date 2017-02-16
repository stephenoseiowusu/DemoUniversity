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
        public static Boolean login(String username, String password)
        {
            String query = "Select username, usertype from users where username = @username and password = @password";
            Initialize();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add(new SqlParameter("username", username));
            command.Parameters.Add(new SqlParameter("password", password));
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
            return (reader.Read()) == true ? true : false;

        }
        public static Dictionary<int,String> retrievemajors()
        {
            Dictionary<int, String> result = new Dictionary<int, string>();
            String query = "Select * from Major";
            Initialize();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            int i = 1;
            while(reader.Read())
            {
                String course = reader.GetString(0).ToString() ;
                result.Add(i, course);
                i = i + 1;
            }
            
            conn.Close();
            return result;
        }
        public static bool insertMajor(int id,String Major)
        {
            String major;
            retrievemajors().TryGetValue(id, out major);
            String query = "Update Students set major = " + "where student_id = " + id;
            Initialize();
            SqlCommand comm = new SqlCommand(query, conn);
            int result = comm.ExecuteNonQuery();
            if(result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Users InformUser(String username)
        {
            Initialize();
            String query1 = "Select usertype,userid from Student where username = @username";
            SqlCommand command = new SqlCommand(query1, conn);
            command.Parameters.AddWithValue("username", username);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
               if(reader.GetSqlInt64(0) == 0)
               {
                    return Administrator.getInstance();
               }
            }
            else
            {
                String query = "Select major from Student where student_id = @studentid";

                command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("studentid", username.ID);
                reader = command.ExecuteReader();
                Student stu;
                if (reader.Read())
                {
                    String major = reader.GetString(0);
                    stu = new Student(username.firstname, username.lastname, username.Password, username.Email, username.ID, major);
                }
                else
                {
                    stu = new Student(username.firstname, username.lastname, username.Password, username.Email, username.ID);
                }
                return stu;
            }
           


        }
        public static int registerForClass(String username)
        {
            return 0;
          
        }
        public static Boolean registerUser(string username, string password, String firstname, String lastname, int usertype)
        {
            String query = "Insert into Users(emailaddress,passwords,usertype,firstname,lastname) values (@emailaddress,@passwords, @usertype,@firstname,@lastname)";
            Initialize();
         
            int result = 0;
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add(new SqlParameter("emailaddress", username));
            command.Parameters.Add(new SqlParameter("passwords", password));
            command.Parameters.Add(new SqlParameter("usertype",usertype));
            command.Parameters.Add(new SqlParameter("firstname", firstname));
            command.Parameters.Add(new SqlParameter("lastname", lastname));
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
