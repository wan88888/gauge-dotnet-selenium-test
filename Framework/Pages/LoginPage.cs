using OpenQA.Selenium;
using WebAutomation.Framework.Pages;

namespace WebAutomation.Pages
{
    public class LoginPage : BasePage
    {
        // Locators
        private readonly By _usernameField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.CssSelector("[data-test='error']");

        protected override string PageUrl => "/";

        public void EnterUsername(string username)
        {
            Type(_usernameField, username);
        }

        public void EnterPassword(string password)
        {
            Type(_passwordField, password);
        }

        public void ClickLogin()
        {
            Click(_loginButton);
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(_errorMessage);
        }

        public string GetErrorMessageText()
        {
            return GetText(_errorMessage);
        }

        public void Login(string username, string password)
        {
            Navigate();
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
} 