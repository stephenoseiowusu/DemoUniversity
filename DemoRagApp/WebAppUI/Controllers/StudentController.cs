using DemoRagApp;
using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppUI.Controllers
{
    
    public class StudentController : Controller
    {
        Users currentuser;
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getStudent (Student student)
        {
            currentuser = student;
            Student u = (Student)Model.getModel().returnUser();
            Model.getModel().setUserCredit();
            ViewBag.credithours = u.creditProperty;
            ViewBag.user = currentuser;
            ViewBag.username = Model.getModel().returnUser().Fullname;
            return View();
        }
        public ViewResult getAdmin(Administrator admin)
        {
            currentuser = admin;
            ViewBag.user = currentuser;
            return View();
        }
        
    }
}