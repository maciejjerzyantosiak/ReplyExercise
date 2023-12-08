using BoDi;
using Reply.AutomationFramework.Helpers;
using Reply.AutomationFramework.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reply.Tests.Pages
{
    public class BasePage
    {
        protected readonly PageLoader _pageLoader;
        protected readonly IObjectContainer _objectContainer;

        public BasePage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _pageLoader = new PageLoader(_objectContainer.Resolve<Driver>("driver"));
        }
    }
}
