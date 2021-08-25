using DoorwardGUIAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorwardGUIAutomation.Managers
{
    public class WebDriverManager
    {
        private IWebDriver driver;
        private static BrowserType browserType;
        private static EnvironmentType environmentType;
        private static string DriverPath;
        private static string NodeUrl;
        public WebDriverManager()
        {
            browserType = Fs.GetBrowser();
            environmentType = Fs.GetEnvironmant();
        }

        public IWebDriver GetDriver()
        {
            if (driver == null) driver = CreateDriver();
            return driver;
        }

        private IWebDriver CreateDriver()
        {
            switch (environmentType)
            {
                case EnvironmentType.LOCAL: driver = CreateLocalDriver();
                break;
                case EnvironmentType.REMOTE: driver = CreateRemoteDriver();
                break;
            }
            return driver;
        }


        public  void CloseDriver()
        {
            driver.Quit();
        }

        public void CloseAllDrivers()
        {
            driver.Close();
        }

        private IWebDriver CreateRemoteDriver()
        {
            throw new NotImplementedException();
        }

        private IWebDriver CreateLocalDriver()
        {
            switch(browserType)
            {
                case BrowserType.CHROME:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddAdditionalCapability(CapabilityType.AcceptSslCertificates,true,true);
                    chromeOptions.AddArgument("ignore-certificate-erros");
                    //chromeOptions.AddArgument("--incognito");
                    WebDriver = new ChromeDriver(@"" + Fs.GetDriverPath(), chromeOptions);
                    break;
                case BrowserType.CHROMEHEADLESS:
                    ChromeOptions options = new ChromeOptions();
                    options.AddAdditionalCapability("browser", "chrome", true);
                    options.AcceptInsecureCertificates = true;
                    options.AddArgument("--headless");
                    WebDriver = new ChromeDriver(@"" + Fs.GetDriverPath(), options);
                    break;
                case BrowserType.FIREFOX:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"" + Fs.GetDriverPath(), "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    WebDriver = new FirefoxDriver(service);
                    break;

                default:
                    WebDriver = new ChromeDriver(@""+Fs.GetDriverPath());
                    break;
            }
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Fs.GetDefaultWaitTime());
            WebDriver.Manage().Window.Maximize();
            return WebDriver;
        }

        public IWebDriver WebDriver { get; private set; }

    }

    public enum BrowserType
    {
        CHROME,
        CHROMEHEADLESS,
        FIREFOX,
        IE
    }
    public enum EnvironmentType
    {
        LOCAL, REMOTE
    }
}

