using System.Web.Http;
using Serilog;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.application.controllers
{
    [RoutePrefix("api/employees")]
    public class BankEmployeeController : ApiController
    {
        private readonly IRepository<BankEmployee, string> _repository;
        private readonly ILogger LOG = Log.ForContext<BankEmployeeController>();

        public BankEmployeeController(IRepository<BankEmployee, string> repository)
        {
            LOG.Debug(nameof(BankEmployeeController) + " is initialized.");
            _repository = repository;
        }

        [HttpGet]
        [Route("get/{name}")]
        public IHttpActionResult GetEmployeeByName(string name)
        {
            LOG.Debug("Request received with name: {name}", name);
            var result = _repository.FindById(name);
            if (result == null)
            {
                LOG.Information("Employee with id {name} not found", name);
                return NotFound();
            }
            LOG.Information("Employee found with id {name}", name);
            return Ok(result);
        }
    }
}