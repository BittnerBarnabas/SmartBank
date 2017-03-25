using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Serilog;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.application.controllers
{
    [RoutePrefix("api/transaction")]
    public class TransactionController : ApiController
    {
        private readonly BankAccountRepository _bankAccountRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly ILogger LOG = Log.ForContext<TransactionController>();

        public TransactionController(TransactionRepository transactionRepository,
            BankAccountRepository bankAccountRepository)
        {
            _transactionRepository = transactionRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        [HttpGet]
        [Route("forAccount/{accountNumber}")]
        public List<Transaction> GetRelatedTransactions(int accountNumber)
        {
            LOG.Information("Getting transactions for accout number: {0}", accountNumber);
            return
                _transactionRepository.FindTransactionsForAccountNumber(accountNumber)
                    .ToList();
        }

        [HttpPost]
        [Route("putTransaction")]
        public void ExecuteTranasction(Transaction pendingTransaction)
        {
            LOG.Information("Starting to execute tranasction: {0}", pendingTransaction);

            var sourceBankAccount =
                _bankAccountRepository.FindById(
                    pendingTransaction.SourceAccountNumber);

            if (sourceBankAccount != null)
            {
                LOG.Information("The source account is an internal account");
                //TODO check if the user has the available balance
                sourceBankAccount.Balance -= pendingTransaction.Amount;
                _bankAccountRepository.Save(sourceBankAccount);
            }

            var recipientBankAccount =
                _bankAccountRepository.FindById(
                    pendingTransaction.RecipientAccountNumber);

            if (recipientBankAccount != null)
            {
                LOG.Information("The recipient account is an internal account");
                recipientBankAccount.Balance += pendingTransaction.Amount;
                _bankAccountRepository.Save(recipientBankAccount);
            }

            _transactionRepository.Save(pendingTransaction);
            _transactionRepository.Commit();
            _bankAccountRepository.Commit();
        }
    }
}