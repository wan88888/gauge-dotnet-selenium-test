using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using WebAutomation.Pages;

namespace WebAutomation.Steps
{
    public class CheckoutSteps : BaseSteps
    {
        private readonly CheckoutInfoPage _checkoutInfoPage;
        private readonly CheckoutOverviewPage _checkoutOverviewPage;
        private readonly CheckoutCompletePage _checkoutCompletePage;
        private readonly InventoryPage _inventoryPage;

        public CheckoutSteps()
        {
            _checkoutInfoPage = CreateCheckoutInfoPage();
            _checkoutOverviewPage = CreateCheckoutOverviewPage();
            _checkoutCompletePage = CreateCheckoutCompletePage();
            _inventoryPage = CreateInventoryPage();
        }

        [Step("Fill checkout information with <firstName>, <lastName>, <postalCode>")]
        public void FillCheckoutInfo(string firstName, string lastName, string postalCode)
        {
            _checkoutInfoPage.FillCheckoutInfo(firstName, lastName, postalCode);
            _checkoutOverviewPage.IsOnCheckoutOverviewPage().Should().BeTrue("User should be on checkout overview page");
        }

        [Step("Complete the order")]
        public void CompleteOrder()
        {
            _checkoutOverviewPage.ClickFinish();
            _checkoutCompletePage.IsOnCheckoutCompletePage().Should().BeTrue("User should be on checkout complete page");
        }

        [Step("Order should be completed successfully")]
        public void VerifyOrderCompleted()
        {
            _checkoutCompletePage.IsOrderCompleted().Should().BeTrue("Order should be completed successfully");
        }

        [Step("Return to home page")]
        public void ReturnToHomePage()
        {
            _checkoutCompletePage.ClickBackHome();
            _inventoryPage.IsOnInventoryPage().Should().BeTrue("User should be back on inventory page");
        }
    }
} 