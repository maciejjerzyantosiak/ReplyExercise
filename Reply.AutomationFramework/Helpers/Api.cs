using RestSharp;
using RestSharp.Authenticators;


namespace Reply.AutomationFramework.Helpers
{
    public class Api
    {
        private readonly RestClient Client;
        private ConfigurationManager ConfigManager { get; set; }
        private Settings Settings { get; set; }
        public Api()
        {
            ConfigManager = new ConfigurationManager();
            Settings = ConfigManager.get_config();
            var options = new RestClientOptions(Settings.apiUrl)
            {
                Authenticator = new HttpBasicAuthenticator("admin", "admin")
            };
            Client = new RestClient(options);
        }
        public string[] GetCookie()
        {
            var request = new RestRequest(Settings.apiEndPoint, Method.Get);
            request.AddJsonBody(new { username = "admin", password = "admin" });
            var cookies = Client.Post(request).Cookies;
            return cookies[0].ToString().Split("=");
        }
    }
}
