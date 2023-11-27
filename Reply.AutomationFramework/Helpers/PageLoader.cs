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
            return new WebDriverWait(_driver.SeleniumDriver, System.TimeSpan.FromSeconds(10))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public List<IWebElement> GetVisibleElements(By locator)
        {
            return new WebDriverWait(_driver.SeleniumDriver, System.TimeSpan.FromSeconds(10))
                                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).ToList();
        }
    }
}
