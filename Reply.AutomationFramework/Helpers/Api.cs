using RestSharp;
using RestSharp.Authenticators;


namespace Reply.AutomationFramework.Helpers
{
    public class Api
    {
        private readonly RestClient client;
        private ConfigurationManager configManager { get; set; }
        private Settings settings { get; set; }
        public Api()
        {
            configManager = new ConfigurationManager();
            settings = configManager.get_config();
            var options = new RestClientOptions(settings.apiUrl)
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            };
            client = new RestClient(options);
        }
        public string[] getCookie()
        {
            var request = new RestRequest(settings.apiEndPoint, Method.Get);
            request.AddJsonBody(new { username = "admin", password = "admin" });
            var cookies = client.Post(request).Cookies;
            return cookies[0].ToString().Split("=");
        }
    }
}
