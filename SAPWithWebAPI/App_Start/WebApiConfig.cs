using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SAPWithWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Enabling CORS at controller level
            //config.EnableCors();

            //Enabling CORS at Application Level
            EnableCorsAttribute obj = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(obj);
        }
    }
}
