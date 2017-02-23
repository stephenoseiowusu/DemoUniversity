using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using DemoUniversity.course;

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
        public static Dictionary<String, Course> setStudentList(Dictionary<String,Course> Courses)
        {

                Student student;
                Initialize();
                foreach(var newCourse in Courses)
                 {
                      String query3 = "Select firstname, lastname, passwords,emailaddress,userid from Users inner join Registration on Users.userid = Registration.student_id where Registration.course_id = @courseId";
                      
                      SqlCommand command = new SqlCommand(query3, conn);
                      command.Parameters.AddWithValue("courseID", newCourse.Value.Courseidprop);
                      SqlDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                     {
                      student = new Student(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                      newCourse.Value.studentRosterprop.Add(student);
                   }
                reader.Close();
            } 
                
                conn.Close();
                
                return Courses;
            
        }
        public static Dictionary<String,Course>GetListOfCourse()
        {
            {
                Dictionary<String, Course> result = new Dictionary<String, Course>();
                String query = "Select Registration.course_id,credit_hour,time_of_day,course_name,major_name, COUNT(reg_id) as 'total students'from Registration inner join Course on Course.course_id = Registration.Course_id inner join major on major.major_id = Course.course_id group by Registration.Course_id,credit_hour,Course.time_of_day,Course.course_name,major.major_name;";
                Initialize();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("lol");
                    int course_id = reader.GetInt32(0);
                    int credit_hour = reader.GetInt32(1);
                    TimeSpan time = reader.GetTimeSpan(2);
                    String course_name = reader.GetString(3);
                    String major_name = reader.GetString(4);
                    int number_of_people = reader.GetInt32(5);
                    Course course = new Course(course_name, time.Hours, credit_hour, major_name);
                    course.Courseidprop = course_id;
                    course.countpeoppro = number_of_people;
                    result.Add(course_name, course);
                }
                reader.Close();
                conn.Close();
                Console.WriteLine("size is" + result.Count);
                return result;
            }
        }
        public static Dictionary<String,Course> getCourses(int id)
        {
            Dictionary<String, Course> result = new Dictionary<String, Course>();
            String query = "Select Registration.course_id,credit_hour,time_of_day,course_name,major_name from Registration inner join Course on Course.course_id = Registration.Course_id inner join Major on major.major_id = Course.course_id where student_id = @studentid";
            Initialize();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("studentid", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("lol");
                int course_id = reader.GetInt32(0);
                int credit_hour = reader.GetInt32(1);
                TimeSpan time = reader.GetTimeSpan(2);
                String course_name = reader.GetString(3);
                String major_name = reader.GetString(4);
                Course course = new Course(course_name, time.Hours, credit_hour, major_name);
                course.Courseidprop = course_id;
                result.Add(course_name, course);
            }
            reader.Close();
            conn.Close();
            Console.WriteLine("size is" + result.Count);
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
        public static int RegisterForClass(int userid, int classid)
        {
            Initialize();
            int credithours = getTotalCreditHours(userid);
            if(credithours == 6)
            {
                
                conn.Close();
                return 0;
                //return "you have reached the max credit hours";
            }
            else
            {
               
                String query1 = "Select credit_hour from Course where course_id = @class";
                SqlCommand command = new SqlCommand(query1, conn);
                command.Parameters.AddWithValue("class", classid);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String num = reader.GetSqlValue(0).ToString();
                    int number = int.Parse(num);
                    if((number + credithours) > 6)
                    {
                        return 1;
                       // return "adding this class would put you over the max credits";
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        String query2 = "Insert into Registration(student_id,Course_id) values (@userID,@Courseid)";
                        command = new SqlCommand(query2, conn);
                        command.Parameters.AddWithValue("userID", userid);
                        command.Parameters.AddWithValue("Courseid", classid);
                        int i= command.ExecuteNonQuery();
                        if(i ==1)
                        {
                            return 2;
                         //   return "Success";
                        }
                        else
                        {
                            return 3;
                           // return "failure to insert";
                        }


                    }
                }
                else
                {
                    reader.Close();
                    conn.Close();
                    return 4;
                    //return "you have entered an invalid course number";
                }
            }

        }
        public static int getTotalCreditHours(int userid)
        {
            Initialize();
            String query1 = "Select count(credit_hour) from Registration r inner join Course c on r.course_ID = c.Course_ID where student_Id = @userid";
            SqlCommand command = new SqlCommand(query1, conn);
            command.Parameters.AddWithValue("userid", userid);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                String num = reader.GetSqlValue(0).ToString();
                reader.Close();
                return int.Parse(num);
            }
            else
            {
                reader.Close();
                return 0;
            }
        }
        public static Users InformUser(String username)
        {
            Student student;
            Initialize();
            String query1 = "Select Users.userid from Users  inner join Administrator  on Administrator.userid = Users.userid where emailaddress  = @username";
            SqlCommand command = new SqlCommand(query1, conn);
            command.Parameters.AddWithValue("username", username);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (1 == 1)
                {
                    conn.Close();
                    return Administrator.getInstance();
                }

               
            }
            else
            {

                String query3 = "Select firstname, lastname, passwords,emailaddress,userid from Users where emailaddress = " + "\'" + username + "\'";
                command = new SqlCommand(query3, conn);
                //command.Parameters.AddWithValue("username", username);
                reader.Close();
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // conn.Close();
                    student = new Student(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                    String query = "Select major from Student where student_id = @studentid";
                    command = new SqlCommand(query3, conn);
                    command.Parameters.AddWithValue("studentid", student.ID);
                    reader.Close();
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
        public  static Boolean grabusername(String username)
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
        public static Boolean DeleteClass(int userid,int classid)
        {
            Initialize();
            String query = "Delete from Registration where student_id = @userid and Course_id = @classid ";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("userid", userid);
            command.Parameters.AddWithValue("classid", classid);
           
          
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                conn.Close();
                return true;

            }
            else
            {
                conn.Close();
                return false;
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
