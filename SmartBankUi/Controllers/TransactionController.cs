using System;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger LOG = Log.ForContext<TransactionController>();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var result = WebApiUtils.GetFromUrl(WebApiUtils.HostName,
                WebApiUtils.GetUserPath +
                HttpContext.User.Identity.GetUserId());
            return View("TransactionPage",
                result.Content.ReadAsAsync<BankUser>().Result.BankAccounts);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(Transaction transaction)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult NewTransaction(int accountNumber)
        {
            return View("NewTransaction",
                new Transaction { SourceAccountNumber = accountNumber });
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewTransaction(Transaction transaction)
        {
            transaction.TransactionDateTime = DateTime.Now;
            LOG.Information("Posting transaction: {0}", transaction);

            var result = WebApiUtils.PostToUrl(WebApiUtils.HostName,
                WebApiUtils.PutTransactionPath,
                transaction);

            if (!result.IsSuccessStatusCode) return View("TransactionPage");

            LOG.Information("Transaction submitted successfully.");
            return RedirectToAction("Index", "Home");
        }
    }
}