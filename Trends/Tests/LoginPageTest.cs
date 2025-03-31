using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trends.Drivers;
using Trends.Sources.Pages;

namespace Trends.Tests
{
    public class LoginPageTest:Driver
    {
        [Test]
        public void NewAccountSignIn()
        {
            LoginPage lp = new LoginPage(_driver);
            _driver.Navigate().GoToUrl("https://www.ajio.com/");

            lp.ClickLoginButton();
            lp.ClickGoogleSelect();

            // Store the main window handle before switching
            string mainWindow = _driver.CurrentWindowHandle;

            // Wait until a new tab opens
            lp.GetWebDriverWait().Until(driver => driver.WindowHandles.Count > 1);

            // Switch to the new tab (Google login)
            foreach (string handle in _driver.WindowHandles)
            {
                if (handle != mainWindow)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
            }
            lp.EnterEmail("nisargahathwar@gmail.com");
            lp.ClickNextButton();
            lp.EnterPassword("Nisu@01022001");
            lp.ClickNextToSignIn();
            Thread.Sleep(4000);
        }
        [Test]
        public void ExistingAccountSignIn()
        {
            LoginPage lp = new LoginPage(_driver);
            _driver.Navigate().GoToUrl("https://www.ajio.com/");

            lp.ClickLoginButton();
            lp.ClickGoogleSelect();

            // Store the main window handle before switching
            string mainWindow = _driver.CurrentWindowHandle;

            // Wait until a new tab opens
            lp.GetWebDriverWait().Until(driver => driver.WindowHandles.Count > 1);

            // Switch to the new tab (Google login)
            foreach (string handle in _driver.WindowHandles) // ❌ Fix: Don't use lp.GetWebDriverWait().WindowHandles
            {
                if (handle != mainWindow)
                {
                    _driver.SwitchTo().Window(handle); // ❌ Fix: Use _driver, not _webDriver
                    break;
                }
            }
            lp.ClickExistingEmail();

            Thread.Sleep(4000); // ❌ Avoid if possible
        }

    }
}
