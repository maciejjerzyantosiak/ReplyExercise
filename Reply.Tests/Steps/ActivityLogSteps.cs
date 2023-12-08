using BoDi;
using NUnit.Framework;
using Reply.Tests.Pages;
using TechTalk.SpecFlow;

namespace Reply.Tests.Steps
{
    [Binding]
    public class ActivityLogSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        public ActivityLogSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
        [Given(@"I am on activity log page")]
        public void GivenIAmOnActivityLogPage()
        {
            var home = new Home(_objectContainer);
            home.HoverOverReportsSettings();
            home.ClickActivityLog();
        }

        [When(@"I delete first (.*) items in the table")]
        public void WhenIDeleteFirstItemsInTheTable(int p0)
        {
            var activity = new ActivityLog(_objectContainer);
            _scenarioContext.Set(activity, "ActivityLog");
            _scenarioContext.Set(activity.SelectActivityRowsFromTop(p0), "SelectedActivities");
            activity.DeleteRecords();
        }

        [Then(@"the items should not be present")]
        public void ThenTheItemsShouldNotBePresent()
        {
            Assert.True(_scenarioContext.Get<ActivityLog>("ActivityLog").VerifyDeletedActivities(_scenarioContext.Get<List<string>>("SelectedActivities")));
        }
    }
}
