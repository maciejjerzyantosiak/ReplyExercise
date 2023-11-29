using Newtonsoft.Json;

namespace Reply.AutomationFramework.Helpers
{
    public class ConfigurationManager
    {
        public Settings get_config()
        {
            Settings settings;
            var config_path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,
                                           @"..\..\..\..\Reply.AutomationFramework\appsettings.json");

            using (StreamReader file = File.OpenText(config_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                settings = (Settings)serializer.Deserialize(file, typeof(Settings));
            }
            return settings;
        }
    }
}
