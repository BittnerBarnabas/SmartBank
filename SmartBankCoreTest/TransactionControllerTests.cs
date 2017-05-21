using System.Web.Http.Results;
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
        private readonly int TestAccountNumber = 123;
        private readonly int TestLockedAccountNUmber = 1234;
        private TransactionController _transactionController;

        [TestInitialize]
        public void SetUp()
        {
            var mockTransactionRepository =
                new Mock<ITransactionRepository<Transaction, string>>();
            var mockBankAccountRepository = new Mock<IRepository<BankAccount, int>>();

            mockBankAccountRepository.Setup(o => o.FindById(TestAccountNumber))
                .Returns(new BankAccount { Balance = 500, IsLocked = false });

            mockBankAccountRepository.Setup(o => o.FindById(TestLockedAccountNUmber))
                .Returns(new BankAccount { Balance = 500, IsLocked = true });

            _transactionController =
                new TransactionController(mockTransactionRepository.Object,
                    mockBankAccountRepository.Object);
        }

        [TestMethod]
        public void TestExeuteLockedTransaction()
        {
            var result = _transactionController.ExecuteTransaction(new Transaction
            {
                SourceAccountNumber = TestLockedAccountNUmber,
                Amount = 200
            });
            Assert.AreEqual(result.GetType(), typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void TestExeuteTransaction()
        {
            var result = _transactionController.ExecuteTransaction(new Transaction
            {
                SourceAccountNumber = TestAccountNumber,
                Amount = 200
            });
            Assert.AreEqual(result.GetType(), typeof(OkResult));
        }
    }
}