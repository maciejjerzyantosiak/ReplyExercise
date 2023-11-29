using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Reply.Tests.Pages
{
    internal class Reports
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PageLoader _pageLoader;

        public Reports(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pageLoader = new PageLoader(_scenarioContext.Get<Driver>("SeleniumDriver"));
        }
        IWebElement SearchInput => _pageLoader.GetVisibleElement(By.CssSelector("input[class='input-text input-entry ']"));
        List<IWebElement> ReportsTable => _pageLoader.GetVisibleElement(By.CssSelector("div[class='card-body panel-body listview-body']")).FindElements(By.TagName("tr")).ToList();
        List<IWebElement> Pagination => _pageLoader.GetVisibleElements(By.CssSelector("div[class='input-button-group']")).ToList();
        IWebElement RunReport => _pageLoader.GetClickableElement(By.Name("FilterForm_applyButton"));
        public void ClickRunReport()
        {
            Actions action = new Actions(_scenarioContext.Get<Driver>("SeleniumDriver").SeleniumDriver);
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
            _pageLoader.WaitUntilNotStale(By.Name("mass[]"));
            foreach(IWebElement row in ReportsTable)
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
            Pagination[0].FindElements(By.TagName("button"))[1].Click();
            GoToReportPage(text);
        }
        public int TableCount()
        {
            _pageLoader.WaitUntilNotStale(By.Name("mass[]"));
            var test = ReportsTable.Count();
            return ReportsTable.Count();
        }
    }
}
