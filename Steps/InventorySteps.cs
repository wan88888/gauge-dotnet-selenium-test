using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using WebAutomation.Pages;

namespace WebAutomation.Steps
{
    public class InventorySteps : BaseSteps
    {
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;

        public InventorySteps()
        {
            _inventoryPage = CreateInventoryPage();
            _cartPage = CreateCartPage();
        }

        [Step("Add product <productName> to cart")]
        public void AddProductToCart(string productName)
        {
            _inventoryPage.AddProductToCart(productName);
        }

        [Step("Cart should contain <count> items")]
        public void VerifyCartCount(string count)
        {
            int itemCount = int.Parse(count);
            _inventoryPage.GetCartItemCount().Should().Be(itemCount, $"Cart should contain {count} items");
        }

        [Step("Cart should contain 1 items")]
        public void VerifyCartContainsOneItem()
        {
            _inventoryPage.GetCartItemCount().Should().Be(1, "Cart should contain exactly one item");
        }

        [Step("Cart should contain 3 items")]
        public void VerifyCartContainsThreeItems()
        {
            _inventoryPage.GetCartItemCount().Should().Be(3, "Cart should contain exactly three items");
        }

        [Step("Go to shopping cart")]
        public void GoToShoppingCart()
        {
            _inventoryPage.GoToShoppingCart();
            _cartPage.IsOnCartPage().Should().BeTrue("User should be on cart page");
        }
    }
} 