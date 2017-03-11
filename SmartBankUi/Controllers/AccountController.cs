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

        public AccountController(IAccountControllerService<UserIdentity> accountControllerService)
        {
            _accountControllerService = accountControllerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BankUser user)
        {
            LOG.Debug("Received user login from : {user}", user);
            var result = WebApiUtils.GetFromUrl(WebApiUtils.HostName, WebApiUtils.GetUserPath + user.Username);

            if (!result.IsSuccessStatusCode || !Login(user, result.Content.ReadAsAsync<BankUser>().Result))
            {
                LOG.Warning("Access denied for user: {user}", user.Username);
                ModelState.AddModelError(string.Empty, "Username or password is incorrect.");
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
            if (CryptographyUtils.HaveTheSamePassword(user, receivedUser))
            {
                _accountControllerService.SignInDefault(UserIdentity.FromBankUser(receivedUser),
                    System.Web.HttpContext.Current);
                return true;
            }
            return false;
        }
    }
}