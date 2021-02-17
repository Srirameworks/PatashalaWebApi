
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Newtonsoft.Json;
using Patashala_Web_Api.Config;
using Patashala_Web_Api.CustomRoute;
using Patashala_Web_Api.ExceptionHandlers;
using Patashala_Web_Api.Filters;
using Patashala_Web_Api.Loggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;

namespace Patashala_Web_Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MessageHandlers.Add(new TokenValidationHandler());

            var Entity = new DefaultInlineConstraintResolver();
            Entity.ConstraintMap.Add("EntityConstraint", typeof(EntityConstraint));
            config.MapHttpAttributeRoutes(Entity);

            


            // Web API configuration and services

            // Web API routes

            //config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            config.Services.Replace(typeof(IExceptionHandler), new UnhandledExceptionHandler());

            config.EnableCors();

            config.Filters.Add(new UnhandledDbExceptionFilterAttribute());

            var json = config.Formatters.JsonFormatter.SerializerSettings;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
