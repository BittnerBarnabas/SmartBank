using System.Collections.Generic;

namespace SmartBankCore.domain.persistence
{
    public class BankUser
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Pin { get; set; }
        public string Salt { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; } = new HashSet<BankAccount>();
    }
}