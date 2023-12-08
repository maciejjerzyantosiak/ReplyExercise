using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Reply.AutomationFramework.Helpers;

namespace Reply.AutomationFramework.Setup
{
    public class Driver
    {
        public IWebDriver SeleniumDriver { get; set; }
        public Settings Settings { get; set; }
        public ConfigurationManager ConfigManager { get; set; }
        public Driver()
        {
            ConfigManager = new ConfigurationManager();
            Settings = ConfigManager.GetConfig();
            SeleniumDriver = GetDriver();
        }
        public void Setup(string[] cookie)
        {
            SeleniumDriver.Url = Settings.TestedAppUrl;
            SeleniumDriver.Manage().Cookies.AddCookie(new Cookie(cookie[0], cookie[1]));
            SeleniumDriver.Url = Settings.TestedAppUrl;
        }
        private IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArgument("--headless=new");
            options.AddArgument("disable-gpu");
            options.AddArguments("--disable-extensions");
            options.AddArgument("--start-maximized");
            if (Settings.DefaultBrowser.ToLower() == "remote")
            {
                if (Settings.DefaultDriver.ToLower() == "chrome")
                {
                    return new RemoteWebDriver(new Uri(Settings.SeleniumServerUrl), options);
                }
                return new RemoteWebDriver(new Uri(Settings.SeleniumServerUrl), new FirefoxOptions());
            }
            if (Settings.DefaultBrowser.ToLower() == "chrome")
                return new ChromeDriver(options);
            else return new FirefoxDriver();
        }
    }
}
