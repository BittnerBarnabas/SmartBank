using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Serilog;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SmartBankUi.Models;
using SmartBankUi.Services;

namespace SmartBankUi
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            var LOG = Log.ForContext<MvcApplication>();

            LOG.Information("Logger is initialized");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            LOG.Information("Registered routing config");

            LOG.Information("Registering IoC container");
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            LOG.Information("Registering dependencies");
            container
                .Register
                <IAccountControllerService<UserIdentity>, AccountControllerServiceImpl>(
                    Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            LOG.Information("IoC container successfully initialized");
        }
    }
}