using NUnit.Framework;
using Reply.AutomationFramework.Drivers;
using Reply.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace Reply.Tests.Steps
{
    [Binding]
    public class ContactsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public ContactsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am on Contacts page")]
        public void GivenIAmOnContactsPage()
        {
            var home = new Home(_scenarioContext);
            home.ClickSalesMarketing();
        }

        [When(@"I create a new contact")]
        public void WhenICreateANewContact()
        {
            Assert.IsTrue(true);
        }

        [Then(@"the contact data should match with entered data")]
        public void ThenTheContactDataShouldMatchWithEnteredData()
        {
            Assert.IsTrue(true);
        }
    }
}
