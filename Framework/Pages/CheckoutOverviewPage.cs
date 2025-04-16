using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Framework.Pages;

namespace WebAutomation.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        // Locators
        private readonly By _cartItems = By.ClassName("cart_item");
        private readonly By _itemName = By.ClassName("inventory_item_name");
        private readonly By _itemPrice = By.ClassName("inventory_item_price");
        private readonly By _subtotalLabel = By.ClassName("summary_subtotal_label");
        private readonly By _taxLabel = By.ClassName("summary_tax_label");
        private readonly By _totalLabel = By.ClassName("summary_total_label");
        private readonly By _cancelButton = By.Id("cancel");
        private readonly By _finishButton = By.Id("finish");

        protected override string PageUrl => "/checkout-step-two.html";

        public bool IsOnCheckoutOverviewPage()
        {
            return Driver.Url.Contains("checkout-step-two.html");
        }

        public List<string> GetCartItemNames()
        {
            return Driver.FindElements(_itemName).Select(e => e.Text).ToList();
        }

        public double GetSubtotal()
        {
            string subtotalText = GetText(_subtotalLabel);
            return ExtractPrice(subtotalText);
        }

        public double GetTax()
        {
            string taxText = GetText(_taxLabel);
            return ExtractPrice(taxText);
        }

        public double GetTotal()
        {
            string totalText = GetText(_totalLabel);
            return ExtractPrice(totalText);
        }

        private double ExtractPrice(string text)
        {
            // Extract price value from a string like "Item total: $29.99"
            string priceString = text.Split('$')[1].Trim();
            return double.Parse(priceString);
        }

        public void ClickCancel()
        {
            Click(_cancelButton);
        }

        public void ClickFinish()
        {
            Click(_finishButton);
        }

        public bool IsItemInCheckout(string itemName)
        {
            return GetCartItemNames().Contains(itemName);
        }
    }
} 