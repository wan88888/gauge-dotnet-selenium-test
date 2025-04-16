using System;
using System.Threading;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using WebAutomation.Pages;

namespace WebAutomation.Steps
{
    public class SortingSteps : BaseSteps
    {
        private readonly InventoryPage _inventoryPage;
        private readonly LoginPage _loginPage;

        public SortingSteps()
        {
            _inventoryPage = CreateInventoryPage();
            _loginPage = CreateLoginPage();
        }

        [Step("Sort products by <sortOption>")]
        public void SortProducts(string sortOption)
        {
            try
            {
                // 确保我们在商品页面
                if (!_inventoryPage.IsOnInventoryPage())
                {
                    Console.WriteLine("Not on inventory page, attempting to navigate there");
                    _loginPage.Login("standard_user", "secret_sauce");
                    
                    // 等待页面加载
                    Thread.Sleep(1000);
                    
                    // 验证我们是否成功导航到库存页面
                    if (!_inventoryPage.IsOnInventoryPage())
                    {
                        Console.WriteLine($"Failed to navigate to inventory page. Current URL: {WebDriver.WebDriver.Url}");
                        
                        // 如果登录失败，再尝试一次直接导航
                        WebDriver.WebDriver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");
                        Thread.Sleep(1000);
                    }
                }
                
                try 
                {
                    Console.WriteLine($"Current URL: {WebDriver.WebDriver.Url}");
                    Console.WriteLine($"Sorting products by: {sortOption}");
                    _inventoryPage.SortProducts(sortOption);
                    Console.WriteLine("Products sorted successfully");
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine($"Sort dropdown not found: {ex.Message}");
                    // 尝试刷新页面后再试
                    WebDriver.WebDriver.Navigate().Refresh();
                    Thread.Sleep(1000);
                    _inventoryPage.SortProducts(sortOption);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during product sorting: {ex.Message}");
                throw;
            }
        }
    }
} 