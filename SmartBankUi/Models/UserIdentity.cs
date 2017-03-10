using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartBankUi.Models
{
    public class UserIdentity : IdentityUser
    {
        private UserIdentity() { }
        public string username { get; set; }
        public string name { get; set; }

        public static UserIdentity FromBankUser(BankUser user)
        {
            return new UserIdentity {name = user.Name, username = user.Username};
        }
    }
}