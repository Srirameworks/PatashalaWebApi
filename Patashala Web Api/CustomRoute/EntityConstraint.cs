using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;


namespace Patashala_Web_Api.CustomRoute
{
    public class EntityConstraint: IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            foreach( var val in values)
            {
                if (val.Value.ToString().Contains("Address"))
                {
                    return true;
                }
            }
            
            return false;
        }

    }

}