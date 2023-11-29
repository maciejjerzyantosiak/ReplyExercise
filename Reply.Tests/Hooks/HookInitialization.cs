using TechTalk.SpecFlow;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using Reply.AutomationFramework.Helpers;

namespace Reply.Tests.Hooks
{
    [Binding]
    public class HookInitialization
    {
        private readonly ScenarioContext _scenarioContext;

        public HookInitialization(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver _driver = new Driver();
            _scenarioContext.Set(_driver, "SeleniumDriver");
            var api = new Api();
            var cookie = api.getCookie();
            _driver.Setup(cookie);
            var _pageLoader = new PageLoader(_driver);
            _pageLoader.CloseSystemMessage();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<Driver>("SeleniumDriver").SeleniumDriver.Quit();
        }
    }
}
