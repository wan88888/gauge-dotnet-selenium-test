using System;
using OpenQA.Selenium;

namespace WebAutomation.Framework.Driver
{
    public class Driver
    {
        private static readonly Lazy<Driver> LazyInstance = new Lazy<Driver>(() => new Driver());
        
        private IWebDriver _webDriver;
        private bool _isInitialized;

        private Driver()
        {
        }

        public static Driver Instance => LazyInstance.Value;

        public IWebDriver WebDriver
        {
            get
            {
                if (!_isInitialized)
                {
                    Initialize();
                }
                
                return _webDriver;
            }
        }

        public void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            _webDriver = WebDriverFactory.CreateDriver();
            _isInitialized = true;
        }

        public void Quit()
        {
            if (!_isInitialized)
            {
                return;
            }

            try
            {
                _webDriver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while quitting driver: {ex.Message}");
            }
            finally
            {
                _isInitialized = false;
                _webDriver = null;
            }
        }
    }
} 