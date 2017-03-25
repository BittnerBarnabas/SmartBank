using System.Security.Claims;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Serilog;
using SmartBankUi;

[assembly: OwinStartup(typeof(Startup))]

namespace SmartBankUi
{
    public class Startup
    {
        private readonly ILogger LOG = Log.ForContext<Startup>();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            LOG.Information("Authentication settings configured");
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}