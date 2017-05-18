using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using SmartBankDesktop.Properties;

namespace SmartBankDesktop.Model.Utils
{
    public static class WebApiUtils
    {
        public static string GetEmployeePath { get; } =
            Settings.Default.SmartBankGetEmployeePath;

        public static HttpResponseMessage GetFromUrl(string hostname, string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostname);
                return client.GetAsync(hostname + url).Result;
            }
        }

        public static HttpResponseMessage GetFromUrl(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
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