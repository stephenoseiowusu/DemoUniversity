using DemoUniversity.course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUniversity.Users
{
   public  class Student:Users
    {
        private String major;
        private bool isFullTime;
       // List<Courses> classes = new List<Courses>();
        Dictionary<string, Course> classes = new Dictionary<string, Course>();
        //enum year
        //array of their courses 
        public Student()
        {

        }
         
        public Student(string firstname, string lastname, string password, string email, int id, string major = "undecided"): base(firstname,lastname,password,email,id)
        {
            
            this.major = major;
            this.isFullTime = false;
            
        }

        public override string getInfo()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append($"\n{major}");
            sb.Append($"\n fulltime: {isFullTime}");
            if(classes.Count == 0)
            {
                sb.Append($"notregistered for classes");
            }
            else
            {
                foreach( KeyValuePair<String,Course> item in classes)
                {
                    sb.Append("\n");
                    sb.Append(item.Value.titles);
                }
            }

            return sb.ToString();
        }
    }
}
