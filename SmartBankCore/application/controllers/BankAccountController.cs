using System.Web.Http;
using Serilog;
using SmartBankCore.domain;
using SmartBankCore.domain.persistence.repository;

namespace SmartBankCore.application.controllers
{
    [RoutePrefix("api/bankAccount")]
    public class BankAccountController : ApiController
    {
        private readonly IRepository<BankAccount, int> _bankAccountRepository;
        private readonly ILogger LOG = Log.ForContext<BankAccountController>();

        public BankAccountController(IRepository<BankAccount, int> bankAccountRepository)
        {
            LOG.Debug(nameof(BankAccountController) + " is initialized.");
            _bankAccountRepository = bankAccountRepository;
        }

        [HttpPost]
        [Route("toggleLock")]
        public IHttpActionResult ToggleLock(int id)
        {
            LOG.Information("Toggling lock status for accout {id}", id);
            var account = _bankAccountRepository.FindById(id);
            account.IsLocked = !account.IsLocked;
            _bankAccountRepository.Save(account);
            _bankAccountRepository.Commit();
            return Ok();
        }
    }
}