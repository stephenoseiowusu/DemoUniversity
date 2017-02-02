using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUniversity;
using DemoUniversity.Users;
using DemoUniversity.courses;
//using DemoUniversity.Users.Student;
namespace DemoRagApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Courses testCourse = new Courses("courses100",new DateTime());
            Student s = new Student("f", "l", "pwd", "aaa.com", 1);
            Users u = new Administrator();
            List<Student> slist = new List<Student>();
            testCourse.AddStudent(s);
            Console.WriteLine(testCourse.rosterCount);
            testCourse.AddStudent(s);
            Console.WriteLine(testCourse.rosterCount);


            for(int i = 0; i < 3; i++)
            {
                slist.Add(s);
            }
            try
            {
                testCourse.AddStudents(slist);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine(e.ToString());
            }
            
            Console.Read();
        }
        
    }
}
