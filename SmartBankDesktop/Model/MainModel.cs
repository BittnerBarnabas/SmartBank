using System.Collections.Generic;
using System.Net.Http;
using Serilog;
using SmartBankDesktop.Model.Utils;
using SmartBankDesktop.Properties;

namespace SmartBankDesktop.Model
{
    internal class MainModel
    {
        private readonly ILogger LOG = Log.ForContext<MainModel>();
        public string LoggedInUserName { get; set; }
        public IEnumerable<BankUser> BankUsers { get; set; }
        public BankUser SelectedUser { get; set; }

        public void PopulateDataForDispay()
        {
            LOG.Information("Populating fields with data for display.");
            var response =
                WebApiUtils.GetFromUrl(Settings.Default.SmartBankGetAllUsersPath);
            if (response.IsSuccessStatusCode)
            {
                LOG.Debug("All bank users queried successfully.");
                BankUsers = response.Content.ReadAsAsync<IEnumerable<BankUser>>().Result;
            }
        }
    }
}