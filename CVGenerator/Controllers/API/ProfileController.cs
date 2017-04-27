using CVGenerator.Entities;
using CVGenerator.Models;
using CVGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

            var token = Request.Headers.Authorization;
            if (token != null && token.Scheme.Length != 0 && token.Scheme != "null")
            {
                var id = System.Web.Security.FormsAuthentication.Decrypt(token.Scheme).UserData.Split('|')[0];
                var userId = Convert.ToInt32(id);
                entity.IdUser = userId;
            }

            using (var db = new GvGenEntities())
            {
                if (entity.Id > 0)
                {
                    var entityEntry = db.Entry<TProfile>(entity);
                    entityEntry.State = EntityState.Modified;
                }
                else
                {
                    db.TProfiles.Add(entity);
                }

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

                var dataReturn = new
                {
                    PersonalInformation = profile,
                    Educations = educations,
                    WorkExps = workExps,
                    Skills = skills,
                    References = references,
                };

                return Request.CreateResponse(HttpStatusCode.OK, dataReturn);
            }
        }

        //[HttpGet]
        //public HttpResponseMessage Generate(string url, string id)
        //{

        //    WebClient client = new WebClient();
        //    string downloadString = client.DownloadString("http://localhost:52714/mycv/darkblue/6B96D41A-101E-4781-BDC4-1F8A6F7F8E98/");
           
        //    var gen = PdfGenerator.GetInstance();
        //    var exportPath = ConfigurationManager.AppSettings["CVPath"];
        //    gen.ConvertToPDF("http://localhost:52714/mycv/darkblue/6B96D41A-101E-4781-BDC4-1F8A6F7F8E98/", id + ".pdf");
            
        //    var byteArr = File.ReadAllBytes(exportPath + "/" + id + ".pdf");

        //    var stream = new MemoryStream(byteArr);
        //    // processing the stream.

        //    var result = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ByteArrayContent(stream.ToArray())
        //    };
        //    result.Content.Headers.ContentDisposition =
        //        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //        {
        //            FileName = "CV.pdf"
        //        };
        //    result.Content.Headers.ContentType =
        //        new MediaTypeHeaderValue("application/octet-stream");

        //    return result;
        //}

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
