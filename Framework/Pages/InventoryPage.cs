using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Framework.Pages;

namespace WebAutomation.Pages
{
    public class InventoryPage : BasePage
    {
        // Locators
        private readonly By _productItems = By.ClassName("inventory_item");
        private readonly By _productTitle = By.ClassName("inventory_item_name");
        private readonly By _productPrice = By.ClassName("inventory_item_price");
        private readonly By _addToCartButton = By.CssSelector("button[id^='add-to-cart']");
        private readonly By _removeButton = By.CssSelector("button[id^='remove']");
        private readonly By _shoppingCartBadge = By.ClassName("shopping_cart_badge");
        private readonly By _shoppingCartLink = By.ClassName("shopping_cart_link");
        private readonly By _sortDropdown = By.ClassName("product_sort_container");
        private readonly By _menuButton = By.Id("react-burger-menu-btn");
        private readonly By _logoutLink = By.Id("logout_sidebar_link");

        protected override string PageUrl => "/inventory.html";

        public bool IsOnInventoryPage()
        {
            return Driver.Url.Contains("inventory.html");
        }

        public void AddProductToCart(string productName)
        {
            var products = Driver.FindElements(_productItems);
            
            foreach (var product in products)
            {
                var title = product.FindElement(_productTitle).Text;
                
                if (title == productName)
                {
                    product.FindElement(_addToCartButton).Click();
                    break;
                }
            }
        }

        public void RemoveProductFromCart(string productName)
        {
            var products = Driver.FindElements(_productItems);
            
            foreach (var product in products)
            {
                var title = product.FindElement(_productTitle).Text;
                
                if (title == productName)
                {
                    product.FindElement(_removeButton).Click();
                    break;
                }
            }
        }

        public void GoToShoppingCart()
        {
            Click(_shoppingCartLink);
        }

        public int GetCartItemCount()
        {
            try
            {
                return int.Parse(GetText(_shoppingCartBadge));
            }
            catch
            {
                return 0;
            }
        }

        public List<string> GetProductNames()
        {
            return Driver.FindElements(_productTitle).Select(e => e.Text).ToList();
        }

        public void SortProducts(string sortOption)
        {
            var select = new OpenQA.Selenium.Support.UI.SelectElement(Driver.FindElement(_sortDropdown));
            select.SelectByText(sortOption);
        }

        public void Logout()
        {
            Click(_menuButton);
            WaitForElementVisible(_logoutLink);
            Click(_logoutLink);
        }
    }
} 