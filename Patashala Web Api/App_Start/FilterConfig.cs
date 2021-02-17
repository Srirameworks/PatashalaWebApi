using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Patashala_Web_Api.Config;
using System.Web;
using System.Web.Mvc;

namespace Patashala_Web_Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}
