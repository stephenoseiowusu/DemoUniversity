using DemoRagApp;
using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppUI.Controllers
{
    public class CourseController : Controller
    {
        public Student stu = Model.getModel().getStudent();

        // GET: Course
        public ActionResult Index()
        {
            
            ViewBag.user = Model.getModel().returnUser();
            return View();
        }
        public ViewResult getCourse()
        {
            Model.getModel().setRegisteredCourses();
           Console.WriteLine( Model.getModel().getStudent().listCourse.Count);
            stu = Model.getModel().getStudent();
            ViewBag.user = Model.getModel().getStudent(); 
            return View();
        }
        [HttpPost]
        public ActionResult signUp(int Courseid)
        {
            int result = Model.getModel().registerCourse(Courseid);
            ViewBag.SignUp = result;
            return RedirectToAction("getCourse", "Course");
            
           
        }
    }
}