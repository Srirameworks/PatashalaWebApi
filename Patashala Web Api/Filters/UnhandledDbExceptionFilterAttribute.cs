using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Patashala_Web_Api.Filters
{
    public class UnhandledDbExceptionFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is DbUpdateConcurrencyException|| 
                context.Exception is DbUpdateException ||
                context.Exception is DbEntityValidationException||
                context.Exception is SqlException
                )
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            else
            {
                return;
            } 
        }
    }
}