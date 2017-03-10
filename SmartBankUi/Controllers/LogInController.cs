using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Serilog;
using SmartBankUi.Models;
using SmartBankUi.Models.Util;

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
        public async Task<ActionResult> Index(BankUser user)
        {
            LOG.Debug("Received user login from : {user}", user);

            using (var client = new HttpClient())
            {
                var hostname = "http://localhost:49848";
                var addUserPath = "/api/users/getuser/" + user.Username;
                client.BaseAddress = new Uri(hostname);
                var result = client.GetAsync(hostname + addUserPath).Result;

                if (!result.IsSuccessStatusCode) return RedirectToAction("Index", "Home");

                var receivedUser = await result.Content.ReadAsAsync<BankUser>();
                LOG.Debug("Received user : {0}", receivedUser);

                Login(user, receivedUser);
            }   
            return RedirectToAction("Index","Home");
        }

        private void Login(BankUser user, BankUser receivedUser)
        {
            if (CryptographyUtils.HaveTheSamePassword(user, receivedUser))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, receivedUser.Name),
                    new Claim(ClaimTypes.NameIdentifier, receivedUser.Username)
                };

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                AuthenticationManager.SignIn(new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                }, identity);

                LOG.Information("User successfully logged in: {0}, {1}", HttpContext.User.Identity.Name, HttpContext.User.Identity.IsAuthenticated);
            }
            else
            {
                LOG.Warning("Access denied for user: {user}", user.Username);
            }
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}