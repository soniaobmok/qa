using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;


namespace laba3
{
    static class DriverHelper
    {
        public static IWebDriver GetChromeDriverForSite(string siteURL, string waitingElXpath)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(siteURL);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));

            //wait.Until(driver => driver.FindElement(By.XPath(waitingElXpath)));

            return driver;
        }
    }
}
