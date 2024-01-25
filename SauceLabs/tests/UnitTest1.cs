using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using SauceLabs.utilities;
using SauceLabs.pageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using static SauceLabs.utilities.Base;
using OpenQA.Selenium.DevTools.V115.FedCm;

namespace SauceLabs.tests
{
    public class Tests : Base
    {

        [Test]
        public void TestSignup()
        {
            IFrameHandler iframeHandler = new IFrameHandler(driver);
            iframeHandler.SwitchToDefaultContent();

            driver.FindElement(By.CssSelector("a[href='/login']")).Click();                   
            Console.WriteLine("User redirected to Signup/Login Page");

            driver.FindElement(By.CssSelector("input[placeholder='Name']")).SendKeys("Sarmad");

            driver.FindElement(By.CssSelector("input[data-qa='signup-email']")).SendKeys("adminuser@out.com");

            driver.FindElement(By.CssSelector("button[data-qa='signup-button']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[normalize-space()='Enter Account Information']")));

            Console.WriteLine("User is navigated to Enter Account Information Page.");

            driver.FindElement(By.Id("password")).SendKeys("123456789");
            

            IList<IWebElement> titleRadio = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radioButton in titleRadio) 
            {
                if(radioButton.GetAttribute("Value").Equals("Mrs")) 
                {
                    radioButton.Click();
                }
            }

            WebDriverWait waitRad = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Console.WriteLine("Radio button is clicked successfully");

            driver.FindElement(By.Id("first_name")).SendKeys("Charlie");

            driver.FindElement(By.Id("last_name")).SendKeys("Brown");

            driver.FindElement(By.Id("address1")).SendKeys("Dynamic Address");

            driver.FindElement(By.Id("state")).SendKeys("Munich");

            driver.FindElement(By.Id("city")).SendKeys("Hamburg");

            driver.FindElement(By.Id("zipcode")).SendKeys("Hamburg");

            driver.FindElement(By.Id("mobile_number")).SendKeys("12321312123");


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-qa='create-account']"))); //**this is where the magic happens

            driver.SwitchTo().DefaultContent();

            // Create an instance of Actions
            Actions actions = new Actions(driver);

            // Scroll down the page
            actions.SendKeys(Keys.PageDown).Build().Perform();


            //            driver.SwitchTo().DefaultContent();
            //            IWebElement iframeElement1 = driver.FindElement(By.Id("aswift_1"));
            //            driver.SwitchTo().DefaultContent();

            // Now you can interact with the desired button
            IWebElement createAccountButton = driver.FindElement(By.XPath("//button[normalize-space()='Create Account']"));
            createAccountButton.Click();

            driver.SwitchTo().DefaultContent();

            WebDriverWait waitnext = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[normalize-space()='Account Created!']")));

            Console.WriteLine("User successfully created new account.");

            iframeHandler.SwitchToDefaultContent();

            driver.FindElement(By.XPath("//a[@class='btn btn-primary']")).Click();

            Console.WriteLine("USER LOGGED IN.");

            iframeHandler.SwitchToDefaultContent();

            WebDriverWait waitnext1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Logout']")));

            Console.WriteLine("User on Home page.");
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.CssSelector("a[href = '/delete_account']")).Click();

            WebDriverWait waitnext2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[normalize-space()='Account Deleted!']")));
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.XPath("//a[@class='btn btn-primary']")).Click();

            Console.WriteLine("User account deleted.");

            driver.SwitchTo().DefaultContent();

        }

        [Test]
        public void TestSigninSuccess()
        {
            driver.FindElement(By.CssSelector("a[href='/login']")).Click();
            Console.WriteLine("User redirected to Signup/Login Page");

            driver.FindElement(By.CssSelector("input[data-qa='login-email']")).SendKeys("davidbrown@gmail.com");
            driver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("123456789");
            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            Console.WriteLine("User is navigated to home page.");

            WebDriverWait waitnext6 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitnext6.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Logout']")));

            Console.WriteLine("User on Home page.");
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.CssSelector("a[href='/delete_account']")).Click();

            WebDriverWait waitnext9 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitnext9.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[normalize-space()='Account Deleted!']")));
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.XPath("//a[@class='btn btn-primary']")).Click();

            Console.WriteLine("User account deleted.");

        }

        [Test]
        public void TestSigninFailure()
        {
            driver.FindElement(By.CssSelector("a[href='/login']")).Click();
            Console.WriteLine("User redirected to Signup/Login Page");

            driver.FindElement(By.CssSelector("input[data-qa='login-email']")).SendKeys("davidbrown@gmail.co");
            driver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("123456789");
            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            WebDriverWait waitnext10 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitnext10.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[normalize-space()='Your email or password is incorrect!']")));

            Console.WriteLine("Error occurred due to incorrect email/password.");

        }
    }
}