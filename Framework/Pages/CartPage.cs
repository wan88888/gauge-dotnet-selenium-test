using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Framework.Pages;

namespace WebAutomation.Pages
{
    public class CartPage : BasePage
    {
        // Locators
        private readonly By _cartItems = By.ClassName("cart_item");
        private readonly By _itemName = By.ClassName("inventory_item_name");
        private readonly By _itemPrice = By.ClassName("inventory_item_price");
        private readonly By _removeButton = By.CssSelector("button[id^='remove']");
        private readonly By _continueShoppingButton = By.Id("continue-shopping");
        private readonly By _checkoutButton = By.Id("checkout");

        protected override string PageUrl => "/cart.html";

        public bool IsOnCartPage()
        {
            return Driver.Url.Contains("cart.html");
        }

        public List<string> GetCartItemNames()
        {
            return Driver.FindElements(_itemName).Select(e => e.Text).ToList();
        }

        public void RemoveItemFromCart(string itemName)
        {
            var items = Driver.FindElements(_cartItems);
            
            foreach (var item in items)
            {
                var name = item.FindElement(_itemName).Text;
                
                if (name == itemName)
                {
                    item.FindElement(_removeButton).Click();
                    break;
                }
            }
        }

        public int GetCartItemCount()
        {
            return Driver.FindElements(_cartItems).Count;
        }

        public void ContinueShopping()
        {
            Click(_continueShoppingButton);
        }

        public void Checkout()
        {
            Click(_checkoutButton);
        }

        public bool IsItemInCart(string itemName)
        {
            return GetCartItemNames().Contains(itemName);
        }
    }
} 