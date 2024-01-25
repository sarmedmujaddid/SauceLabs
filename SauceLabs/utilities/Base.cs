using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Internal;
using SauceLabs.pageObjects;

namespace SauceLabs.utilities
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()

        {
            string browserName =ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationexercise.com";
        }

        public IWebDriver getDriver()

        {
            return driver;
        }

        public void InitBrowser(string browserName)

        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;
            }
        }

     public class IFrameHandler
    
        {
        private readonly IWebDriver driver;

        public IFrameHandler(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToIframe(string iframeId)
        {
                IWebElement iframeElement1 = driver.FindElement(By.Id("aswift_1"));
                IWebElement iframeElement2 = driver.FindElement(By.Id("aswift_2"));
                IWebElement iframeElement3 = driver.FindElement(By.Id("aswift_3"));
                IWebElement iframeElement4 = driver.FindElement(By.Id("aswift_4"));

            driver.SwitchTo().Frame(iframeElement1);
            driver.SwitchTo().Frame(iframeElement2);
            driver.SwitchTo().Frame(iframeElement3);
            driver.SwitchTo().Frame(iframeElement4);
           
            }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }


    [TearDown]
        public void closeBrowser()
        {
            driver.Dispose();
        }
    }
}
