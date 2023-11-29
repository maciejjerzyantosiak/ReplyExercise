using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    public class Home
    {
        private readonly ScenarioContext _scenarioContext;
        private PageLoader _pageLoader;
        private Actions action;
        public Home(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pageLoader = new PageLoader(_scenarioContext.Get<Driver>("SeleniumDriver"));
            action = new Actions(_scenarioContext.Get<Driver>("SeleniumDriver").SeleniumDriver);
        }
        IWebElement SalesMarketing => _pageLoader.GetVisibleElement(By.Id("grouptab-1"));
        IWebElement ReportsSettings => _pageLoader.GetVisibleElement(By.Id("grouptab-5"));
        IWebElement Contacts => _pageLoader.GetVisibleElement(By.CssSelector("a[href='index.php?module=Contacts&action=index']"));
        IWebElement Reports => _pageLoader.GetVisibleElement(By.CssSelector("a[href='index.php?module=Reports&action=index']"));
        IWebElement ActivityLog => _pageLoader.GetVisibleElement(By.CssSelector("a[href='index.php?module=ActivityLog&action=index']"));
        public void ClickSalesMarketing() => SalesMarketing.Click();
        public void ClickContacts() => Contacts.Click();
        public void ClickReports() => Reports.Click();
        public void ClickActivityLog() => ActivityLog.Click();
        public void HoverOverSalesMarketing()
        {
            action.MoveToElement(SalesMarketing).Perform();
        }
        public void HoverOverReportsSettings()
        {
            action.MoveToElement(ReportsSettings).Perform();
        }
    }
}
