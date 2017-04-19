using CVGenerator.Entities;
using CVGenerator.Models;
using CVGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CVGenerator.Controllers.API
{
    [HandleApiException]
    public abstract class BaseApiController : ApiController
    {
        protected virtual IEnumerable<T> GetNewItems<T>(List<T> lst)
        {
            return lst;
        }

        protected virtual IEnumerable<T> GetExistedItems<T>(List<T> lst)
        {
            return lst;
        }

        protected bool UpdateConvertibleModelList<T, K>(List<T> lst) where T : IConvertibleModel<K> where K : IEntity
        {
            var newItems = GetNewItems(lst);
            var existedItems = GetExistedItems(lst);

            using (var context = new GvGenEntities())
            {
                var set = context.Set(typeof(K));
                // create new skills
                if (newItems != null)
                {
                    foreach (var item in newItems)
                    {
                        set.Add(item.GetEntity());
                    }
                }

                // update existing skills
                if (existedItems != null && existedItems.Any())
                {
                    var currentItems = set.ToListAsync().Result;
                    foreach (var item in existedItems)
                    {
                        var entity = currentItems.FirstOrDefault(s => (s as IEntity).Id == item.Id);
                        if (entity == null)
                            return false;

                        item.Update((K)entity);
                        set.Attach(entity);
                        DbEntityEntry entry = context.Entry(entity);
                        entry.State = EntityState.Modified;
                    }

                    foreach (var entity in currentItems.ToList())
                    {
                        var foundSkill = existedItems.FirstOrDefault(s => s.Id == (entity as IEntity).Id);
                        if (foundSkill == null)
                        {
                            set.Attach(entity);
                            DbEntityEntry entry = context.Entry(entity);
                            entry.State = EntityState.Deleted;
                        }
                    }
                }

                context.SaveChanges();

                return true;
            }
        }
    }
}
