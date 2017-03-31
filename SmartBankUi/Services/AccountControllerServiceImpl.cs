using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Serilog;
using SmartBankUi.Models;

namespace SmartBankUi.Services
{
    public class AccountControllerServiceImpl : IAccountControllerService<UserIdentity>
    {
        private readonly ILogger LOG = Log.ForContext<AccountControllerServiceImpl>();

        public bool SignIn(UserIdentity userIdentity,
            Func<UserIdentity, ICollection<Claim>> claimsProvider,
            HttpContext httpContext)
        {
            try
            {
                var identity = new ClaimsIdentity(claimsProvider.Invoke(userIdentity),
                    DefaultAuthenticationTypes.ApplicationCookie);

                httpContext.GetOwinContext()
                    .Authentication.SignIn(new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddSeconds(5)
                    }, identity);

                LOG.Information("User successfully logged in: {0}, {1}",
                    httpContext.User.Identity.Name,
                    httpContext.User.Identity.IsAuthenticated);
                return true;
            }
            catch (Exception exc)
            {
                LOG.Error("Login failed with exception: {0}", exc);
                return false;
            }
        }

        public bool SignInDefault(UserIdentity userIdentity, HttpContext httpContext)
        {
            return SignIn(userIdentity, DefaultClaims, httpContext);
        }

        public bool SingOut(HttpContext httpContext)
        {
            LOG.Debug("User: {0} is logged out.", httpContext.User.Identity.Name);
            httpContext.GetOwinContext()
                .Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return true;
        }

        private List<Claim> DefaultClaims(UserIdentity userIdentity)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, userIdentity.Name),
                new Claim(ClaimTypes.NameIdentifier, userIdentity.UserName),
                new Claim("SecureMode", userIdentity.SecureMode.ToString())
            };
        }
    }
}