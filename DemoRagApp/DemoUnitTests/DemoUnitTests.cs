using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DemoUniversity.Users;
using DemoUniversity.course;

namespace DemoUnitTests
{
    [TestFixture]
    public class DemoUnitTests
    {

        [SetUp]
        protected void SetUpMockData()
        {

        }
        [Test]
        public void AddNUmbers()
        {
            //arrange
            int i = 1;
            int d = 2;
            //act
            int answer = i + d;
            //assert
            Assert.AreEqual(answer,i + d);
            Assert.AreNotEqual(answer,i);
            
        }
       
        [Test]
       
        public void CourseFullException()
        {
            Course testCourse = new Course("courses100", new DateTime());
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
            
            Assert.Throws<System.Exception> (() => dotnet.AddStudent(kirk));
        }
    }
}
