using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVGenerator.Models;
using CVGenerator.Entities;
using System.Web.Security;

namespace CVGenerator.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult ViewUserProfile(string idTemplate, string idProfile)
        {
            ResumeViewModel vm = new ResumeViewModel();
            using (var db = new GvGenEntities())
            {
                var template = db.TTemplates.FirstOrDefault(p => p.Name == idTemplate);

                if (template == null)
                {
                    //TODO:Redirect 404
                }

                var profile = db.TProfiles.FirstOrDefault(p => p.IdProfile == new Guid(idProfile));
                if (profile == null)
                {
                    //TODO:Redirect 404
                }
                else
                {
                    vm.Template = template;
                    vm.PersonalInformation = profile;
                    vm.Educations = db.TEducations.Where(ed => ed.IdProfile == profile.Id).ToList();
                    vm.WorkExps = db.TWorkExperiences.Where(w => w.IdProfile == profile.Id).ToList();
                    vm.Skills = db.TSkills.Where(s => s.IdProfile == profile.Id).ToList();
                    vm.References = db.TReferences.Where(r => r.IdProfile == profile.Id).ToList();
                }
            }

            return View(vm);
        }

        public ActionResult ViewProfile(string id)
        {
            ViewBag.ProfileGuidId = id;
            return View();
        }

        public ActionResult CreateProfile()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewMyCvs()
        {
            var userEmail = HttpContext.User.Identity.Name;
            MyCvsViewModel viewModel = new MyCvsViewModel();
            viewModel.UserEmail = userEmail;

            using (var db = new GvGenEntities())
            {
                var userId = db.TUsers.First(u => u.Email == userEmail).Id;
                var user = db.TUsers.First(u => u.Email == userEmail);
                viewModel.PersonalInformations = db.TProfiles.Where(p => p.IdUser == userId).ToList();
            }

            return View(viewModel);
        }
    }
}