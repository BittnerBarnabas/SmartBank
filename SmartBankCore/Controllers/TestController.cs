using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SmartBankCore.adapters.persistence;
using SmartBankCore.domain.persistence;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.Controllers
{
    public class TestController : ApiController
    {
        private DbContext _dbContext = new SmartBankDataModel();
        private readonly BankUserRepository _repository;

        public TestController()
        {
            _repository = new BankUserRepository(_dbContext);
        }
        public IHttpActionResult GetBankUsersById(String id)
        {
            var bankuser = new BankUser()
            {
                Name = "John",
                Password = "secret",
                Pin = 3342,
                Username = "johnn123",
                UserId = "ABC123",
            };
            var tmp = new List<BankAccount>
            {
                new BankAccount()
                {
                    ACCOUNT_NUMBER = 33,
                    BALANCE = 500,
                    CREATED_DATE = DateTime.Now.Date,
                    BankUser = bankuser,
                    OWNER = bankuser.Username
                }
            };
            bankuser.BANK_ACCOUNTS = tmp;
            _repository.Save(bankuser);
            _dbContext.SaveChanges();
            return Ok(_repository.FindById(id));
        }
    }
}
