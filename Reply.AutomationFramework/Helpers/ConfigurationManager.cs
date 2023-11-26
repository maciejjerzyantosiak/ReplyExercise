using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Reply.AutomationFramework.Helpers
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            var test = System.AppDomain.CurrentDomain.BaseDirectory;
            test = Path.Combine(test, @"..\..\..\..");
            /*AppSetting = new ConfigurationBuilder()
                    .AddJsonFile(test + "\\appsettings.json")
                    .Build();*/




            JsonTextReader reader = new JsonTextReader(new StringReader(test + "\\appsettings.json"));
        }

        public static void config()
        {
            var test = System.AppDomain.CurrentDomain.BaseDirectory;
            test = Path.Combine(test, @"..\..\..\..");
            using (StreamReader file = File.OpenText(test + "\\appsettings.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
        }
    }
}
