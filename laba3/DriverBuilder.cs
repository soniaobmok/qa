using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;


namespace laba3
{
    static class DriverBuilder
    {
        public static IWebDriver GetDriverFromUrlAndTarget(string url, string target)
        {
            IWebDriver driver = new FirefoxDriver();
            driver
                .Navigate()
                .GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath(target)));

            return driver;
        }
    }
}
