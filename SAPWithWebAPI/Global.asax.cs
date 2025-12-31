using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAPWithWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            ViewEngines.Engines.Clear();    //Removing all Engines
            ViewEngines.Engines.Add(new RazorViewEngine()); // Only adding RazorView
        }
    }
}
