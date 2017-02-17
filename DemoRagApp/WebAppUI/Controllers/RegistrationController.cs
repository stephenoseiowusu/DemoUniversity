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
        [HttpPost]
        public HttpResponseMessage Register(String firstname, String lastname, String username, String password,int usertype)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }
    }
}