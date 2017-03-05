using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Serilog;
using SmartBankUi.Models;

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
        public ActionResult Index(BankUser user)
        {
            //user.Password = //GenerateHashAndSalt(user.Password).Item1;
            LOG.Debug("Received user login from : {user}", user);

            using (var client = new HttpClient())
            {

            }   
            return RedirectToAction("Index","Home");
        }


    }
}