using System.Web.Mvc;

namespace SmartBankUi.Controllers
{
    public class TransactionController : Controller
    {
        public ActionResult Index()
        {
            return View("TransactionPage");
        }
    }
}