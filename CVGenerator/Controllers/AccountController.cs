using CVGenerator.Entities;
using CVGenerator.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CVGenerator.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var context = new Entities.GvGenEntities())
            {
                var entities = context.TUsers.Where(m => m.Name == model.Email && m.Password == model.Password).ToList();
                if (entities.Count == 1)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Login failed. Email or Username is not existed");
                }
            }

            return View("login");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var context = new GvGenEntities())
            {
                var mailExists = context.TUsers.FirstOrDefault(m => m.Email == model.Email);
                if (mailExists == null)
                {
                    var entity = new TUser();
                    entity.Name = model.Email;
                    entity.Email = model.Email;
                    entity.Password = model.Password;
                    entity.Role = (int)AuthRole.User;
                    context.TUsers.Add(entity);
                    context.SaveChanges();
                    return RedirectToAction("ConfirmEmail");
                }
                else
                {
                    ModelState.AddModelError("Email", "Your email has been existed in the system.");
                    return View(model);
                }
            }
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}