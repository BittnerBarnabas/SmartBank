using System;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class BankUserDetailsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUtils.HostName);
                var result =
                    client.GetAsync(WebApiUtils.HostName + WebApiUtils.GetUsedPath +
                                    HttpContext.User.Identity.GetUserId())
                        .Result;

                return View(result.Content.ReadAsAsync<BankUser>().Result);
            }
        }
    }
}