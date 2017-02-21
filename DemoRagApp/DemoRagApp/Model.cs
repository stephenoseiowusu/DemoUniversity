using DemoUniversity.course;
using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRagApp
{

    public class Model
    {

         Users user;
        List<Course> AllCourse = new List<Course>();
         
      
        public bool Login(String username,String password)
        {
            if (Database.login(username, password))
            {
                user = Database.InformUser(username);
                return true;

            }
            else
            {
                return false;
            }

        }
        public Users returnUser()
        {
            return user;
        }
        public int Register(String Username, String password, String email,String first, String last, int type)
        {
            Console.WriteLine("DFssssDFFD");
            if (Database.registerUser(Username, password, first, last, type) == true)
            {
               
                if(type == 1)
                {
                    int id = Database.getUserID(Username);
                   user = new Student(first, last, password, email, id, "undecided");
                    if (user == null)
                    {
                        Console.WriteLine("DFDFFD");
                    }
                    Console.WriteLine("DFDFFD");
                }
                else
                {
                    user = Administrator.getInstance();
                    if (user != null)
                    {
                        Console.WriteLine("DFDFFD");
                    }
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public Dictionary<int,String> getMajors()
        {
            return Database.retrievemajors();
        }
        public bool setMajor(String major)
        {
           if(user== null)
            {
                Console.WriteLine("DFDFFD");
            }
           return  Database.insertMajor(user.ID, major);

        }
        public int classRegistration(int ClassID)
        {
            return 1;
        }
        

    }

}
