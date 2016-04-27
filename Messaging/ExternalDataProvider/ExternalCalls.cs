using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExternalDataProvider
{
    public class ExternalCalls
    {
        public async Task<string> GetAuthenticationToken(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("userName OR password is missing!");

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                UseProxy = true,
                UseDefaultCredentials = true,
                Credentials = CredentialCache.DefaultCredentials
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                var authURL = ConfigurationManager.AppSettings["authURL"];
                var urlParams = String.Format("?username={0}&password={1}&client_id=eventsApp&grant_type=password", userName, password);

                // Add a new Request Message
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, authURL);

                client.BaseAddress = new Uri(authURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic ZXZlbnRzQXBwOmV2ZW50c0FwcFNlY3JldA==");

                HttpResponseMessage response = await client.PostAsync(urlParams, requestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    json = json.Substring(1);
                    var arrTokens = json.Split(':');
                    if (arrTokens.Length > 0)
                    {
                        var accessToken = arrTokens[1].Split(',')[0].Replace("\"", "");
                        if (string.IsNullOrWhiteSpace(accessToken) == false)
                        {
                            return accessToken;
                        }
                    }
                }
                return string.Empty;
            }
        }

        public async Task<bool> AccountExists(string accountName)
        {
            if ( string.IsNullOrWhiteSpace(accountName))
                throw new ArgumentNullException("accountName is missing!");

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                UseProxy = true,
                UseDefaultCredentials = true,
                Credentials = CredentialCache.DefaultCredentials
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                var authURL = "http://10.21.218.47:8050/accounts-service/account/check-username";
                var urlParams = String.Format("?username={0}", accountName);

                // Add a new Request Message
                //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, authURL);

                client.BaseAddress = new Uri(authURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(urlParams);
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    if (string.IsNullOrWhiteSpace(json) == false)
                        return (String.Compare(json, "true", StringComparison.OrdinalIgnoreCase) == 0) ? true : false;
                }
            }

            return false;
        }
    }
}
