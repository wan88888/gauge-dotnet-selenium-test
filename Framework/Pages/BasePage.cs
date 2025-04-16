using System;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using WebAutomation.Framework.Driver;
using WebAutomation.Framework.Config;

namespace WebAutomation.Framework.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        private readonly WebDriverWait _wait;
        private static readonly string BaseUrl = ConfigurationManager.GetString("baseUrl", "https://www.saucedemo.com");
        private static readonly int ElementTimeout = ConfigurationManager.GetInt("elementTimeout", 30);

        protected BasePage()
        {
            Driver = WebAutomation.Framework.Driver.Driver.Instance.WebDriver;
            _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ElementTimeout));
        }

        protected abstract string PageUrl { get; }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(BaseUrl + PageUrl);
        }

        protected IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected bool WaitForElementNotVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        protected void Click(By locator)
        {
            WaitForElementClickable(locator).Click();
        }

        protected void Type(By locator, string text)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return WaitForElementVisible(locator).Text;
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void WaitForPageLoad()
        {
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
} 