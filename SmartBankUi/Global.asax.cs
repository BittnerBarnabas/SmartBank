using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Serilog;

namespace SmartBankUi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            Log.Information("Logger is initialized");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
