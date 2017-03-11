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
            var result = WebApiUtils.GetFromUrl(WebApiUtils.HostName, WebApiUtils.GetUserPath +
                                                                      HttpContext.User.Identity.GetUserId());

            return View(result.Content.ReadAsAsync<BankUser>().Result);
        }
    }
}