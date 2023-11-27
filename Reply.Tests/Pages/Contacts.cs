using OpenQA.Selenium;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    public class Contacts
    {
        private readonly ScenarioContext _scenarioContext;
        private PageLoader _pageLoader;
        public Contacts(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pageLoader = new PageLoader(_scenarioContext.Get<Driver>("SeleniumDriver"));
        }
        
        IWebElement create => _pageLoader.GetVisibleElement(By.Id("listView-92a9-create"));
        IWebElement leftSidebar => _pageLoader.GetVisibleElement(By.Id("left-sidebar"));
        IWebElement firstName => _pageLoader.GetVisibleElement(By.Id("DetailFormfirst_name-input"));
        IWebElement lastName => _pageLoader.GetVisibleElement(By.Id("DetailFormfirst_name-input"));
        IWebElement role => _pageLoader.GetVisibleElement(By.Id("DetailFormbusiness_role-input-label"));
        List<IWebElement> actions => _pageLoader.GetVisibleElements(By.CssSelector("div[class='column listview-actions buttons-inline align-left']"));

        public void ClickCreate() => create.Click();
        public void ClickOnSideBar(string sideBarItem)
        {
            var items = leftSidebar.FindElements(By.CssSelector("div[class='sidebar-item']"));
            foreach(IWebElement elem in items)
            {
                if(elem.Text == sideBarItem)
                {
                    elem.Click();
                }
            }
        }
    }
}
