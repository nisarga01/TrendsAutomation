using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace Trends.Drivers
{
    public class Driver
    {
        public IWebDriver _driver;
        [SetUp]
        public void initScript()
        {
            // ✅ Ensure WebDriver matches Chrome version
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

            // ✅ Set Chrome options
            ChromeOptions options = new ChromeOptions();

            // Use an existing Chrome profile to stay logged in
            options.AddArgument(@"--user-data-dir=C:\Users\ADMIN\AppData\Local\Google\Chrome\User Data\Default");
            options.AddArgument("--profile-directory=Default");

            //// Remove saved login sessions by clearing user data
            //string chromeUserData = @"C:\Users\ADMIN\AppData\Local\Google\Chrome\User Data\Default";
            //if (Directory.Exists(chromeUserData))
            //{
            //    Directory.Delete(chromeUserData, true);
            //}
            //// Use fresh Chrome profile
            //options.AddArgument("--user-data-dir=" + chromeUserData);

            // Disable automation flags to prevent Google from detecting Selenium
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            // Start Chrome maximized
            options.AddArgument("--start-maximized");

            // ✅ Pass options to ChromeDriver
            _driver = new ChromeDriver(options);
        }
        [TearDown]
        public void Cleanup()
        {
            if (_driver != null)
            {
                _driver.Dispose();
                Thread.Sleep(3000);// ✅ Close the browser after test execution
            }
        }
    }
} 
