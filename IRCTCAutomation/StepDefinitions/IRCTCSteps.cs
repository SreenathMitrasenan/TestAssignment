using DoorwardGUIAutomation.Managers;
using DoorwardGUIAutomation.PageObjects;
using DoorwardGUIAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DoorwardGUIAutomation.StepDefinitions
{
    [Binding]
    public class IRCTCSteps
    {
        private readonly IWebDriver driver;
        IrctcPage irctcHomepage;

        public IRCTCSteps(TestContext1 testContext)
        {

            this.driver = testContext.getWebDriverManager().GetDriver();
            irctcHomepage = new IrctcPage(driver);

        }


        [Given(@"I am on IRCTC login page")]
        public void GivenIAmOnIRCTCLoginPage()
        {
            driver.Navigate().GoToUrl(Fs.GetIRCTCAppUrl());
        }

        [Then(@"I override the pop up in irctc page")]
        public void ThenIOverrideThePopUpInIrctcPage()
        {
            irctcHomepage.checkandClickPopUp();
        }


        [Then(@"I enter source'(.*)' and destination'(.*)'codes")]
        public void ThenIEnterSourceAndDestinationCodes(string p0, string p1)
        {
            //irctcHomepage.checkandClickPopUp();
            irctcHomepage.enterFrom(p0);
            irctcHomepage.enterTo(p1);
            irctcHomepage.clickSearch();
        }
        
        [Then(@"I verify trains are dispalyed or not and check specefic train'(.*)'")]
        public void ThenIVerifyTrainsAreDispalyedOrNotAndCheckSpeceficTrain(string p0)
        {
            irctcHomepage.verifyShatabdiTrain(p0);
        }

        [Then(@"I verify and check specefic train'(.*)'")]
        public void ThenIVerifyAndCheckSpeceficTrain(string p0)
        {
            irctcHomepage.verifySpeceficTrain(p0);
        }


        [Then(@"I teardown the browser")]
        public void ThenITeardownTheBrowser()
        {
           
        }
        
        [Then(@"I click on track your train")]
        public void ThenIClickOnTrackYourTrain()
        {
            irctcHomepage.navigateTrackYourTrainLink();
        }
        
        [Then(@"I enter train number'(.*)'and hit enter")]
        public void ThenIEnterTrainNumberAndHitEnter(string p0)
        {
            irctcHomepage.enterTrainNumber(p0);
        }
        
        [Then(@"I verify all trains stations'(.*)'are dispalyed")]
        public void ThenIVerifyAllTrainsStationsAreDispalyed(string Locations)
        {
            List<String> stations=irctcHomepage.getStationList();
            String[] myList=Locations.Split(",");
  
            /*foreach (var item in myList)
            {
                Assert.AreEqual(true, stations.Contains(item));
            } */
        }
        
        [Then(@"I verify the date'(.*)'displated")]
        public void ThenIVerifyTheDateDisplated(string p0)
        {
            irctcHomepage.verifyTodaysDate(p0);


        }
    }
}
