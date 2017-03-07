using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class LogInController : Controller
    {
        private ILogger LOG = Log.ForContext<LogInController>();

        // GET: LogIn
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

                if (CryptographyUtils.HaveTheSamePassword(user, receivedUser))
                {
                    LOG.Information("User is successfully logged in: {user}", receivedUser.Username);
                }
                else
                {
                    LOG.Warning("Access denied for user: {user}", user.Username);
                }
            }   
            return RedirectToAction("Index","Home");
        }


    }
}