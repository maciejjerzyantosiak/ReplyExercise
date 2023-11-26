using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
