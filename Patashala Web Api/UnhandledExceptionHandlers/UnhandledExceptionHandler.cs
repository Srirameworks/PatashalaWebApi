using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Patashala_Web_Api.UnhandledHttpActionResults;

namespace Patashala_Web_Api.ExceptionHandlers
{
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
#if DEBUG
            var content = JsonConvert.SerializeObject(context.Exception);
#else
            var content = @"{""message"":""Oops, Something unexpected went wrong""}";
#endif
            context.Result = new ErrorContentResult(content, "application/json", context.Request);

        }
    }
}