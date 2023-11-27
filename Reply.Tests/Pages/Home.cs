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
        public Home(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pageLoader = new PageLoader(_scenarioContext.Get<Driver>("SeleniumDriver"));
        }
        IWebElement salesMarketing => _pageLoader.GetVisibleElement(By.Id("grouptab-1"));
        IWebElement contacts => _pageLoader.GetVisibleElement(By.CssSelector("a[href='index.php?module=Contacts&action=index']"));
        public void ClickSalesMarketing() => salesMarketing.Click();
        public void ClickContacts() => contacts.Click();
        public void HoverOverSalesMarketing()
        {
            Actions action = new Actions(_scenarioContext.Get<Driver>("SeleniumDriver").SeleniumDriver);
            action.MoveToElement(salesMarketing).Perform();
        }
    }
}
