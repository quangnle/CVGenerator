using CVGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CVGenerator.Controllers.API
{
    [HandleApiException]
    public abstract class BaseApiController : ApiController
    {
    }
}
