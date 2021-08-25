using DoorwardGUIAutomation.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorwardGUIAutomation.Managers
{
    public class PageObjectManager
    {
        private IWebDriver driver;
        private DoorwardHomePage doorwardLogin;
        private DoorwardDashboardPage doorwardDashboard;

        public PageObjectManager(IWebDriver driver)
        {
            this.driver = driver;
        }
        public DoorwardHomePage getDoorwardLoginPage()
        {
            return (doorwardLogin == null) ? doorwardLogin = new DoorwardHomePage(driver) : doorwardLogin;
        }
        public DoorwardDashboardPage getDoorwardDashboardPage()
        {
            return (doorwardDashboard == null) ? doorwardDashboard = new DoorwardDashboardPage(driver) : doorwardDashboard;
        }
    }
}
