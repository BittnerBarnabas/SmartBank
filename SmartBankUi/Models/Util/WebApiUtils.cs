using System;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace SmartBankUi.Models.Util
{
    public static class WebApiUtils
    {
        public static string HostName { get; set; } = "http://localhost:49848";
        public static string GetUserPath { get; set; } = "/api/users/getuser/";

        public static string PutTransactionPath { get; set; } =
            "/api/transaction/putTransaction/";

        public static string GetTransactionsForAccountPath { get; set; } =
            "/api/transaction/forAccount/";

        public static HttpResponseMessage GetFromUrl(string hostname, string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostname);
                return client.GetAsync(hostname + url).Result;
            }
        }

        public static HttpResponseMessage PostToUrl<T>(string hostname, string url,
            T param)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostname);
                return
                    client.PostAsync(hostname + url, param, new JsonMediaTypeFormatter())
                        .Result;
            }
        }
    }
}