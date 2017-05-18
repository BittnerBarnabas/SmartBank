using System.Data.Entity;
using System.Web;
using System.Web.Http;
using Serilog;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SmartBankCore.adapters.persistence;
using SmartBankCore.application.startup;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IRepository<BankEmployee, string>, BankEmployeeRepository>();
            container.Register<IRepository<BankUser, string>, BankUserRepository>();
            container.Register<IRepository<BankAccount, int>, BankAccountRepository>();
            container
                .Register
                <ITransactionRepository<Transaction, string>, TransactionRepository>();
            container.Register<DbContext, SmartBankDataModel>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}