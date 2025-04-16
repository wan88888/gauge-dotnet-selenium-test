using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using WebAutomation.Pages;

namespace WebAutomation.Steps
{
    public class CartSteps : BaseSteps
    {
        private readonly CartPage _cartPage;
        private readonly CheckoutInfoPage _checkoutInfoPage;

        public CartSteps()
        {
            _cartPage = CreateCartPage();
            _checkoutInfoPage = CreateCheckoutInfoPage();
        }

        [Step("Cart should contain product <productName>")]
        public void VerifyCartContainsProduct(string productName)
        {
            _cartPage.IsItemInCart(productName).Should().BeTrue($"Cart should contain {productName}");
        }

        [Step("Proceed to checkout")]
        public void ProceedToCheckout()
        {
            _cartPage.Checkout();
            _checkoutInfoPage.IsOnCheckoutInfoPage().Should().BeTrue("User should be on checkout info page");
        }
    }
} 