using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartBankCore.application.controllers;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCoreTest
{
    [TestClass]
    public class BankEmployeeControllerTests
    {
        private readonly string TestEmployeeName = "Test name";
        private BankEmployeeController _bankEmployeeController;
        private readonly string TestNonExistentEmployeeName = "Non existent";

        [TestInitialize]
        public void SetUp()
        {
            var mockBankEmployeeRepository = new Mock<IRepository<BankEmployee, string>>();
            mockBankEmployeeRepository.Setup(o => o.FindById(TestEmployeeName))
                .Returns(new BankEmployee {UserName = TestEmployeeName, Password = "Mock"});

            _bankEmployeeController =
                new BankEmployeeController(mockBankEmployeeRepository.Object);
        }

        [TestMethod]
        public void TestGetEmployeeByName()
        {
            var result = _bankEmployeeController.GetEmployeeByName(TestEmployeeName);
            Assert.AreEqual(result.GetType(),
                typeof(OkNegotiatedContentResult<BankEmployee>));
        }

        [TestMethod]
        public void TestNotFoundGetEmployeeByName()
        {
            var result =
                _bankEmployeeController.GetEmployeeByName(TestNonExistentEmployeeName);
            Assert.AreEqual(result.GetType(), typeof(NotFoundResult));
        }
    }
}