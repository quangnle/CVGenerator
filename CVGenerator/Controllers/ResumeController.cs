using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVGenerator.Models;
namespace CVGenerator.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult ViewUserProfile(string idTemplate, string idProfile)
        {
            return View();
        }

        public ActionResult ViewProfile(string id)
        {
            return View();
        }

        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProfile(Profile model)
        {
            return new JsonResult();
        }
    }
}