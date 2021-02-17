using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Patashala_Web_Api.Loggers
{
    public class UnhandledExceptionLogger: ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.Message;
            Debug.WriteLine($"EXCEPTION LOGGED: {log}");
        }
    }
}