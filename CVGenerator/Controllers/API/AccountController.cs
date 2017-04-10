using CVGenerator.Entities;
using CVGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace CVGenerator.Controllers.API
{
    public class AccountController : BaseApiController
    {
        public bool RegisterUser (Login model)
        {
            using (var context = new GvGenEntities())
            {
                var mailExists = context.TUsers.First(m => m.Email == model.Email);
                if (mailExists == null)
                {
                    var entity = new TUser();
                    entity.Name = model.Email;
                    entity.Email = model.Email;
                    entity.Password = model.Password;
                    entity.Role = (int)AuthRole.User;
                    context.TUsers.Add(entity);

                    return true;
                }

                return false;
            }
        }

        public bool Validate(Login model)
        {
            using (var context = new Entities.GvGenEntities())
            {
                var entities = context.TUsers.Where(m => m.Name == model.Email && m.Password == model.Password).ToList();
                if (entities.Count == 1)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return true;
                }

                return false;
            }
        }
    }
}
