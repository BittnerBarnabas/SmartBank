using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Serilog;
using SmartBankUi.Models;

namespace SmartBankUi.Controllers
{
    public class RegistrationController : Controller
    {
        private ILogger LOG = Log.ForContext<RegistrationController>();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BankUser user)
        {
            using (var client = new HttpClient())
            {
                var hostname = "http://localhost:49848";
                var addUserPath = "/api/users/adduser";
                client.BaseAddress = new Uri(hostname);
                var link = hostname + addUserPath;
                LOG.Debug("Posting user data to: {link}", link);
                var result = client.PostAsync(addUserPath, user, new JsonMediaTypeFormatter()).Result;
                if (result.IsSuccessStatusCode)
                {
                    LOG.Information("Bank user successfully sent to API {user}", user);
                }
                else
                {
                    string content = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("oops, an error occurred, here's the raw response: {0}", content);
                }
            }
            return Index();
        }

    }
}