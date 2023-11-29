using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using Reply.AutomationFramework.Setup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reply.AutomationFramework.Helpers
{
    public class PageLoader
    {
        private Driver _driver;
        public PageLoader(Driver driver)
        {
            _driver = driver;
        }
        public IWebElement GetVisibleElement(By locator)
        {
            return new WebDriverWait(_driver.SeleniumDriver, System.TimeSpan.FromSeconds(20))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public IWebElement GetClickableElement(By locator)
        {
            return new WebDriverWait(_driver.SeleniumDriver, System.TimeSpan.FromSeconds(20))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public List<IWebElement> GetVisibleElements(By locator)
        {
            return new WebDriverWait(_driver.SeleniumDriver, System.TimeSpan.FromSeconds(20))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).ToList();
        }
        public void WaitUntilNotStale(By locator)
        {
            try
            {
                new WebDriverWait(_driver.SeleniumDriver, System.TimeSpan.FromSeconds(30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(_driver.SeleniumDriver.FindElement(locator)));
            }
            catch (Exception WebDriverTimeoutException)
            {
                Console.WriteLine("Exception occured when waiting for element to not be stale");
                Console.WriteLine("Waiting for 3 seconds and continuing...");
                Thread.Sleep(3000);
                //logging tbd
            }
        }
        public void CloseSystemMessage()
        {
            List<IWebElement> dialogs = _driver.SeleniumDriver.FindElements(By.Id("sysmsg-0")).ToList();
            if (dialogs.Count() > 0)
            {
                GetVisibleElement(By.CssSelector("div[class='uii uii-cancel uii-lg active-icon dialog-close']")).Click();
            }
        }
    }
}
