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
    }
}
