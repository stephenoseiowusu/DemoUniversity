using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUniversity;
using DemoUniversity.Users;
using DemoUniversity.courses;
using DemoUniversity.course;
using System.Threading;
//using DemoUniversity.Users.Student;
namespace DemoRagApp
{
    class Program
    {/*
        static void Main(string[] args)
        {
            Course testCourse = new Course("courses100",new DateTime());
            Student s = new Student("f", "l", "pwd", "aaa.com", 1);
            Users u = Administrator.getInstance();
            List<Student> slist = new List<Student>();
            testCourse.AddStudent(s);
         //   Console.WriteLine(testCourse.rosterCount);
            testCourse.AddStudent(s);
            Console.WriteLine(testCourse.rosterCount);
            Student paul = new Student("Paul", "a", "pwd", "1@1.com", 1);
            Student mike = new Student("Mike", "a", "pwd", "2@2.com", 2);
            Student stephen = new Student("Stephen", "a", "pwd", "3@3.com", 3);
            Student chris = new Student("Chris", "a", "pwd", "4@4.com", 4);
            Student devonte = new Student("Devonte", "a", "pwd", "5@5.com", 5);
            Student alain = new Student("Alain", "a", "pwd", "6@6.com", 6);
            Student antone = new Student("Antone", "a", "pwd", "7@7.com", 7);
            Student erik = new Student("Erik", "a", "pwd", "8@8.com", 8);
            Student summer = new Student("Summer", "a", "pwd", "9@9.com", 9);
            Student kirk = new Student("Stephen", "ab", "pwd", "10@10.com", 10);
            Course dotnet = new Course("dotnet", new DateTime());
            dotnet.cr = Administrator.CloseCourse;
            
            dotnet.AddStudent(paul);
            dotnet.AddStudent(mike);
            dotnet.AddStudent(stephen);
            dotnet.AddStudent(chris);
            dotnet.AddStudent(devonte);
            dotnet.AddStudent(alain);
            dotnet.AddStudent(antone);
            dotnet.AddStudent(erik);
            dotnet.AddStudent(summer);
            dotnet.AddStudent(kirk);
            dotnet.AddStudent(kirk);
            dotnet.AddStudent(kirk);
            var studentlist = dotnet.GetStudentRoster();
            Console.WriteLine( studentlist.Result.Count);
           // t1.Join();
            
            Thread t2 = new Thread(dotnet.PrintRosterCount);
            t2.Start();
            // dotnet.RemoveStudentById(paul.ID);
            // dotnet.cr = CloseCourse;
            // Console.WriteLine(dotnet.GetStudentByName("Paul"));
            // Console.WriteLine(dotnet.GetStudentByName("stephen"));
            // Console.WriteLine(dotnet.GetStudentByFullName("Paul a"));
            /*
                        for (int i = 0; i < 3; i++)
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


                         */
            //Console.Read();
        }

        //
       
    }

