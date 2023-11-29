using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Reply.AutomationFramework.Helpers;
using Newtonsoft.Json;

namespace Reply.AutomationFramework.Setup
{
    public class Driver
    {
        public IWebDriver SeleniumDriver { get; set; }
        private Settings settings { get; set; }
        private ConfigurationManager configManager { get; set; }
        public Driver()
        {
            configManager = new ConfigurationManager();
            settings = configManager.get_config();
            SeleniumDriver = GetDriver();
        }
        public void Setup(string[] cookie)
        {
            SeleniumDriver.Url = settings.testedAppUrl;
            SeleniumDriver.Manage().Cookies.AddCookie(new Cookie(cookie[0], cookie[1]));
            SeleniumDriver.Url = settings.testedAppUrl;
        }
        private IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArgument("--headless=new");
            options.AddArgument("disable-gpu");
            options.AddArguments("--disable-extensions");
            options.AddArgument("--start-maximized");
            if (settings.defaultBrowser.ToLower() == "remote")
            {
                if (settings.defaultDriver.ToLower() == "chrome")
                {
                    return new RemoteWebDriver(new Uri(settings.seleniumServerUrl), options);
                }
                return new RemoteWebDriver(new Uri(settings.seleniumServerUrl), new FirefoxOptions());
            }
            if (settings.defaultBrowser.ToLower() == "chrome")
                return new ChromeDriver(options);
            else return new FirefoxDriver();
        }
    }
}
