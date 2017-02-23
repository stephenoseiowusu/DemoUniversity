using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUniversity.courses;
using DemoUniversity.Users;
using System.Threading;

//dssdfsdf
namespace DemoUniversity.course
{




    public class Course : iCourse
    {
        private string title;
        private string major;
        public String majorprop { get { return major; } set { major = value; } }
        public int creditprop { get { return creditHour; } }
        public Boolean isClosed = false;
        public int getDate{get{return timeOfDay;} }
        private int timeOfDay;
        private int creditHour;
        private int courseid;
        private int countpeop;
        public String titleprop { get { return title; } }
        public int countpeoppro { get { return countpeop; } set { countpeop = value; } }
        public int Courseidprop { get { return courseid; } set {courseid = value; } }
        private List<Student> studentRoster = new List<Student>();
        public List<Student> studentRosterprop { get { return studentRoster; }set { studentRoster = value; } }
     //   private DateTime dateTime;
        public delegate bool CloseRegistration(Course thisCoursetoClose);
        public CloseRegistration cr = null;

        public Course(string title, int hour,int creditHour, string major = "undecided" )
        {
            this.title = title;
            this.major = major;
            this.timeOfDay = hour;
            this.creditHour = creditHour;
        }
        public Course(String title, int timeofDay)
        {
            this.title = title;
            this.timeOfDay = timeofDay;
        }
        public Student GetStudentByID(int id)
        {
            var temp = from x in studentRoster
                       where x.ID == id
                       select x;
            var student = studentRoster.Where(x => x.ID == id).FirstOrDefault();
            return student;
        }
        public IEnumerable<Student> GetStudentByName(String Firstname)
        {
            var student = studentRoster.Where(x => x.Fullname.Equals($"{Firstname}"));
            return student;
        }
        public Student GetStudentByFullName(String name, String lastname)
        {
            return GetStudentByFullName("{name} {lastname}");
        }
        public Student GetStudentByFullName(String Name)
        {
            var student = studentRoster.Where(x => x.Fullname.Equals(Name)).FirstOrDefault();
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
        

        public void PrintRosterCount()
        {
         
            Thread.Sleep(2000);
            Console.WriteLine("num of students: " + studentRoster.Count);
        }
        public string titles
        {
            get
            {
                return title;
            }

            set
            {
               title = titles;
            }
        }

        public bool AddStudent(Student student)
        {

            int count = studentRoster.Count;
            studentRoster.Add(student);
            if(cr !=null && isFull)
            {
                cr(this);
            }
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
        public bool RemoveStudentById(int id)
        {
            return studentRoster.Remove(GetStudentByID(id));
          //  return false;
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
            return studentRoster;
        }
        public async Task<List<Student>> GetStudentRoster()
        {
            Console.WriteLine("start async");
            var results = await FetchRoster();
            return studentRoster;
        }
        public Task<List<Student>> FetchRoster()
        {
            return Task.Run(() => { return studentRoster; }); 
        }     

        public IEnumerable<Student> GetIenumerableStudentList()
        {
            return studentRoster;
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
