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
            ViewBag.user = currentuser;
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