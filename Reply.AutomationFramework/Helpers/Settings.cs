using Newtonsoft.Json;

namespace Reply.AutomationFramework.Helpers
{
    public class Settings
    {
        [JsonProperty("defaultBrowser")]
        public string DefaultBrowser { get; set; }
        [JsonProperty("defaultDriver")]
        public string DefaultDriver { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("webdrivertimeout")]
        public double Timeout { get; set; }
        [JsonProperty("seleniumServerUrl")]
        public string SeleniumServerUrl { get; set; }
        [JsonProperty("testedAppUrl")]
        public string TestedAppUrl { get; set; }
        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }
        [JsonProperty("apiEndPoint")]
        public string ApiEndPoint { get; set; }
        [JsonProperty("exclude")]
        public List<string> Exclude { get; set; }
    }
}
