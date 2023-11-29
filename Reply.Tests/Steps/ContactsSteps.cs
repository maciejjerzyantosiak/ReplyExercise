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
            var contacts = new Contacts(_scenarioContext);
            contacts.ClickCreate();
            Dictionary<string, string> contactInfo = contacts.FillContactInfo();
            _scenarioContext.Set(contactInfo, "ContactInfo");
        }

        [Then(@"the contact data should match with entered data")]
        public void ThenTheContactDataShouldMatchWithEnteredData()
        {
            var contactDetails = new ContactDetails(_scenarioContext);
            Assert.IsTrue(!_scenarioContext.Get<Dictionary<string, string>>("ContactInfo").Except(contactDetails.ReturnDetails()).Any());
        }
    }
}
