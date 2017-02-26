using System.Web.Mvc;
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

            return Index();
        }

    }
}