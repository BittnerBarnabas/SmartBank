using System.Web.Mvc;
using Serilog;

namespace SmartBankUi.Controllers
{
    public class HomeController : Controller
    {
        private ILogger LOG = Log.ForContext<HomeController>();

        [Authorize]
        public ActionResult Index()
        {
            LOG.Debug("New request from user with username: {0} and authentication status: {1}", HttpContext.User.Identity.Name, HttpContext.User.Identity.IsAuthenticated);
            return View();
        }
    }
}