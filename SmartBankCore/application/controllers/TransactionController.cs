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
        private readonly TransactionRepository _transactionRepository;
        private readonly ILogger LOG = Log.ForContext<TransactionController>();

        public TransactionController(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        [Route("forAccount/{accountNumber}")]
        public List<Transaction> GetRelatedTransactions(int accountNumber)
        {
            LOG.Information("Getting transactions for accout number: {0}", accountNumber);
            return _transactionRepository.FindTransactionsForAccountNumber(accountNumber).ToList();
        }
    }
}