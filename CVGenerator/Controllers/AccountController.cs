﻿using CVGenerator.Entities;
using CVGenerator.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                    var tickValue = string.Concat(entities[0].Id.ToString(), "|", DateTime.Now.ToFileTime());
                    var ticket = new FormsAuthenticationTicket(1, "userId", DateTime.Now, DateTime.Now.AddMinutes(30), false, tickValue);
                    string token = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                    AccountHelper.Token = token;

                    //new FormsAuthentication().SetAuthCookie(model.Email, model.RememberMe, ticketData);
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

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var context = new GvGenEntities())
            {
                var entity = context.TUsers.FirstOrDefault(m => m.Email == HttpContext.User.Identity.Name && m.Password == model.OldPassword);
                if (entity != null)
                {
                    entity.Password = model.Password;
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    ViewBag.SuccessMessage = "Your password has been changed successfully! Thank you.";
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Current password incorrect.");
                    return View(model);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AccountHelper.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("HomePageRedirect");
        }

        [HttpGet]
        public ActionResult HomePageRedirect()
        {
            return View();
        }
    }
}