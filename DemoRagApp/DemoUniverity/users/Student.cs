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
        public String majorProperty { get { return major; } set { major = value; } }
        public Dictionary<string, Course> classes = new Dictionary<string, Course>();
        
        public Dictionary<string, Course> listCourse
        {
            get { return classes; }
            set { classes = value; }
        }
        public int creditProperty { get { return credit_hours; } set { credit_hours = value; } }
        int credit_hours = 0;
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
