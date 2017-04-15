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
    public class SkillController : BaseApiController
    {
        protected override IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {   
            var existedSkills = lst.Where(s => (s as Skill).IdProfile > 0);
            return existedSkills;
        }

        protected override IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            var newSkills = lst.Where(s => (s as Skill).IdProfile == -1);
            return newSkills;
        }

        [HttpPost]
        public HttpResponseMessage SubmitSkills([FromBody]List<Skill> skills)
        {
            if (skills == null || skills.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var success = UpdateConvertibleModelList<Skill, TSkill>(skills);

            return new HttpResponseMessage(HttpStatusCode.OK);
            
        }
    }
}
