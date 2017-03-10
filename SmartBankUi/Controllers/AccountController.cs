using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;
using SmartBankUi.Services;

namespace SmartBankUi.Controllers
{
    public class AccountController : Controller
    {
        private ILogger LOG = Log.ForContext<AccountController>();

        private IAccountControllerService<UserIdentity> _accountControllerService;
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
        public async Task<ActionResult> Index(BankUser user)
        {
            LOG.Debug("Received user login from : {user}", user);

            using (var client = new HttpClient())
            {
                var hostname = "http://localhost:49848";
                var addUserPath = "/api/users/getuser/" + user.Username;
                client.BaseAddress = new Uri(hostname);
                var result = client.GetAsync(hostname + addUserPath).Result;

                if (!result.IsSuccessStatusCode) return RedirectToAction("Index", "Home");

                var receivedUser = await result.Content.ReadAsAsync<BankUser>();
                LOG.Debug("Received user : {0}", receivedUser);

                Login(user, receivedUser);
            }   
            return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            _accountControllerService.SingOut(System.Web.HttpContext.Current);
            return RedirectToAction("Index","Home");
        }

        private void Login(BankUser user, BankUser receivedUser)
        {
            if (CryptographyUtils.HaveTheSamePassword(user, receivedUser))
            {
                _accountControllerService.SignInDefault(UserIdentity.FromBankUser(receivedUser),
                    System.Web.HttpContext.Current);
            }
            else
            {
                LOG.Warning("Access denied for user: {user}", user.Username);
                ModelState.AddModelError("invalidCredentials", "Username or password is incorrect");
            }
        }

    }
}