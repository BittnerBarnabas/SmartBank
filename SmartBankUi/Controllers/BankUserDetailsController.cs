using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class BankUserDetailsController : Controller
    {
        private readonly ILogger LOG = Log.ForContext<BankUserDetailsController>();

        [Authorize]
        public ActionResult Index()
        {
            LOG.Debug("Getting bank account list for user: {0}",
                HttpContext.User.Identity.GetUserId());
            var result = WebApiUtils.GetFromUrl(WebApiUtils.HostName,
                WebApiUtils.GetUserPath +
                HttpContext.User.Identity.GetUserId());

            return View(result.Content.ReadAsAsync<BankUser>().Result);
        }

        [Authorize]
        public ActionResult History(int accountNumber)
        {
            LOG.Debug("Getting transaction list for accont number: {0}", accountNumber);
            var result = WebApiUtils.GetFromUrl(WebApiUtils.HostName,
                WebApiUtils.GetTransactionsForAccountPath + accountNumber);
            return View("History",
                new Tuple<List<Transaction>, int>(
                    result.Content.ReadAsAsync<List<Transaction>>().Result, accountNumber));
        }
    }
}