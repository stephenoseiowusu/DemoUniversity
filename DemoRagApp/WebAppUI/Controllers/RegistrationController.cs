using DemoRagApp;
using DemoUniversity.Users;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebAppUI.Controllers
{
    public class RegistrationController : Controller
    {
        public static int failure = 0;
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult RegistrationPage()
        {
            if(failure != 0)
            {
                ViewBag.isLogged = false;
            }
           
            return View();
        }
        [HttpPost]
        public HttpResponseMessage Register(JObject reg)
        {
            var response = new HttpResponseMessage();
            
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }
        [HttpPost]
        public ActionResult login(String username, String password)
        {
            Model mod = Model.getModel();
            bool did = mod.Login(username, password);
            if (did == true)
            {

                Users which = mod.returnUser();
                if (which is Student )
                {
                    failure = 1;
                    Model.getModel().setRegisteredCourses();
                    return RedirectToAction("getStudent", "Student", new { student = which });
                }
                else
                {
                    failure = 1;
                    return RedirectToAction("getAdmin", "Student", new { admin = which });
                }

            }
            else
            {
                ViewBag.isLogged = false;
                failure = 1;
                RegistrationController co = new RegistrationController();
                co.ViewBag.isLogged = false;
                RegistrationController.failure = 1;
                return RedirectToAction("RegistrationPage", "Registration");
                //   return null;
            }

        }
    }
}