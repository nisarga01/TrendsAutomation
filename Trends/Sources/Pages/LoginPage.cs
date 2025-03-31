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
    public class LoginPage
    {
        IWebDriver _webDriver;


        [FindsBy(How = How.ClassName, Using = "google-login")]
        private IWebElement googleSelect;

        [FindsBy(How = How.CssSelector, Using = "#identifierId")]
        private IWebElement signInTextBox;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"identifierNext\"]/div/button")]
        private IWebElement nextButton;

        [FindsBy(How = How.Name, Using = "Passwd")]
        private IWebElement passwordTextBox;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"passwordNext\"]/div/button")]
        private IWebElement passwordNextButton;

        [FindsBy(How = How.ClassName, Using = "aZvCDf")]
        private IWebElement clickExistingEmail;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);
        }
        public WebDriverWait GetWebDriverWait()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
        }
        public void ClickLoginButton()
        {
            HomePage hp = new HomePage(_webDriver);
            GetWebDriverWait().Until(driver => hp.loginButton.Displayed && hp.loginButton.Enabled);
            hp.loginButton.Click();
        }
        public void ClickGoogleSelect()
        {
            GetWebDriverWait().Until(driver => googleSelect.Displayed && googleSelect.Enabled);
            googleSelect.Click();
        }
        public void EnterEmail(string email)
        {
            // Wait for Email input field and enter email using stored element
            GetWebDriverWait().Until(driver => signInTextBox.Displayed && signInTextBox.Enabled);
            signInTextBox.SendKeys(email);
        }
        public void ClickNextButton()
        {
            GetWebDriverWait().Until(driver => nextButton.Displayed && nextButton.Enabled);
            nextButton.Click();
        }
        public void EnterPassword(string password)
        {
            GetWebDriverWait().Until(driver => passwordTextBox.Displayed && passwordTextBox.Enabled);
            passwordTextBox.SendKeys(password);
        }
        public void ClickNextToSignIn()
        {
            GetWebDriverWait().Until(driver => passwordNextButton.Displayed && passwordNextButton.Enabled);
            passwordNextButton.Click();
        }
        public void ClickExistingEmail()
        {
            GetWebDriverWait().Until(driver => clickExistingEmail.Displayed && clickExistingEmail.Enabled);
            clickExistingEmail.Click();
        }
    }
}
    

