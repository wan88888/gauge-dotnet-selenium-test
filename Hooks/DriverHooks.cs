using System;
using Gauge.CSharp.Lib.Attribute;
using WebAutomation.Framework.Driver;

namespace WebAutomation.Hooks
{
    public class DriverHooks
    {
        [BeforeSuite]
        public void BeforeSuite()
        {
            Console.WriteLine("Setting up WebDriver for the test suite");
            Driver.Instance.Initialize();
        }

        [AfterSuite]
        public void AfterSuite()
        {
            Console.WriteLine("Closing WebDriver after the test suite");
            Driver.Instance.Quit();
        }

        [BeforeSpec]
        public void BeforeSpec()
        {
            Console.WriteLine("Setting up for the specification");
            try
            {
                Driver.Instance.WebDriver.Manage().Cookies.DeleteAllCookies();
                Driver.Instance.WebDriver.Navigate().GoToUrl("https://www.saucedemo.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BeforeSpec: {ex.Message}");
            }
        }

        [AfterSpec]
        public void AfterSpec()
        {
            Console.WriteLine("Cleaning up after the specification");
            try
            {
                Driver.Instance.WebDriver.Manage().Cookies.DeleteAllCookies();
                Driver.Instance.WebDriver.Navigate().GoToUrl("about:blank");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AfterSpec: {ex.Message}");
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Setting up for the scenario");
            try
            {
                Driver.Instance.WebDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BeforeScenario: {ex.Message}");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Cleaning up after the scenario");
            try
            {
                Driver.Instance.WebDriver.Manage().Cookies.DeleteAllCookies();
                Driver.Instance.WebDriver.Navigate().GoToUrl("about:blank");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AfterScenario: {ex.Message}");
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {
            // Optional hook before each step
        }

        [AfterStep]
        public void AfterStep()
        {
            // Optional hook after each step
        }
    }
} 