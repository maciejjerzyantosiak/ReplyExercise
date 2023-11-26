using OpenQA.Selenium;
using Reply.AutomationFramework.Drivers;
using Reply.AutomationFramework.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    public class Home
    {
        private readonly ScenarioContext _scenarioContext;
        public Home(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        IWebElement salesMarketing => _scenarioContext.Get<Driver>("SeleniumDriver").SeleniumDriver.FindElement(By.Id("grouptab-1"));

        public void ClickSalesMarketing() => salesMarketing.Click();
    }
}
