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

        //[FindsBy(How = How.CssSelector, Using = "a[href='/login']")]
        //private IWebElement signup_header_button;      

        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Name']")]
        private IWebElement namefield;

        [FindsBy(How = How.CssSelector, Using = "input[data-qa='signup-email']")]
        private IWebElement emailfield;

        [FindsBy(How = How.Id, Using = "loginButton_0")]
        private IWebElement signup_Button;



        //[FindsBy(How = How.Id, Using = "idToken1")]
        //private IWebElement username;

        //[FindsBy(How = How.Name, Using = "idToken2")]
        //private IWebElement password;

        //[FindsBy(How = How.XPath, Using = "//span[@class='checkmark']")]
        //private IWebElement checkBox;

        //[FindsBy(How = How.Id, Using = "loginButton_0")]
        //private IWebElement signInButton;

        public void validLogin(string user, string email)
        {
            namefield.SendKeys(user);
            emailfield.SendKeys(email);
            //checkBox.Click();
            signup_Button.Click();
        }
        public IWebElement getUserName()

        {
            //LoginPage.namefield("Sarmad Ali");
            return namefield;
        }
    }
}
