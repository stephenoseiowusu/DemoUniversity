using DemoRagApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppUI.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult ClassInfo(int classid)
        {
            ViewBag.studentlist = Model.getModel().getByCourses(classid);
            ViewBag.ClassID = classid;
            return View();
        }
        public ActionResult dropstudent(int studentID, int classID)
        {

            Model.getModel().DeleteClass(studentID, classID);
            ViewBag.studentlist = Model.getModel().getByCourses(classID);
            return RedirectToAction("classInfo","Classes",new { classid = classID });
        }
    }
}