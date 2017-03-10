using System;

namespace SmartBankCore.domain.persistence
{
    public class BankAccount
    {
        public int ACCOUNT_NUMBER { get; set; }
        public string OWNER { get; set; }
        public int BALANCE { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public virtual BankUser BankUser { get; set; }
    }
}