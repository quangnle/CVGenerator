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
    public class WorkExpController : BaseApiController
    {
        public override IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {
            var existedWorkExp = lst.Where(s => (s as WorkExperience).IdProfile > 0);
            return existedWorkExp;
        }

        public override IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            var newWorkExp = lst.Where(s => (s as WorkExperience).IdProfile == -1);
            return newWorkExp;
        }

        [HttpPost]
        public HttpResponseMessage SubmitWorkExps([FromBody]List<WorkExperience> workExps)
        {
            if (workExps == null || workExps.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var success = UpdateConvertibleModelList<WorkExperience, TWorkExperience>(workExps);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
