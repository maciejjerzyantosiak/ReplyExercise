using RestSharp;
using RestSharp.Authenticators;


namespace Reply.AutomationFramework.Helpers
{
    public class Api
    {
        private readonly RestClient Client;
        public ConfigurationManager ConfigManager { get; set; }
        public Settings Settings { get; set; }
        public Api()
        {
            ConfigManager = new ConfigurationManager();
            Settings = ConfigManager.GetConfig();
            var options = new RestClientOptions(Settings.ApiUrl)
            {
                Authenticator = new HttpBasicAuthenticator(Settings.Username, Settings.Password)
            };
            Client = new RestClient(options);
        }
        public string[] GetCookie()
        {
            var request = new RestRequest(Settings.ApiEndPoint, Method.Get);
            request.AddJsonBody(new { username = Settings.Username, password = Settings.Password });
            var cookies = Client.Post(request).Cookies;
            return cookies[0].ToString().Split("=");
        }
    }
}
