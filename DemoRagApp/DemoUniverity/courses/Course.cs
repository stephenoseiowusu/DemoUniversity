using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUniversity.courses;
using DemoUniversity.Users;

//dssdfsdf
namespace DemoUniversity.course
{
    

    public class Course : iCourse
    {
        private string title;
        private string major;
        private DateTime timeOfDay;
        private int creditHour;
        private List<Student> studentRoster = new List<Student>();
        private DateTime dateTime;

        public Course(string title, DateTime timeofDay,int creditHour, string major = "DateTime timeofDay" )
        {
            this.title = title;
            this.major = major;
            this.timeOfDay = timeofDay;
            this.creditHour = creditHour;
        }
        public Course(String title, DateTime timeofDay)
        {
            this.title = title;
            this.timeOfDay = timeofDay;
        }
        public Student GetStudentByID(int id)
        {
            var student = studentRoster.Where(x => x.ID == id).FirstOrDefault();
            return student;
        }
        public IEnumerable<Student> GetStudentByName(String Firstname)
        {
            var student = studentRoster.Where(x => x.Fullname.Equals($"{Firstname} a"));
            return student;
        }
        public bool isFull
        {
            get
            {
                return studentRoster.Count == Global.maxStudents;  
            }
        }

        public int rosterCount
        {
            get
            {
                return studentRoster.Count;
            }

          
        }

        int iCourse.rosterCount
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

    
        public string titles
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AddStudent(Student student)
        {

            int count = studentRoster.Count;
            studentRoster.Add(student);
            return true;
        }

        public bool AddStudents(List<Student> roster)
        {
         
            SpaceCheck(roster.Count + studentRoster.Count);
           
            foreach (Student item in roster)
            {
                AddStudent(item);
            } 
            return true;
        }

        public void Path()
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public List<Student> StudentRoster()
        {
            throw new NotImplementedException();
        }

        private bool SpaceCheck(int countDracula)
        {
            if(countDracula > Global.maxStudents)
            {
                throw new Exception(Errors.notEnoughSpace);
            }
            return true;
        }
    }
}
