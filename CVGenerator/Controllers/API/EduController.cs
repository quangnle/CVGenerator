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
    public class EduController : BaseApiController
    {
        protected override IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {
            var existedEdu = lst.Where(s => (s as Education).Id > 0);
            return existedEdu;
        }

        protected override IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            var newEdu = lst.Where(s => (s as Education).Id <= 0);
            return newEdu;
        }

        [HttpPost]
        public HttpResponseMessage SubmitEdus(int profileId, [FromBody]List<Education> edus)
        {
            if (edus == null || edus.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var success = UpdateConvertibleModelList<Education, TEducation>(profileId, edus);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public List<TEducation> GetEdus(int idProfile)
        {
            using (var db = new GvGenEntities())
            {
                var lst = db.TEducations.Where(e => e.IdProfile == idProfile).ToList();
                return lst;
            }
        }

        protected override IQueryable<IEntity> GetListDb(int parentId, DbSet dbSet)
        {
            return dbSet.Cast<TEducation>().Where(e => e.IdProfile == parentId);
        }
    }
}
