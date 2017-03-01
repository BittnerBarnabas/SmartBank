using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using Serilog;
using SmartBankUi.Models;

namespace SmartBankUi.Controllers
{
    public class RegistrationController : Controller
    {
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
                client.BaseAddress = new Uri("http://localhost:49848");
                var result = client.PostAsync("/api/users/adduser", user, new JsonMediaTypeFormatter()).Result;
                if (result.IsSuccessStatusCode)
                {
                    Log.Information("Performance instance successfully sent to the API");
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