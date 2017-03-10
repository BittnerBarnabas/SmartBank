using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace SmartBankUi.Services
{
    public interface IAccountControllerService<T> where T : IdentityUser
    {
        bool SignIn(T userIdentity, Func<T, ICollection<Claim>> claimsProvider, HttpContext httpContext);
        bool SignInDefault(T userIdentity, HttpContext httpContext);
        bool SingOut(HttpContext httpContext);
    }
}
