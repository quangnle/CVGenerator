using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVGenerator.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult ViewProfile(string id)
        {
            return View();
        }

        public ActionResult CreateProfile()
        {
            return View();
        }
    }
}