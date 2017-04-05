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
                db.TProfiles.Add(new Entities.TProfile
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Age=20,
                    YearOfExp=4,
                    Gender="Male",
                    Degree="Collage",
                    Occupation="Test",
                    Address=profile.Address,
                    Nationality=profile.Nationality,
                    PhoneNo=profile.PhoneNumber,
                    Email=profile.Email,
                    Website="http:",
                    AboutMe="About me"
                });
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
