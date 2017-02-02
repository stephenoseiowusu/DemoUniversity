using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUniversity.Users;
namespace DemoUniversity.courses
{
    interface iCourse
    {
        bool AddStudent(Student student);
        bool RemoveStudent(int id);
        bool RemoveStudent(Student student);
        bool RemoveStudent(string firstname, string lastname);
        bool isFull { get; }
        int rosterCount { get; set; }
        List<Student> StudentRoster();
        string titles { get; set; }
        
        bool AddStudents(List<Student> roster);




    }
}
