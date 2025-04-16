using System;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using WebAutomation.Framework.Config;

namespace WebAutomation.Framework.Driver
{
    public class WebDriverFactory
    {
        private static readonly string BrowserType = ConfigurationManager.GetString("browser", "chrome");
        private static readonly bool Headless = ConfigurationManager.GetBool("headless", false);

        public static IWebDriver CreateDriver()
        {
            IWebDriver driver = BrowserType.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => CreateFirefoxDriver(),
                "edge" => CreateEdgeDriver(),
                _ => CreateChromeDriver()
            };

            // Configure timeouts
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationManager.GetInt("elementTimeout", 30));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationManager.GetInt("pageLoadTimeout", 60));
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationManager.GetInt("scriptTimeout", 30));
            
            driver.Manage().Window.Maximize();
            
            return driver;
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            
            if (Headless)
            {
                options.AddArgument("--headless=new");
            }
            
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            
            // Add additional Chrome options for better stability and performance
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-gpu");
            
            // Disable save password prompt
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            
            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions();
            
            if (Headless)
            {
                options.AddArgument("--headless");
            }
            
            // Firefox specific settings
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-gzip");
            
            return new FirefoxDriver(options);
        }

        private static IWebDriver CreateEdgeDriver()
        {
            var options = new EdgeOptions();
            
            if (Headless)
            {
                options.AddArgument("--headless");
            }
            
            // Edge specific options
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            
            return new EdgeDriver(options);
        }
    }
} 