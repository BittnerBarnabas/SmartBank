using System.Data.Entity.Validation;
using System.Web.Http;
using Serilog;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.application.controllers
{
    [RoutePrefix("api/users")]
    public class BankUsersController : ApiController
    {
        private readonly IRepository<BankUser, string> _repository;
        private readonly ILogger LOG = Log.ForContext<BankUsersController>();

        public BankUsersController(IRepository<BankUser, string> repository)
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

        [HttpGet]
        [Route("getAllUser")]
        public IHttpActionResult GetAllBankUsers()
        {
            LOG.Debug("Getting all bank users");
            return Ok(_repository.FindAll());
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