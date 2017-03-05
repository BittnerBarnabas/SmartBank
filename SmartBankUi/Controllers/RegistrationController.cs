using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class RegistrationController : Controller
    {
        private ILogger LOG = Log.ForContext<RegistrationController>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BankUser user)
        {
            var passwordAndSalt = CryptographyUtils.GenerateHashAndSalt(user.Password);
            user.Password = passwordAndSalt.Item1;
            user.Salt = passwordAndSalt.Item2;

            using (var client = new HttpClient())
            {
                var hostname = "http://localhost:49848";
                var addUserPath = "/api/users/adduser";
                client.BaseAddress = new Uri(hostname);
                LOG.Debug("Posting user data to: {0}", hostname + addUserPath);
                var result = client.PostAsync(addUserPath, user, new JsonMediaTypeFormatter()).Result;
                if (result.IsSuccessStatusCode)
                {
                    LOG.Information("Bank user successfully sent to API {user}", user);
                }
                else
                {
                    LOG.Warning("An error occured when sending user: {user}", user);
                    LOG.Debug("The error was: {0}", result.Content.ReadAsStringAsync().Result);
                }
            }
            return Index();
        }
    }
}