namespace NancyApplication
{
    using System;
    using Nancy;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;
    
    public class HomeModule : NancyModule
    {
        private static readonly string baseAddress = "https://api.accusoft.com/";
        private static async Task<string> GetiFrameAuthToken(string key, string user, string role)
        {
            var message = string.Format("grant_type=client_credentials&scope=userid:{0} role:{1}", user, role);
            
            dynamic json = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("acs-api-key", key);
                
                var request = new HttpRequestMessage(HttpMethod.Post, "/v1/authTokens");
                request.Content = new StringContent(message, Encoding.UTF8, "application/x-www-form-urlencoded");
                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                json = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                return json.access_token;
            }
        }
        public HomeModule()
        {
            Get["/", true] = async (_, ct) => {
                
                // This will be the username and role from your system
                var userName = "<USER NAME HERE>";
                var roleName = "<USER ROLE HERE>";
                
                // This is your api key from http://www.accusoft.com/portal
                var apiKey = "<ACS API KEY HERE>";
                
                var token = await GetiFrameAuthToken(apiKey, userName, roleName);
                
                var address = baseAddress
                    + "v1/docstore/assets/index.html?authToken="
                    + token;
                    
                var template = "<iframe src=\"{0}\" style=\"width:100%; height:100%;\"></iframe>";
                return string.Format(template, address);
            };
        }
    }
}
