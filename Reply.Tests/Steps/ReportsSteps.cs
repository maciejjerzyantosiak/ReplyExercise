using NUnit.Framework;
using Reply.Tests.Pages;
using TechTalk.SpecFlow;

namespace Reply.Tests.Steps
{
    [Binding]
    public class ReportsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public ReportsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am on Reports page")]
        public void GivenIAmOnReportsPage()
        {
            var home = new Home(_scenarioContext);
            home.HoverOverReportsSettings();
            home.ClickReports();
        }

        [When(@"I run '([^']*)' report")]
        public void WhenIRunReport(string p0)
        {
            var reports = new Reports(_scenarioContext);
            reports.Search(p0);
            reports.GoToReportPage(p0);
            reports.ClickRunReport();
            _scenarioContext.Set(reports, "Reports");
        }

        [Then(@"the I should see some results")]
        public void ThenTheIShouldSeeSomeResults()
        {
            Assert.That(_scenarioContext.Get<Reports>("Reports").TableCount() > 0);
            Assert.That(_scenarioContext.Get<Reports>("Reports").TableText().Count() > 100);
        }
    }
}
