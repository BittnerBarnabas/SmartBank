using System;

namespace SmartBankUi.Models
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 20);
        public TransactionType Type { get; set; }
        public int SourceAccountNumber { get; set; }
        public int RecipientAccountNumber { get; set; }
        public string RecipientUserName { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int Amount { get; set; }
    }
}