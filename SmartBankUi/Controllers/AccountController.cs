using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;
using SmartBankUi.Services;

namespace SmartBankUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountControllerService<UserIdentity> _accountControllerService;
        private readonly ILogger LOG = Log.ForContext<AccountController>();

        public AccountController(
            IAccountControllerService<UserIdentity> accountControllerService)
        {
            _accountControllerService = accountControllerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("LogInPage");
        }

        [HttpPost]
        public ActionResult Index(BankUser user)
        {
            LOG.Debug("Received user login from : {user}", user);

            // the received user is incomplete so we need to ignore this property
            // when validating
            ModelState.Remove("Name");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please fill all the fields.");
                return View();
            }

            var result = WebApiUtils.GetFromUrl(WebApiUtils.HostName,
                WebApiUtils.GetUserPath + user.Username);

            if (!result.IsSuccessStatusCode ||
                !Login(user, result.Content.ReadAsAsync<BankUser>().Result))
            {
                LOG.Warning("Access denied for user: {user}", user.Username);
                ModelState.AddModelError(string.Empty, "Login details are incorrect.");
                return View();
            }

            LOG.Debug("Logged in user : {0}", user.Username);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            _accountControllerService.SingOut(System.Web.HttpContext.Current);
            return RedirectToAction("Index", "Home");
        }

        private bool Login(BankUser user, BankUser receivedUser)
        {
            if (!CryptographyUtils.HaveTheSamePassword(user, receivedUser) ||
                !MatchesAccountNumber(user.LoginBankAccountNumer,
                    receivedUser.BankAccounts) ||
                !user.Pin.Equals(receivedUser.Pin)) return false;

            _accountControllerService.SignInDefault(
                UserIdentity.FromBankUser(receivedUser),
                System.Web.HttpContext.Current);

            return true;
        }

        private static bool MatchesAccountNumber(int accountNumber,
            IEnumerable<BankAccount> bankAccounts)
            =>
                bankAccounts.Any(
                    bankAccount => bankAccount.AccountNumber.Equals(accountNumber));
    }
}