using System;

namespace SmartBankUi.Models
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual BankUser BankUser { get; set; }

        public bool IsLocked { get; set; }
    }
}