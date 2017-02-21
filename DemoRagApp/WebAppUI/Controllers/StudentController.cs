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
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getStudent (Student student)
        {
            return View();
        }
        public ViewResult getAdmin(Administrator admin)
        {
            return View();
        }
    }
}