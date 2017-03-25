using System;

namespace SmartBankCore.domain
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual BankUser BankUser { get; set; }
        public bool IsLocked { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(AccountNumber)}: {AccountNumber}, {nameof(Owner)}: {Owner}, {nameof(Balance)}: {Balance}, {nameof(CreatedDate)}: {CreatedDate}, {nameof(BankUser)}: {BankUser}, {nameof(IsLocked)}: {IsLocked}";
        }
    }
}