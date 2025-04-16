using WebAutomation.Framework.Driver;
using WebAutomation.Pages;

namespace WebAutomation.Steps
{
    public abstract class BaseSteps
    {
        protected Driver WebDriver => Driver.Instance;

        // 常用的页面对象可以放在基类中，让子类直接使用
        protected LoginPage CreateLoginPage() => new LoginPage();
        protected InventoryPage CreateInventoryPage() => new InventoryPage();
        protected CartPage CreateCartPage() => new CartPage();
        protected CheckoutInfoPage CreateCheckoutInfoPage() => new CheckoutInfoPage();
        protected CheckoutOverviewPage CreateCheckoutOverviewPage() => new CheckoutOverviewPage();
        protected CheckoutCompletePage CreateCheckoutCompletePage() => new CheckoutCompletePage();
    }
} 