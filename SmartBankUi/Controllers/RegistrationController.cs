using System.Web.Mvc;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger LOG = Log.ForContext<RegistrationController>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BankUser user)
        {
            if (!ModelState.IsValid)
            {
                LOG.Warning("Model-state is not valid for {user}", user);
                ModelState.AddModelError(string.Empty,
                    "Please fill all fields with the required information.");
                return View();
            }
            var passwordAndSalt = CryptographyUtils.GenerateHashAndSalt(user.Password);
            user.Password = passwordAndSalt.Item1;
            user.Salt = passwordAndSalt.Item2;

            var hostname = "http://localhost:49848";
            var addUserPath = "/api/users/adduser";

            LOG.Debug("Posting user data to: {0}", hostname + addUserPath);
            var result = WebApiUtils.PostToUrl(hostname, addUserPath, user);

            if (result.IsSuccessStatusCode)
            {
                LOG.Information("Bank user successfully sent to API {user}", user);
            }
            else
            {
                LOG.Warning("An error occured when sending user: {user}", user);
                LOG.Debug("The error was: {0}", result.Content.ReadAsStringAsync().Result);
            }

            return Index();
        }
    }
}