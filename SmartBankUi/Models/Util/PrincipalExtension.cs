using System.Security.Claims;
using System.Security.Principal;

namespace SmartBankUi.Models.Util
{
    public static class PrincipalExtension
    {
        public static bool IsSecureMode(this IPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity;
            return bool.Parse(identity.FindFirst("SecureMode").Value);
        }
    }
}