using AutomationProject.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.PageObjects.AddAddressPage
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }
        [FindsBy(How = How.CssSelector, Using = "input[data-test='username']")]
        private IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-test='password']")]
        private IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='LOGIN']")]
        private IWebElement BtnSignIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h3[data-test='error']")]
        private IWebElement LblFailLoginMessage { get; set; }

      

        public string FailLoginMessageText => LblFailLoginMessage.Text;
        public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);
        public void LoginApplication(LoginBO loginBo)
        {
            TxtUserName.SendKeys(loginBo.UserName);
            TxtPassword.SendKeys(loginBo.Password);
            BtnSignIn.Click();
        }

        public void FillEmailAndSignIn(string email)
        {
            TxtUserName.SendKeys(email);
            BtnSignIn.Click();
        }

    }
}
