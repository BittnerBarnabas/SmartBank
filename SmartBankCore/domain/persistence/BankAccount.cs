using System;

namespace SmartBankCore.domain.persistence
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual BankUser BankUser { get; set; }
    }
}