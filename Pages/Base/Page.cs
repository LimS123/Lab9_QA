using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Pages.Base
{
    class Page
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IWebElement FindElementWithWaitElementExists(By locator, double seconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public IWebElement FindElementWithWaitElementToBeClickable(By locator, double seconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void SwitchToFrame(By frameLocator)
        {
            driver.SwitchTo().Frame(FindElement(frameLocator));
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
