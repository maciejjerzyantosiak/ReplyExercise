using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using TechTalk.SpecFlow;
using Faker;
using BoDi;

namespace Reply.Tests.Pages
{
    public class Contacts: BasePage
    {
        public Contacts(IObjectContainer objectContainer) : base(objectContainer)
        {
        }
        
        IWebElement Create => _pageLoader.GetVisibleElement(By.Id("listView-92a9-create"));
        IWebElement LeftSidebar => _pageLoader.GetVisibleElement(By.Id("left-sidebar"));
        IWebElement FirstName => _pageLoader.GetVisibleElement(By.Id("DetailFormfirst_name-input"));
        IWebElement LastName => _pageLoader.GetVisibleElement(By.Id("DetailFormlast_name-input"));
        IWebElement Role => _pageLoader.GetVisibleElement(By.Id("DetailFormbusiness_role-input"));
        IWebElement RoleInput => _pageLoader.GetVisibleElement(By.Id("DetailFormbusiness_role-input-label"));
        IWebElement RolePopup => _pageLoader.GetVisibleElement(By.Id("DetailFormbusiness_role-input-popup"));
        IWebElement RolePopupInput => _pageLoader.GetVisibleElement(By.Id("DetailFormbusiness_role-input-search-text"));
        IWebElement Category => _pageLoader.GetVisibleElement(By.Id("DetailFormcategories-input"));
        IWebElement CategoryPopup => _pageLoader.GetVisibleElement(By.Id("DetailFormcategories-input-search"));
        
        IWebElement CategoryInput => _pageLoader.GetVisibleElement(By.Id("DetailFormcategories-input-search-text"));
        List<IWebElement> Actions => _pageLoader.GetVisibleElements(By.CssSelector("div[class='column listview-actions buttons-inline align-left']"));
        IWebElement Save => _pageLoader.GetVisibleElement(By.Id("DetailForm_save"));

        public void ClickCreateInShortcuts() => Create.Click();
        public void ClickOnSideBar(string sideBarItem)
        {
            var items = LeftSidebar.FindElements(By.CssSelector("div[class='sidebar-item']"));
            foreach(IWebElement elem in items)
            {
                if(elem.Text == sideBarItem)
                {
                    elem.Click();
                }
            }
        }
        public void ClickCreate()
        {
            var buttons = Actions[0].FindElements(By.CssSelector("div[class='inline-elt']"));
            foreach(IWebElement button in buttons)
            {
                if(button.Text == "Create")
                {
                    button.Click();
                }
            }
        }
        public Dictionary<string, string> FillContactInfo()
        {
            var contactData = CreateRandomContact();
            Actions action = new(_objectContainer.Resolve<Driver>("driver").SeleniumDriver);
            action.MoveToElement(Role).Perform();
            Thread.Sleep(3000);
            action.Click(Role).Perform();
            RolePopup.SendKeys(contactData["BusinessRole"]);
            RolePopupInput.FindElement(By.CssSelector("input[class='input-text']")).SendKeys(Keys.Enter);

            FirstName.Clear();
            FirstName.SendKeys(contactData["FirstName"]);
            LastName.Clear();
            LastName.SendKeys(contactData["LastName"]);

            action.MoveToElement(Category).Perform();
            Thread.Sleep(3000);
            action.Click(Category).Perform();
            CategoryInput.FindElement(By.CssSelector("input[class='input-text']")).SendKeys(contactData["Category"]);
            CategoryInput.FindElement(By.CssSelector("input[class='input-text']")).SendKeys(Keys.Enter);

            Save.Click();

            return contactData;
        }

        public Dictionary<string, string> CreateRandomContact()
        {
            List<string> categories = new ()
            {
                "Suppliers",
                "Customers"
            };

            List<string> businessRole = new ()
            {
                "CEO",
                "MIS",
                "CFO",
                "Sales",
                "Admin"
            };

            Dictionary<string, string> contactData = new ();
            contactData.Add("FirstName", Faker.NameFaker.FirstName());
            contactData.Add("LastName", Faker.NameFaker.LastName());
            contactData.Add("Category", categories.OrderBy(s => Guid.NewGuid()).First());
            contactData.Add("BusinessRole", businessRole.OrderBy(s => Guid.NewGuid()).First());

            return contactData;
        }
    }
}
