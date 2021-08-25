using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorwardGUIAutomation.PageObjects
{
    class IrctcPage
    {
        private IWebDriver _driver;
       
        public IrctcPage(IWebDriver driver) => _driver = driver;


        public IWebElement popUpButton => _driver.FindElement(By.XPath("//button[normalize-space()='OK']"));


        public IWebElement From => _driver.FindElement(By.XPath("//input[@class='ng-tns-c58-8 ui-inputtext ui-widget ui-state-default ui-corner-all ui-autocomplete-input ng-star-inserted']"));
        public IWebElement To => _driver.FindElement(By.XPath("//input[@class='ng-tns-c58-9 ui-inputtext ui-widget ui-state-default ui-corner-all ui-autocomplete-input ng-star-inserted']"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ShatabdiTrain => _driver.FindElement(By.XPath("//strong[contains(text(),'JAN SHATABDI')]"));

        public String TrainLinks => "https://enquiry.indianrail.gov.in/mntes/";

        public IWebElement TrainNumber => _driver.FindElement(By.XPath("//input[@id='trainNo']"));

        public IWebElement todaysDate => _driver.FindElement(By.XPath("//input[@name='jToday']"));








        public void checkandClickPopUp()
        {

            /*Actions action = new Actions(_driver);
            action.DoubleClick(popUpButton).Build().Perform(); */
            popUpButton.Click();

        }

        public void enterFrom(String arg)
        {
            From.SendKeys(arg);
            System.Threading.Thread.Sleep(1500);
            From.SendKeys(Keys.Enter);
            From.SendKeys(Keys.Tab);

        }

        public void enterTo(String arg)
        {
            To.SendKeys(arg);
            System.Threading.Thread.Sleep(1500);
            To.SendKeys(Keys.Enter);
            To.SendKeys(Keys.Tab);
        }

        public void clickSearch()
        {
            SearchButton.Click();
        }

        public void verifyShatabdiTrain(String trainName)
        {
            String tName = ShatabdiTrain.Text;
            Assert.AreEqual(trainName,tName);
        }
        public void verifySpeceficTrain(String trainName)
        {
             IWebElement ExpTrain = _driver.FindElement(By.XPath("//strong[contains(text(),'"+ trainName + "')]"));
            String tName = ExpTrain.Text;
            Assert.AreEqual(trainName, tName);
        }

        public void navigateTrackYourTrainLink()
        {
            _driver.Navigate().GoToUrl(TrainLinks);
        }

        public void enterTrainNumber(String trNumber)
        {
            System.Threading.Thread.Sleep(1000);
            TrainNumber.SendKeys(trNumber);
            System.Threading.Thread.Sleep(1000);
            TrainNumber.SendKeys(Keys.Enter);
            TrainNumber.SendKeys(Keys.Tab);
        }

        public List<String> getStationList()
        {
            List<String> stations = new List<string>();
            IWebElement StationList = _driver.FindElement(By.XPath("//select[@id='jStation']"));
            
            SelectElement oSelect = new SelectElement(StationList);
            IList<IWebElement> elementCount = oSelect.Options;
            int iSize = elementCount.Count;

            for (int i = 0; i < iSize; i++)
            {
                String sValue = elementCount.ElementAt(i).Text;
                stations.Add(sValue);
                Console.WriteLine(sValue);

            }
            return stations;
        }


        public void verifyTodaysDate(String argDate)
        {
            String cc = todaysDate.GetAttribute("value");
            Assert.AreEqual(argDate, cc);
        }

    }
}
