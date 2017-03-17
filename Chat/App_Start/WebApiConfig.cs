using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Chat
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /*
            config.Routes.MapHttpRoute(
                name: "Post",
                routeTemplate: "api/{controller}/{id}/{user}/{pass}/{message}",
                defaults: new { id = RouteParameter.Optional, user = RouteParameter.Optional, pass = RouteParameter.Optional, message = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );
            */

        }
    }
}
