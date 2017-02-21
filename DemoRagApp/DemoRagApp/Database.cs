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
            Boolean loggedin = false;
            String query = "Select emailaddress, usertype from users where emailaddress = @username and passwords = @password";
            Initialize();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add(new SqlParameter("username", username));
            command.Parameters.Add(new SqlParameter("password", password));
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                loggedin = true;
            }
           
            conn.Close();
            return loggedin;

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
        public static bool insertMajor(int id, String Major)
        {
            Initialize();


            //  retrievemajors().TryGetValue(id, out major);
            int major_id=1;
            String querys = "Select major_id from Major where  major_name = " + "'" + Major + "'";
            SqlCommand getMajorID = new SqlCommand(querys, conn);

            SqlDataReader read = getMajorID.ExecuteReader();
            Console.WriteLine(getMajorID.CommandText);
            if (read.Read()) { 
            major_id = read.GetInt32(read.GetOrdinal("major_id"));
            }
            read.Close();
            String query = "Update Students set student_major = " + major_id + " where student_id = " + id;
            Console.WriteLine(query);
            SqlCommand comm = new SqlCommand(query, conn);
            int result = comm.ExecuteNonQuery();
            conn.Close();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public static Users InformUser(String username)
        {
            Student student;
            Initialize();
            String query1 = "Select usertype,userid from Users where emailaddress = @username";
            SqlCommand command = new SqlCommand(query1, conn);
            command.Parameters.AddWithValue("username", username);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetSqlValue(0).ToString() == "0")
                {
                    conn.Close();
                    return Administrator.getInstance();
                }

                else
                {

                    String query3 = "Select firstname, lastname, password,email,id from Users where username = @username";
                    command = new SqlCommand(query3, conn);
                    command.Parameters.AddWithValue("username", username);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // conn.Close();
                        student = new Student(reader.GetString(0), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                        String query = "Select major from Student where student_id = @studentid";
                        command = new SqlCommand(query3, conn);
                        command.Parameters.AddWithValue("studentid", student.ID);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!reader.GetString(0).ToString().Equals(""))
                            {

                                student.majorProperty = reader.GetString(0);
                            }

                        }

                        conn.Close();
                        return student;
                    }
                }
            }

            conn.Close();
            return null;
            }
        public static int registerForClass(String username)
        {
            return 0;
          
        }
        public static int getUserID(String username)
        {
            String query = "Select username from Users where username = @user";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("user", username);
            Initialize();
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                conn.Close();
                return read.GetInt32(0);

            }
            else
            {
                conn.Close();
                return -1;
            }
        }
        private static Boolean grabusername(String username)
        {
            String query = "Select username from Users where username = @user";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("user", username);
            Initialize();
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                conn.Close();
                return false;

            }
            else
            {
                conn.Close();
                return true;
            }
           
        }
        public static Boolean registerUser(string username, string password, String firstname, String lastname, int usertype)
        {
            if (grabusername(username) == true)
            {
                return false;
            }
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
            Console.WriteLine(i + " result");
            return i == 2? true : false;
           
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
