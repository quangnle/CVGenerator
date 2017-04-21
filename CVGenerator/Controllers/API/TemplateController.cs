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
    public class TemplateController : BaseApiController
    {        
        [HttpGet]
        public List<TTemplate> GetAll()
        {
            using (var db = new GvGenEntities())
            {
                var lst = db.TTemplates.ToList();
                return lst;
            }
        }
    }
}
