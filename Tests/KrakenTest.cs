using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UnitTest.Pages;
using UnitTest.Pages.Base;

namespace UnitTest
{
    public class KrakenTest
    {
        private IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;

        private const string ExpectedFavoritedMarketName = "ETH/USD";
        MainPage mainPage;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Size = new Size(1920, 1080);
            _webDriver.Navigate().GoToUrl("https://demo-futures.kraken.com/futures/PI_ETHUSD");

            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(35));

            mainPage = new MainPage(_webDriver);
            mainPage.RegIn();
            mainPage.SubmitAuthorization();
            mainPage.CloseWindowWithMessageAboutSettingUpTwoFactorAuthentication();
        }
        [Test]
        public void AddMarketToFavoriteTest()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var mostTradedMarketsButton = _webDriver.FindElement(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/main/app-toolbar/market-dropdowns/div[1]/button"));
            mostTradedMarketsButton.Click();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var addToFavoritesButton = _webDriver.FindElement(By.CssSelector("#cdk-overlay-19 > div > div > market-picker > cdk-virtual-scroll-viewport > div.cdk-virtual-scroll-content-wrapper > market-picker-ticker:nth-child(1) > div.icon.global__text.global__text-body > fa-icon > svg"));
            addToFavoritesButton.Click();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var favoriteMarketsButton = _webDriver.FindElement(By.CssSelector("#cdk-overlay-19 > div > div > market-picker > div.assets > div"));
            favoriteMarketsButton.Click();

            String actualFavoritedMarketName = _webDriver.FindElements(By.CssSelector("#cdk-overlay-19 > div > div > market-picker > cdk-virtual-scroll-viewport > div.cdk-virtual-scroll-content-wrapper > market-picker-ticker:nth-child(1) > div.maturity.global__text.global__text-subheading"))[1].Text;
            Assert.AreEqual(ExpectedFavoritedMarketName, actualFavoritedMarketName);

        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}