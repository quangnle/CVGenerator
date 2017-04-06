using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVGenerator.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            AuthenticationManager.SignOut("Cookies");
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
 

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            AuthenticationManager.SignOut("Cookies");
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            return View();
        }
    }
}