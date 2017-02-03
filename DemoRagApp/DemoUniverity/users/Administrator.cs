using DemoUniversity.course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUniversity.Users
{
    public  class Administrator : Users
    {
        private static Administrator admin = null;
        public void setPassword(ref String password)
        {
            this.password = password;
            this.password = password;
            this.password = password;
        }
        private Administrator()
        {

        }
        public static Administrator getInstance()
        {
            if(admin == null)
            {
                admin = new Administrator();
                return admin;
            }
            else
            {
                return admin;
            }
        }
        public override String getInfo()
        {
            return base.ToString();
        }

        public static bool CloseCourse(Course thisCourseToCLose)
        {
            thisCourseToCLose.isClosed = true;
            Console.WriteLine("course is close");
            return true;
        }
        public static bool ChangeCourseStatus(Course thisCourseToChange)
        {
            thisCourseToChange.isClosed = !thisCourseToChange.isClosed;
            Console.WriteLine("registration is " + (thisCourseToChange.isClosed ? "Closed" : "Open"));
            return true;
        }

        
    }
    
}
