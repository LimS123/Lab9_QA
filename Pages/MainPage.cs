using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Pages
{
    class MainPage : Base.Page
    {
        private By RegInBtnLocator = By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/main/app-toolbar/section/div[1]/button[2]");
        private By submitBtnLocator = By.CssSelector("#mat-dialog-0 > demo-credentials > pro-dialog > mat-card > mat-card-content > div > form > button");
        private By windowWithMessageAboutSettingUpTwoFactorAuthenticationLocator = By.
            XPath("//div[@class = 'el-dialog__wrapper traderbox-dialog modal-mfa-notify coinup']" +
                "//i[@class = 'el-dialog__close el-icon el-icon-close']");

        private By coinsViewOfDemoAccLocator = By.XPath("//div[@class = 'group']/div[@class = 'title primary-text']");
        private By startNumberOfDotsLocator = By.
            XPath("//span[contains(text(),'DOT') and @class = 'title primary-text']/ancestor::tr//span[@class = 'primary-text']");
        private By searchingForAllPolkadotTradingPairsLocator = By.XPath("//div[@class = 'input']//input[@type = 'text']");
        private By choosingDotBtcTradingPairLocator = By.XPath("//div[@class = 'ticker primary-text']//span[contains(text(),'DOT/BTC')]");
        private By inputingNumberOfDotsLocator = By.XPath("//div[@class = 'order-tab']//div[@class = 'quantity-block']//input[@type = 'text']");
        private By submitingCurrnecyExchangeBtnLocator = By.XPath("//div[@class = 'footer primary-bg light']/div[@class = 'button green']");
        private By finishNumberOfDotsLocator = By.
                XPath("//span[contains(text(),'DOT') and @class = 'title primary-text']/ancestor::tr//span[@class = 'primary-text']");

        private By iframeLocator = By.XPath("//iframe[starts-with(@id, 'tradingview')]");
        private By fullscreenModLocator = By.Id("header-toolbar-fullscreen");
        private By exitFullscreenButtonLocator = By.ClassName("tv-exit-fullscreen-button");


        public MainPage(IWebDriver driver) : base(driver)
        {
        }


        public void RegIn()
        {
            IWebElement logInBtn = FindElement(RegInBtnLocator);
            logInBtn.Click();
        }
        public void SubmitAuthorization()
        {
            IWebElement submitBtn = FindElement(submitBtnLocator);
            submitBtn.Click();
        }
        public void CloseWindowWithMessageAboutSettingUpTwoFactorAuthentication()
        {
            IWebElement closeWindowWithMessageAboutSettingUpTwoFactorAuthentication =
                FindElementWithWaitElementToBeClickable(windowWithMessageAboutSettingUpTwoFactorAuthenticationLocator, 10);
            closeWindowWithMessageAboutSettingUpTwoFactorAuthentication.Click();
        }


        public void ViewCoinsOfDemoAcc()
        {
            IWebElement viewCoinsOfDemoAcc = FindElementWithWaitElementToBeClickable(coinsViewOfDemoAccLocator, 30);
            viewCoinsOfDemoAcc.Click();
        }
        public string GetExpectedNumberOfDots(int testValueForDots)
        {
            string startNumberOfDots = FindElementWithWaitElementExists(startNumberOfDotsLocator, 30).Text;
            int dotIndex = startNumberOfDots.IndexOf(".");
            string startNumberOfDotsBeforeDotIndex = startNumberOfDots.Substring(0, dotIndex);
            return Convert.ToString(Convert.ToInt32(startNumberOfDotsBeforeDotIndex) + testValueForDots);
        }
        public void SearchForAllPolkadotTradingPairs()
        {
            IWebElement searchForAllPolkadotTradingPairs = FindElementWithWaitElementExists(searchingForAllPolkadotTradingPairsLocator, 120);
            searchForAllPolkadotTradingPairs.SendKeys("dot");
        }
        public void ChooseDotBtcTradingPair()
        {
            IWebElement chooseDotBtcTradingPair = FindElementWithWaitElementToBeClickable(choosingDotBtcTradingPairLocator, 240);
            chooseDotBtcTradingPair.Click();
        }
        public void InputNumberOfDots(string testValueForDots)
        {
            IWebElement inputNumberOfDots = FindElementWithWaitElementExists(inputingNumberOfDotsLocator, 240);
            inputNumberOfDots.SendKeys(Convert.ToString(testValueForDots));
        }
        public void SubmitCurrnecyExchange()
        {
            IWebElement submitCurrnecyExchangeBtn = FindElementWithWaitElementToBeClickable(submitingCurrnecyExchangeBtnLocator, 120);
            submitCurrnecyExchangeBtn.Click();
        }
        public string GetFinishNumberOfDots()
        {
            Task.Delay(5000).Wait();
            string finishNumberOfDots = FindElementWithWaitElementExists(finishNumberOfDotsLocator, 120).Text;
            int dotIndex = finishNumberOfDots.IndexOf(".");
            return finishNumberOfDots.Substring(0, dotIndex);
        }


        public void OpenFullscreenMod()
        {
            SwitchToFrame(iframeLocator);
            IWebElement fullscreenMod = FindElementWithWaitElementToBeClickable(fullscreenModLocator, 30);
            fullscreenMod.Click();
        }
        public bool GetComparisonOfExpectedTextAndRealText()
        {
            IWebElement realTextInFullscreenMod = FindElementWithWaitElementExists(exitFullscreenButtonLocator, 30);
            if (realTextInFullscreenMod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CloseFullscreenMod()
        {
            IWebElement fullscreenMod = FindElementWithWaitElementToBeClickable(exitFullscreenButtonLocator, 30);
            fullscreenMod.Click();
            SwitchToDefaultContent();
        }
    }
}
