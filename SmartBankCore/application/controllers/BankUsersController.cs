using System;
using System.Collections.Generic;
using System.Web.Http;
using Serilog;
using SmartBankCore.domain.persistence;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.application.controllers
{
    [RoutePrefix("api/users")]
    public class BankUsersController : ApiController
    {
        private readonly BankUserRepository _repository;
        private readonly ILogger LOG = Log.ForContext<BankUsersController>();

        public BankUsersController(BankUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("getuser/{id}")]
        public IHttpActionResult GetBankUsersById(string id)
        {
            LOG.Debug("Request received with Id: {id}", id);
            var result = _repository.FindById(id);
            if (result == null)
            {
                LOG.Warning("Didn't find user with id: {id}", id);
                return NotFound();
            }
            LOG.Debug("Found user with id: {0}", id);
            return Ok(result);
        }

        [HttpPost]
        [Route("adduser")]
        public IHttpActionResult PutBankUser(BankUser user)
        {
            var acc = new BankAccount {AccountNumber = 1234, Balance = 500, CreatedDate = DateTime.Now};
            var test = new BankUser
            {
                Username = "cica",
                Name = "C",
                Password = "abc",
                Pin = 123,
                Salt = "as",
                BankAccounts = new List<BankAccount> {acc}
            };
            _repository.Save(test);
            _repository.Commit();
            /*
            _repository.Save(user);
            try
            {
                _repository.Commit();
            }
            catch (DbEntityValidationException e)
            {
                LOG.Error("Entity validation failed: {0}", e);
                return BadRequest();
            }*/
            return Ok("Saved and commited user!");
        }
    }
}