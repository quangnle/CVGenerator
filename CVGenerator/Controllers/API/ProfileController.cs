using CVGenerator.Entities;
using CVGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CVGenerator.Controllers.API
{
    public class ProfileController : BaseApiController
    {
        [HttpGet]
        public int Ping()
        {
            return 1;
        }

        [HttpPost]
        public HttpResponseMessage SubmitProfile([FromBody]Profile profile)
        {
            using (var db = new GvGenEntities())
            {
                var entity = profile.GetNew();

                db.TProfiles.Add(entity);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage SubmitPersonalInfo([FromBody]Profile profile)
        {
            var entity = profile.GetNew();
            using (var db = new GvGenEntities())
            {
                db.TProfiles.Add(entity);
                db.SaveChanges();
            }
            var dataReturn = new { Id = entity.Id, GuidId = entity.IdProfile };       
            var message = Request.CreateResponse(HttpStatusCode.OK, dataReturn);
            return message;
        }

        [HttpGet]
        public HttpResponseMessage GetUserProfile(string idProfile)
        {
            using (var db = new GvGenEntities())
            {
                var profile = db.TProfiles.FirstOrDefault(e => e.IdProfile == new Guid(idProfile));
                if (profile == null)
                {
                    throw new Exception("Invalid Profile ID.");
                }
                
                var educations = db.TEducations.Where(ed => ed.IdProfile == profile.Id).ToList();
                var workExps = db.TWorkExperiences.Where(w => w.IdProfile == profile.Id).ToList();
                var skills = db.TSkills.Where(s => s.IdProfile == profile.Id).ToList();
                var references = db.TReferences.Where(r => r.IdProfile == profile.Id).ToList();

                var dataReturn = new {
                    PersonalInformation = profile,
                    Educations= educations,
                    WorkExps = workExps,
                    Skills = skills,
                    References = references,
                };
               
                return Request.CreateResponse(HttpStatusCode.OK, dataReturn);
            }
        }

        //[HttpGet]       
        //public TProfile GetProfile(int id)
        //{
        //    using (var db = new GvGenEntities())
        //    {
        //        var entity = db.TProfiles.FirstOrDefault(e => e.Id == id);

        //        return entity;
        //    }
        //}

        //public List<TProfile> GetProfileByUserId(int idUser)
        //{
        //    using (var db = new GvGenEntities())
        //    {
        //        var list = db.TProfiles.Where(e => e.IdUser == idUser).ToList();

        //        return list;
        //    }
        //}
    }
}
