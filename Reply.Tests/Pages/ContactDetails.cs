using BoDi;
using OpenQA.Selenium;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    public class ContactDetails: BasePage
    {
        public ContactDetails(IObjectContainer objectContainer) : base(objectContainer)
        {
        }
        IWebElement Name => _pageLoader.GetVisibleElement(By.Id("_form_header"));
        List<IWebElement> Summary => _pageLoader.GetVisibleElements(By.CssSelector("div[class='summary-meta'] > ul[class='summary-list'] > li[class='withLabel']")).ToList();
        IWebElement MainSelection => _pageLoader.GetVisibleElement(By.Id("main-0"));
        IWebElement BusinessRole => MainSelection.FindElement(By.CssSelector("div[class='column form-cell sm-6 cell-business_role span-1'] > div > div"));
        IWebElement Role => _pageLoader.GetVisibleElement(By.Id("DetailFormbusiness_role-input"));

        public Dictionary<string, string> ReturnDetails()
        {
            Dictionary<string, string> contactData = new ();
            _pageLoader.WaitUntilExists(By.Id("DetailForm_return_list-label"));
            contactData.Add("Category", Summary[0].Text.Replace("Category:\r\n", ""));
            contactData.Add("BusinessRole", BusinessRole.Text);
            var full_name = Name.Text.Split(" ");
            contactData.Add("FirstName", full_name[0]);
            contactData.Add("LastName", full_name[1]);

            return contactData;
        }
    }
}
