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
        Dictionary<String,Course> AllCourse = new Dictionary<String,Course>();
        public Dictionary<String, Course> getCourses { get { return AllCourse; } }
        public static Model model;
        public static Model getModel()
        {
            if (model == null)
            {
                model = new Model();
            }
            return model;
        } 
        public List<Student> getByCourses(int id)
        {
            List<Student> and = null;
            foreach (var newAnimal in AllCourse)
            {
                if(newAnimal.Value.Courseidprop == id)
                {
                    // Console.WriteLine(newAnimal.Value);
                    // Console.WriteLine(newAnimal.ToString());
                    and = newAnimal.Value.studentRosterprop; 
                }
               
            }
            return and;
        }
        public  void  setupAdmin()
        {
            AllCourse = Database.GetListOfCourse();
            AllCourse = Database.setStudentList(AllCourse);
        }
        public  int registerCourse(int classid)
        {
            return Database.RegisterForClass(user.ID,classid);
        }
        public void setRegisteredCourses()
        {
            Student u = (Student)user;
            u.listCourse = Database.getCourses(u.ID);
            Console.WriteLine(u.Fullname);
            foreach (var newAnimal in u.classes)
            {
                Console.WriteLine(newAnimal.Key);
                Console.WriteLine(newAnimal.Value);
                Console.WriteLine(newAnimal.ToString());
            }
           
            user = u;
            
        }
        public void setUserCredit()
        {
            Student u = (Student)user;
            u.creditProperty = Database.getTotalCreditHours(u.ID);
        }
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
        public Student getStudent()
        {
            return (Student)user;
        }
        public Administrator getAdmin()
        {
            return (Administrator)user;
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
