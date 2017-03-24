using System;

namespace SmartBankCore.domain
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 20);
        public int SourceAccountNumber { get; set; }
        public int RecipientAccountNumber { get; set; }
        public string RecipientUserName { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int Amount { get; set; }
    }
}