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
    public class WorkExpController : BaseApiController
    {
        protected override IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {
            var existedWorkExp = lst.Where(s => (s as WorkExperience).Id > 0);
            return existedWorkExp;
        }

        protected override IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            var newWorkExp = lst.Where(s => (s as WorkExperience).Id <= 0);
            return newWorkExp;
        }

        [HttpPost]
        public HttpResponseMessage SubmitWorkExps(int profileId, [FromBody]List<WorkExperience> workExps)
        {
            if (workExps == null || workExps.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var success = UpdateConvertibleModelList<WorkExperience, TWorkExperience>(profileId, workExps);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpGet]
        public List<TWorkExperience> GetWorkExps(int idProfile)
        {
            using (var db = new GvGenEntities())
            {
                var lst = db.TWorkExperiences.Where(e => e.IdProfile == idProfile).ToList();
                return lst;
            }
        }

        protected override IQueryable<IEntity> GetListDb(int parentId, DbSet dbSet)
        {
            return dbSet.Cast<TWorkExperience>().Where(e => e.IdProfile == parentId);
        }
    }
}
