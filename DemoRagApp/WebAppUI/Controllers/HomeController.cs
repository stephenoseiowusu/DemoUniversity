using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoRagApp;
using DemoUniversity.Users;

namespace WebAppUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult UniHome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(String username,String password)
        {
            Model mod = new Model();
            bool did = mod.Login(username, password);
            if(did == true)
            {
                StudentController con = new StudentController();
                Users which = mod.returnUser();
                if(which is Student)
                {
                    return RedirectToAction("getStudent",con);
                }
                else
                {
                    return con.getAdmin((Administrator)which);
                }
                
            }
            else
            {
                   ViewBag.isLogged = false;
                RegistrationController co = new RegistrationController();
                   return RedirectToAction("RegistrationPage", new RegistrationController());
                //   return null;
            }

        }

    }
}