using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trends.Sources.Pages
{
    public class HomePage
    {
        IWebDriver _webDriver;
        WebDriverWait _wait;

        [FindsBy(How = How.Name, Using = "searchVal")]
        private IWebElement globalSearch;

        [FindsBy(How = How.ClassName, Using = "ic-search")]
        private IWebElement globalSearchIcon;

        [FindsBy(How = How.Id, Using = "loginAjio")]
        public IWebElement loginButton;

        //[FindsBy(How = How.XPath, Using = "//div[@class='guest-header']//a[@aria-label='Sign Out']")]
        //private IWebElement clickSignOut;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);
        }
        public void Search(string search)
        {
            globalSearch.SendKeys(search);
            globalSearchIcon.Click();
        }
    }
}

