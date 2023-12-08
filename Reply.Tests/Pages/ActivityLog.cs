using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    public class ActivityLog: BasePage
    {

        public ActivityLog(IObjectContainer objectContainer): base(objectContainer)
        {          
        }
        List<IWebElement> ActivityTable => _pageLoader.GetVisibleElement(By.CssSelector("div[class='card-body panel-body listview-body']")).FindElements(By.TagName("tr")).ToList();
        List<IWebElement> ActivityTableFull => _pageLoader.GetVisibleElements(By.CssSelector("td[class='listViewTd']")).ToList();
        IWebElement Actions => _pageLoader.GetVisibleElement(By.CssSelector("button[class='input-button menu-source']"));
        List<IWebElement> Delete => _pageLoader.GetVisibleElements(By.CssSelector("div[class='option-cell input-label ']")).ToList();
        public List<string> SelectActivityRowsFromTop(int rows)
        {
            _pageLoader.WaitUntilNotStale(By.Name("mass[]"));
            Thread.Sleep(2000);
            List<string> activites = new ();
            int count = -1;
            foreach(IWebElement row in ActivityTable)
            {
                count += 1;
                if (count > 0 && count <= rows)
                {
                    row.FindElement(By.Name("mass[]")).Click();
                    activites.Add(row.FindElement(By.CssSelector("td[class='listViewTd']")).Text);
                }
            }
            return activites;
        }
        public void DeleteRecords()
        {
            Actions action = new (_objectContainer.Resolve<Driver>("driver").SeleniumDriver);
            action.MoveToElement(Actions).Perform();
            action.Click(Actions).Perform();
            action.MoveToElement(Delete.First()).Perform();
            action.Click(Delete.First()).Perform();
            _objectContainer.Resolve<Driver>("driver").SeleniumDriver.SwitchTo().Alert().Accept();
        }
        public bool VerifyDeletedActivities(List<string> deleted)
        {
            _pageLoader.WaitUntilNotStale(By.Name("mass[]"));
            foreach (IWebElement row in ActivityTableFull)
            {
                foreach(string elem in deleted)
                {
                    if (row.Text == elem)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
