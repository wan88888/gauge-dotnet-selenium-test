using OpenQA.Selenium;
using WebAutomation.Framework.Pages;

namespace WebAutomation.Pages
{
    public class CheckoutInfoPage : BasePage
    {
        // Locators
        private readonly By _firstNameField = By.Id("first-name");
        private readonly By _lastNameField = By.Id("last-name");
        private readonly By _postalCodeField = By.Id("postal-code");
        private readonly By _continueButton = By.Id("continue");
        private readonly By _cancelButton = By.Id("cancel");
        private readonly By _errorMessage = By.CssSelector("[data-test='error']");

        protected override string PageUrl => "/checkout-step-one.html";

        public bool IsOnCheckoutInfoPage()
        {
            return Driver.Url.Contains("checkout-step-one.html");
        }

        public void EnterFirstName(string firstName)
        {
            Type(_firstNameField, firstName);
        }

        public void EnterLastName(string lastName)
        {
            Type(_lastNameField, lastName);
        }

        public void EnterPostalCode(string postalCode)
        {
            Type(_postalCodeField, postalCode);
        }

        public void ClickContinue()
        {
            Click(_continueButton);
        }

        public void ClickCancel()
        {
            Click(_cancelButton);
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(_errorMessage);
        }

        public string GetErrorMessageText()
        {
            return GetText(_errorMessage);
        }

        public void FillCheckoutInfo(string firstName, string lastName, string postalCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterPostalCode(postalCode);
            ClickContinue();
        }
    }
} 