using Newtonsoft.Json;

namespace Reply.AutomationFramework.Helpers
{
    public class Settings
    {
        [JsonProperty("defaultBrowser")]
        public string defaultBrowser { get; set; }
        [JsonProperty("defaultDriver")]
        public string defaultDriver { get; set; }
        [JsonProperty("seleniumServerUrl")]
        public string seleniumServerUrl { get; set; }
        [JsonProperty("testedAppUrl")]
        public string testedAppUrl { get; set; }
        [JsonProperty("exclude")]
        public List<string> exclude { get; set; }
    }
}
