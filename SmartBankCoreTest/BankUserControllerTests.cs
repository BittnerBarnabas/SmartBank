using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartBankCore.application.controllers;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCoreTest
{
    [TestClass]
    public class BankUserControllerTests
    {
        private readonly BankUser testBankUser = new BankUser();
        private readonly string testNonExistentUserId = "non_existent_user";
        private readonly string testUserId = "test_id";
        private readonly string testUserName = "test_user";
        private BankUsersController _bankUsersController;

        [TestInitialize]
        public void SetUp()
        {
            var mockRepository = new Mock<IRepository<BankUser, string>>();
            mockRepository.Setup(o => o.FindById(testUserId))
                .Returns(new BankUser { Username = testUserName });
            _bankUsersController = new BankUsersController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void TestGetBankUsersById()
        {
            var response = _bankUsersController.GetBankUsersById(testUserId);
            BankUser user;
            Assert.IsTrue(
                response.ExecuteAsync(CancellationToken.None)
                    .Result.TryGetContentValue(out user));
            Assert.AreEqual(user.Username, testUserName);
        }

        [TestMethod]
        public void TestGetBankUsersByIdNoUser()
        {
            var response = _bankUsersController.GetBankUsersById(testNonExistentUserId);
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestPutBankUser()
        {
            var response = _bankUsersController.PutBankUser(testBankUser);
            Assert.AreEqual(response.GetType(), typeof(OkNegotiatedContentResult<string>));
        }
    }
}