using BoDi;
using NUnit.Framework;
using Reply.Tests.Pages;
using TechTalk.SpecFlow;

namespace Reply.Tests.Steps
{
    [Binding]
    public class ContactsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        public ContactsSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
        [Given(@"I am on Contacts page")]
        public void GivenIAmOnContactsPage()
        {
            var home = new Home(_objectContainer);
            home.HoverOverSalesMarketing();
            home.ClickContacts();
        }

        [When(@"I create a new contact")]
        public void WhenICreateANewContact()
        {
            var contacts = new Contacts(_objectContainer);
            contacts.ClickCreate();
            Dictionary<string, string> contactInfo = contacts.FillContactInfo();
            _scenarioContext.Set(contactInfo, "ContactInfo");
        }

        [Then(@"the contact data should match with entered data")]
        public void ThenTheContactDataShouldMatchWithEnteredData()
        {
            var contactDetails = new ContactDetails(_objectContainer);
            Assert.IsTrue(!_scenarioContext.Get<Dictionary<string, string>>("ContactInfo").Except(contactDetails.ReturnDetails()).Any());
        }
    }
}
