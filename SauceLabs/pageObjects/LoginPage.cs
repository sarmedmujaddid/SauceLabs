using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceLabs.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        //Pageobject factory

        [FindsBy(How = How.Id, Using = "idToken1")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "idToken2")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//span[@class='checkmark']")]
        private IWebElement checkBox;

        [FindsBy(How = How.Id, Using = "loginButton_0")]
        private IWebElement signInButton;

        public void validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
           
        }
        public IWebElement getUserName()

        {
            return username;
        }
    }
}
