using System.Collections.Generic;

namespace SmartBankCore.domain.persistence
{
    public class BankUser
    {
        public BankUser()
        {
            BANK_ACCOUNTS = new HashSet<BankAccount>();
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Pin { get; set; }
        public ICollection<BankAccount> BANK_ACCOUNTS { get; set; }
    }
}
