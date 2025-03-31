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
            //Assert.True(_driver.Title.Contains("bags"));
        }
    }
} 
    

