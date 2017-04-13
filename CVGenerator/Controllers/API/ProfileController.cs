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
            //.var a=new HttpResponseMessage()
            var message = new HttpResponseMessage(HttpStatusCode.OK);
           // message.Content = entity.Id;
           var aaa= Request.CreateResponse<int>(HttpStatusCode.OK, Tobject);
            return message;
        }

        [HttpPost]
        public HttpResponseMessage SubmitEducation(int profileId,[FromBody]List<Education> educations)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage SubmitWorkExperience([FromBody]Profile profile)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage SubmitReference([FromBody]Profile profile)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage SubmitSkill([FromBody]Profile profile)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public TProfile GetProfile(int id)
        {
            using (var db = new GvGenEntities())
            {
                var entity = db.TProfiles.FirstOrDefault(e => e.Id == id);

                return entity;
            }
        }

        public List<TProfile> GetProfileByUserId(int idUser)
        {
            using (var db = new GvGenEntities())
            {
                var list = db.TProfiles.Where(e => e.IdUser == idUser).ToList();

                return list;
            }
        }
    }
}
