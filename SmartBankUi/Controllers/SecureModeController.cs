using System.Web.Mvc;
using SmartBankUi.Models.Util;

namespace SmartBankUi.Controllers
{
    public class SecureModeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("SecureModeTransfer");
        }

        [HttpPost]
        public ActionResult RedirectToPage(SecureModeTransferObject transferObject)
        {
            return 
            // return RedirectToAction(transferObject.ActionName, transferObject.ControllerName);
        }
    }
}