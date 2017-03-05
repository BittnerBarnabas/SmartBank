using System;
using System.Data.Entity.Validation;
using System.Web.Http;
using Serilog;
using SmartBankCore.domain.persistence;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.application.controllers
{
    [RoutePrefix("api/users")]
    public class BankUsersController : ApiController
    {
        private ILogger LOG = Log.ForContext<BankUsersController>();
        private readonly BankUserRepository _repository;

        public BankUsersController(BankUserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Route("getuser/{id}")]
        public IHttpActionResult GetBankUsersById(string id)
        {
            return Ok(_repository.FindById(id));
        }

        [HttpPost]
        [Route("adduser")]
        public IHttpActionResult PutBankUser(BankUser user)
        {
            _repository.Save(user);
            try
            {
                _repository.Commit();
            }
            catch (DbEntityValidationException e)
            {
                LOG.Error("Entity validation failed: {0}", e);
                return BadRequest();
            }
            return Ok("Saved and commited user!");
        }
    }
}
