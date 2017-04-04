using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace CVGenerator.Utilities
{
    public class HandleApiExceptionAttribute : ExceptionFilterAttribute
    {
        ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(HttpActionExecutedContext context)
        {
            logger.Error("ERROR", context.Exception);

            var httpEx = context.Exception as HttpResponseException;

            if (httpEx != null)
            {
                throw httpEx;
            }
            else
            {
                var request = context.ActionContext.Request;
                var response = new
                {
                    Message = context.Exception.Message
                };

                context.Response = request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }
    }
}