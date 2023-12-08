using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using System;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    internal class Reports: BasePage
    {
        public Reports(IObjectContainer objectContainer) : base(objectContainer)
        {
        }
        private By ReportsTableBy = By.CssSelector("div[class='card-body panel-body listview-body']");
        private By ReportsTableRowsBy = By.CssSelector("div[class='card-body panel-body listview-body'] tr");
        IWebElement SearchInput => _pageLoader.GetClickableElement(By.CssSelector("input[class='input-text input-entry ']"));
        List<IWebElement> ReportsTable => _pageLoader.GetVisibleElement(ReportsTableBy).FindElements(By.TagName("tr")).ToList();
        List<IWebElement> ReportsTableRows => _pageLoader.GetVisibleElements(ReportsTableRowsBy).ToList();
        List<IWebElement> Paginations => _pageLoader.GetVisibleElements(By.CssSelector("div[class='input-button-group']")).ToList();
        IWebElement RunReport => _pageLoader.GetClickableElement(By.Name("FilterForm_applyButton"));
        public void WaitUntilElementsNotStale()
        {
            _pageLoader.WaitUntilNotStale(By.CssSelector("div[class='card-body panel-body listview-body'] td a"));
        }
        public void ClickRunReport()
        {
            Actions action = new (_objectContainer.Resolve<Driver>("driver").SeleniumDriver);
            action.MoveToElement(RunReport).Perform();
            action.Click(RunReport).Perform();
        }
        public void Search(string text)
        {
            SearchInput.SendKeys(text);
            Thread.Sleep(2000);
            SearchInput.SendKeys(Keys.Enter);
        }
        public void GoToReportPage(string text)
        {
            _pageLoader.WaitUntilTextToBePresent(By.CssSelector("div[class='card-body panel-body listview-body'] td a"), text);
            foreach (IWebElement row in ReportsTable)
            {
                var row_details = row.FindElements(By.TagName("td"));
                foreach(IWebElement row_detail in row_details)
                {
                    if(row_detail.Text == text)
                    {
                        row_detail.FindElement(By.TagName("a")).Click();
                        return;
                    }
                }
            }
            Paginations[0].FindElements(By.TagName("button"))[1].Click();
            GoToReportPage(text);
        }
        public int TableCount()
        {
            int rows = 0;
            var MaxRetries = 3;
            _pageLoader.WaitUntilExists(ReportsTableRowsBy);
            for (int i = 0; i < MaxRetries; i++)
            {
                try
                {
                    rows = ReportsTableRows.Count;
                    return rows;
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("INFO - Exception occured when waiting for element to not be present in function TableCount");
                    Console.WriteLine("INFO - Waiting for 3 seconds and continuing...");
                    Thread.Sleep(3000);
                    ClickRunReport();
                }
            }
            return rows;
        }
        public string TableText()
        {
            string text = "";
            WaitUntilElementsNotStale();
            foreach (IWebElement row in ReportsTableRows)
            {
                text += row.Text;
            }
            return text;
        }
    }
}
