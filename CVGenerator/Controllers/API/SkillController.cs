using CVGenerator.Entities;
using CVGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CVGenerator.Controllers.API
{
    public class SkillController : BaseApiController
    {
        protected override IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {
            var existedSkills = lst.Where(s => (s as Skill).Id > 0);
            return existedSkills;
        }

        protected override IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            var newSkills = lst.Where(s => (s as Skill).Id <= 0);
            return newSkills;
        }

        [HttpPost]
        public HttpResponseMessage SubmitSkills(int profileId, [FromBody]List<Skill> skills)
        {
            if (skills == null || skills.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var success = UpdateConvertibleModelList<Skill, TSkill>(profileId, skills);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
