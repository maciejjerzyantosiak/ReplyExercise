using RestSharp;
using RestSharp.Authenticators;


namespace Reply.AutomationFramework.Helpers
{
    public class Api
    {
        private readonly RestClient client;
        public Api()
        {
            var options = new RestClientOptions("https://demo.1crmcloud.com/")
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            };
            client = new RestClient(options);
        }
        public string[] getCookie()
        {
            var request = new RestRequest("json.php?action=login", Method.Get);
            request.AddJsonBody(new { username = "admin", password = "admin" });
            var cookies = client.Post(request).Cookies;
            return cookies[0].ToString().Split("=");
        }
    }
}
