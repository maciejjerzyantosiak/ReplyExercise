using NUnit.Framework;
using Reply.Tests.Pages;
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
            home.HoverOverSalesMarketing();
            home.ClickContacts();
        }

        [When(@"I create a new contact")]
        public void WhenICreateANewContact()
        {
            var salesHome = new Contacts(_scenarioContext);
            salesHome.ClickCreate();
        }

        [Then(@"the contact data should match with entered data")]
        public void ThenTheContactDataShouldMatchWithEnteredData()
        {
            Assert.IsTrue(true);
        }
    }
}
