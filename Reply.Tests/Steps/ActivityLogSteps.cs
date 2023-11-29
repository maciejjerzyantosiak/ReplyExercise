using NUnit.Framework;
using Reply.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace Reply.Tests.Steps
{
    [Binding]
    public class ActivityLogSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public ActivityLogSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am on activity log page")]
        public void GivenIAmOnActivityLogPage()
        {
            var home = new Home(_scenarioContext);
            home.HoverOverReportsSettings();
            home.ClickActivityLog();
        }

        [When(@"I delete first (.*) items in the table")]
        public void WhenIDeleteFirstItemsInTheTable(int p0)
        {
            var activity = new ActivityLog(_scenarioContext);
            _scenarioContext.Set(activity, "ActivityLog");
            _scenarioContext.Set(activity.SelectActivityRowsFromTop(3), "SelectedActivities");
            activity.DeleteRecords();
        }

        [Then(@"the items should not be present")]
        public void ThenTheItemsShouldNotBePresent()
        {
            Assert.True(_scenarioContext.Get<ActivityLog>("ActivityLog").VerifyDeletedActivities(_scenarioContext.Get<List<string>>("SelectedActivities")));
        }
    }
}
