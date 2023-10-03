using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using SauceLabs.utilities;

namespace SauceLabs.tests
{
    public class Tests : Base
    {

        [Test]
        public void TestLogin()
        {
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();                   
            Console.WriteLine("Test One Pass successful..");
        
            driver.FindElement(By.CssSelector(".MuiButtonBase-root.MuiButton-root.MuiButton-text.MuiButton-textDark.MuiButton-sizeMedium.MuiButton-textSizeMedium.MuiButton-disableElevation.MuiButton-root.MuiButton-text.MuiButton-textDark.MuiButton-sizeMedium.MuiButton-textSizeMedium.MuiButton-disableElevation.css-zaj0tr")).Click();

            Console.WriteLine("Test Two running successful..");
        }

    }
}