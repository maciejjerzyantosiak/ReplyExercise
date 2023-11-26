using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Reply.AutomationFramework.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reply.AutomationFramework.Helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Reply.AutomationFramework.Setup
{
    public class Driver
    {
        public IWebDriver SeleniumDriver { get; set; }
        private Settings settings { get; set; }
        public Driver()
        {
            settings = get_config();
            SeleniumDriver = GetDriver();
        }
        public void Setup(string[] cookie)
        {

            SeleniumDriver.Url = settings.testedAppUrl;
            SeleniumDriver.Manage().Cookies.AddCookie(new Cookie(cookie[0], cookie[1]));
            SeleniumDriver.Manage().Window.Maximize();
            SeleniumDriver.Url = settings.testedAppUrl;
        }
        private IWebDriver GetDriver()
        {
            if (settings.defaultBrowser.ToLower() == "remote")
            {
                if (settings.defaultDriver.ToLower() == "chrome")
                {
                    var options = new ChromeOptions();
                    options.AddArguments("--incognito");
                    return new RemoteWebDriver(new Uri(settings.seleniumServerUrl), options);
                }
                return new RemoteWebDriver(new Uri(settings.seleniumServerUrl), new FirefoxOptions());
            }
            if (settings.defaultBrowser.ToLower() == "chrome")
                return new ChromeDriver();
            else return new FirefoxDriver();
        }

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
