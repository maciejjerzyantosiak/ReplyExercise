using TechTalk.SpecFlow;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Drivers;
using Reply.AutomationFramework.Setup;

namespace Reply.Tests.Hooks
{
    [Binding]
    public class HookInitialization
    {
        //private SeleniumDriver _seleniumDriver;
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
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<Driver>("SeleniumDriver").SeleniumDriver.Quit();
        }
    }
}
