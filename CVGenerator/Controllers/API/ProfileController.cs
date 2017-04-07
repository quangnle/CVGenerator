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
        public string Test()
        {
            //throw new Exception("test Exception");
            return "Hello!";
        }

        [HttpPost]
        public HttpResponseMessage SubmitProfile([FromBody]Profile profile)
        {
            using (var db = new Entities.GvGenEntities())
            {
                var entity = profile.GetNew();

                db.TProfiles.Add(entity);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

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
