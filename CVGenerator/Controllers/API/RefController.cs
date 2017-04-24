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
    public class RefController : BaseApiController
    {
        protected override IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {
            var existedEdu = lst.Where(s => (s as Reference).Id > 0);
            return existedEdu;
        }

        protected override IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            var newEdu = lst.Where(s => (s as Reference).Id <= 0);
            return newEdu;
        }

        [HttpPost]
        public HttpResponseMessage SubmitRefs(int profileId, [FromBody]List<Reference> refs)
        {
            if (refs == null || refs.Count == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var success = UpdateConvertibleModelList<Reference, TReference>(profileId, refs);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public List<TReference> GetRefs(int idProfile)
        {
            using (var db = new GvGenEntities())
            {
                var lst = db.TReferences.Where(e => e.IdProfile == idProfile).ToList();
                return lst;
            }
        }

        protected override IQueryable<IEntity> GetListDb(int parentId, DbSet dbSet)
        {
            return dbSet.Cast<TReference>().Where(e => e.IdProfile == parentId);
        }
    }
}
