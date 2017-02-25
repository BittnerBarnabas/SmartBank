using System;
using System.Web.Http;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.Controllers
{
    public class TestController : ApiController
    {
        private readonly BankUserRepository _repository;

        public TestController(BankUserRepository repository)
        {
            _repository = repository;
        }
        public IHttpActionResult GetBankUsersById(String id)
        {
            return Ok(_repository.FindById(id));
        }
    }
}
