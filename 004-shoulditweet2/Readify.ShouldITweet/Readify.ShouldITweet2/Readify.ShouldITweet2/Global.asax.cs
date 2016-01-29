using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Serilog;
using System.IO;

namespace Readify.ShouldITweet2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.File((Path.Combine
                        (AppDomain.CurrentDomain.BaseDirectory, $"log-{DateTime.Today.ToString("dd-MM-yyyy")}.txt")))
                        .WriteTo.Seq("http://localhost:5341")
                        .CreateLogger();
        }
    }
}
