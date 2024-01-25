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
using AngleSharp.Text;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;

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

        [FindsBy(How = How.CssSelector, Using = "a[href='/login']")]
        private IWebElement signup_header_button;

        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Name']")]
        private IWebElement namefield;

        [FindsBy(How = How.CssSelector, Using = "input[data-qa='signup-email']")]
        private IWebElement emailfield;

        [FindsBy(How = How.Id, Using = "button[data-qa='signup-button']")]
        private IWebElement signup_Button;

        public void validLogin(string user, string email)
        {
            namefield.SendKeys(user);
            emailfield.SendKeys(email);
            signup_Button.Click();
        }
        public IWebElement getUserName()

        {
            return namefield;
        }
        public IWebElement getEmail()

        {
            return emailfield;
        }
    }
}
