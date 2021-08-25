using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorwardGUIAutomation.Managers
{
    public class TestContext1
    {

        private WebDriverManager webDriverManager;
        private PageObjectManager pageObjectManager;

        public TestContext1()
        {
        webDriverManager = new WebDriverManager();
        pageObjectManager = new PageObjectManager(webDriverManager.GetDriver());
        }

        public WebDriverManager getWebDriverManager()
        {
            return webDriverManager;
        }

        public PageObjectManager getPageObjectManager()
        {
            return pageObjectManager;
        }
    }
}
