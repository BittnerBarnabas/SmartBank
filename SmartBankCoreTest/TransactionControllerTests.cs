using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartBankCore.application.controllers;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCoreTest
{
    [TestClass]
    public class TransactionControllerTests
    {
        private TransactionController _transactionController;
        private int TestAccountNumber = 123;

        [TestInitialize]
        public void SetUp()
        {
            var mockTransactionRepository =
                new Mock<ITransactionRepository<Transaction, string>>();

            //mockTransactionRepository.Setup(o => o.FindTransactionsForAccountNumber(TestAccountNumber)).Returns()

            var mockBankAccountRepository = new Mock<IRepository<BankAccount, int>>();
            _transactionController =
                new TransactionController(mockTransactionRepository.Object,
                    mockBankAccountRepository.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}