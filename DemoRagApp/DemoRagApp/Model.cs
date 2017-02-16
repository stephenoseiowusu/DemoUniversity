using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRagApp
{

    class Model
    {

        static Users user;
      
        public bool Login(String username,String password)
        {
            if (Database.login(username, password))
            {
                user = Database.getUser();
                return true;

            }
            else
            {
                return false;
            }

        }
        public int Register(String Username, String password, String email,String first, String last, int type)
        {
            if (Database.registerUser(Username, password, first, last, type) == true)
            {
               
                if(type == 1)
                {
                    user = new Student(first, last, password, email, 10, "undecided");
                }
                else
                {
                    user = Administrator.getInstance();
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
           return  Database.insertMajor(user.ID, major);

        }
        public int classRegistration(int ClassID)
        {
            return 1;
        }

    }

}
