using System.Collections.Generic;

namespace SmartBankDesktop.Model
{
    public class BankUser
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Pin { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; } =
            new HashSet<BankAccount>();

        public override string ToString()
        {
            return
                $"{nameof(Username)}: {Username}, {nameof(Name)}: {Name}, {nameof(Password)}: {Password}, {nameof(Pin)}: {Pin}, {nameof(Salt)}: {Salt}, {nameof(BankAccounts)}: {BankAccounts}";
        }
    }
}