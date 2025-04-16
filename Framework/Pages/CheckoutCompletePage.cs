using System;
using OpenQA.Selenium;
using WebAutomation.Framework.Pages;

namespace WebAutomation.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        // Locators
        private readonly By _completeHeader = By.ClassName("complete-header");
        private readonly By _completeText = By.ClassName("complete-text");
        private readonly By _backHomeButton = By.Id("back-to-products");

        protected override string PageUrl => "/checkout-complete.html";

        public bool IsOnCheckoutCompletePage()
        {
            return Driver.Url.Contains("checkout-complete.html");
        }

        public string GetCompleteHeaderText()
        {
            try
            {
                return IsElementDisplayed(_completeHeader) ? GetText(_completeHeader) : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get complete header text: {ex.Message}");
                return string.Empty;
            }
        }

        public string GetCompleteText()
        {
            try
            {
                return IsElementDisplayed(_completeText) ? GetText(_completeText) : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get complete text: {ex.Message}");
                return string.Empty;
            }
        }

        public void ClickBackHome()
        {
            Click(_backHomeButton);
        }

        public bool IsOrderCompleted()
        {
            var isOnCompletePage = IsOnCheckoutCompletePage();
            var headerText = GetCompleteHeaderText();
            
            Console.WriteLine($"Is on complete page: {isOnCompletePage}");
            Console.WriteLine($"Header text: '{headerText}'");
            
            if (!isOnCompletePage)
            {
                Console.WriteLine($"Current URL: {Driver.Url}");
            }
            
            // 修正条件以匹配当前实际的成功消息
            return isOnCompletePage && 
                   (!string.IsNullOrEmpty(headerText) && 
                    (headerText.Contains("Thank you for your order!") || // 完全匹配网站上的实际文本
                     headerText.Contains("THANK YOU") || 
                     headerText.Contains("COMPLETE") || 
                     headerText.Contains("SUCCESS") ||
                     headerText.Contains("Thank you")));
        }
    }
} 