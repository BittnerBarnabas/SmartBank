using System;
using System.Data.Entity;
using System.Web.Http;
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
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IRepository<BankUser, String>, BankUserRepository>();
            container.Register<DbContext, SmartBankDataModel>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
