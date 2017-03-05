using System;
using System.Data.Entity;
using System.Web.Http;
using Serilog;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SmartBankCore.adapters.persistence;
using SmartBankCore.application.startup;
using SmartBankCore.domain.persistence;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IRepository<BankUser, String>, BankUserRepository>();
            container.Register<IRepository<BankAccount, String>, BankAccountRepository>();
            container.Register<DbContext, SmartBankDataModel>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
