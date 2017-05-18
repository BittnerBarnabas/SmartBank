using System.Net.Http;
using Serilog;
using SmartBankDesktop.Model.Utils;

namespace SmartBankDesktop.Model
{
    internal class LoginModel
    {
        private readonly ILogger LOG = Log.ForContext<LoginModel>();

        public void LogIn(string userName, string password)
        {
            LOG.Information("Getting information for user {userName}", userName);
            var result = WebApiUtils.GetFromUrl(WebApiUtils.GetEmployeePath + userName);
            if (result.IsSuccessStatusCode)
            {
                var employee = result.Content.ReadAsAsync<BankEmployee>().Result;
                LOG.Debug("Call returned with : {employee}", employee);
                if (CryptographyUtils.HaveTheSamePassword(
                    new BankEmployee { Password = password }, employee))
                {
                }
            }
        }
    }
}