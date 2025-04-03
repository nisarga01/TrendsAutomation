using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trends.Drivers;
using Trends.Sources.Pages;

namespace Trends.Tests
{
    public class HomePageTest:Driver
    {
        [Test]
        public void SearchBook()
        {
            HomePage homePage = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://www.ajio.com/");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            homePage.Search("bags");

            //manual method to take screenshot for each test
            // ✅ Capture Smart UI screenshot for visual testing
            //((IJavaScriptExecutor)_driver).ExecuteScript("smartui.takeScreenshot=trends_search_results");

            //Assert.True(_driver.Title.Contains("bags"));
            //call the smartuiscreenshot class from the driver class
            CaptureScreenShot("search-bar");
        }
    }
} 
    

