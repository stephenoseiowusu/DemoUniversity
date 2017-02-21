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
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult RegistrationPage()
        {
            return View();
        }
        [HttpPost]
        public HttpResponseMessage Register(JObject reg)
        {
            var response = new HttpResponseMessage();
            
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }
    }
}