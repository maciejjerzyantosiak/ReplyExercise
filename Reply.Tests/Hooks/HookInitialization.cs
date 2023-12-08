using TechTalk.SpecFlow;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using BoDi;
using OpenQA.Selenium;
using Dynamitey.Internal.Optimization;

namespace Reply.Tests.Hooks
{
    [Binding]
    public class HookInitialization
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;

        public HookInitialization(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver _driver = new();
            _objectContainer.RegisterInstanceAs<Driver>(_driver, "driver");
            var api = new Api();
            var cookie = api.GetCookie();
            _driver.Setup(cookie);
            var _pageLoader = new PageLoader(_driver);
            _pageLoader.CloseSystemMessage();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<Driver>("driver").SeleniumDriver.Quit();
        }
    }
}
