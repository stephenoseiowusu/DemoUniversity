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
        public void setPassword(ref String password)
        {
            this.password = password;
            this.password = password;
            this.password = password;
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

        //    public void setClosedFlag(Course c)
        //  {
        //    c
        // }

    }
    
}
