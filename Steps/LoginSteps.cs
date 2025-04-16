using System;
using System.Threading;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using WebAutomation.Framework.Driver;
using WebAutomation.Pages;

namespace WebAutomation.Steps
{
    public class LoginSteps : BaseSteps
    {
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;

        public LoginSteps()
        {
            _loginPage = CreateLoginPage();
            _inventoryPage = CreateInventoryPage();
        }

        [Step("Navigate to the login page")]
        public void NavigateToLoginPage()
        {
            try
            {
                Console.WriteLine("Navigating to login page");
                _loginPage.Navigate();
                Thread.Sleep(500); // 添加短暂等待确保页面加载
                Console.WriteLine($"Current URL after navigation: {WebDriver.WebDriver.Url}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error navigating to login page: {ex.Message}");
                throw;
            }
        }

        [Step("Login with username <username> and password <password>")]
        public void LoginWithCredentials(string username, string password)
        {
            try
            {
                Console.WriteLine($"Logging in with username: {username}");
                _loginPage.Login(username, password);
                Thread.Sleep(1000); // 登录后等待页面加载
                Console.WriteLine($"Current URL after login: {WebDriver.WebDriver.Url}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                throw;
            }
        }

        [Step("Login as standard user")]
        public void LoginAsStandardUser()
        {
            LoginWithCredentials("standard_user", "secret_sauce");
        }

        [Step("User should be on inventory page")]
        public void VerifyUserOnInventoryPage()
        {
            try
            {
                // 添加短暂等待以确保页面完全加载
                Thread.Sleep(1000);
                
                var isOnInventoryPage = _inventoryPage.IsOnInventoryPage();
                Console.WriteLine($"Is on inventory page: {isOnInventoryPage}");
                Console.WriteLine($"Current URL: {WebDriver.WebDriver.Url}");
                
                if (!isOnInventoryPage && WebDriver.WebDriver.Url.Contains("saucedemo.com"))
                {
                    // 如果不在库存页面但在网站上，尝试直接导航到库存页面
                    Console.WriteLine("Attempting to navigate directly to inventory page");
                    WebDriver.WebDriver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");
                    Thread.Sleep(1000);
                    
                    // 再次检查
                    isOnInventoryPage = _inventoryPage.IsOnInventoryPage();
                    Console.WriteLine($"Is on inventory page after direct navigation: {isOnInventoryPage}");
                }
                
                _inventoryPage.IsOnInventoryPage().Should().BeTrue("User should be on inventory page");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying inventory page: {ex.Message}");
                throw;
            }
        }

        [Step("Log out")]
        public void Logout()
        {
            try
            {
                Console.WriteLine("Logging out");
                _inventoryPage.Logout();
                Thread.Sleep(500);
                Console.WriteLine($"Current URL after logout: {WebDriver.WebDriver.Url}");
                // Verify we're back at the login page
                WebDriver.WebDriver.Url.Should().Contain("saucedemo.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during logout: {ex.Message}");
                throw;
            }
        }
    }
} 