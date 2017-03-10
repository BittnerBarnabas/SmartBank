using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartBankUi.Models
{
    public class UserIdentity : IdentityUser
    {
        private UserIdentity()
        {
        }

        public string UserName { get; set; }
        public string Name { get; set; }

        public static UserIdentity FromBankUser(BankUser user)
        {
            return new UserIdentity { Name = user.Name, UserName = user.Username };
        }
    }
}