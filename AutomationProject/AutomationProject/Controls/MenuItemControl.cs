using AutomationProject.PageObjects.AddAddressPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace AutomationProject.Controls
{

    public class MenuItemControl
    {
        public IWebDriver driver;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='bm-burger-button']")]
        private IWebElement BtnMenu { get; set; }
    }


    public class LoggedInMenuItemControl : MenuItemControl
    {
        [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
        private IWebElement BtnAllItems { get; set; }

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        private IWebElement BtnAbout { get; set; }

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        private IWebElement LblLogout { get; set; }

        [FindsBy(How = How.Id, Using = "reset_sidebar_link")]
        private IWebElement LblRese { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn_primary btn_inventory]")]
        private IWebElement buttons { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='shopping_cart_link fa-layers fa-fw]")]
        private IWebElement BtnFinish { get; set; }

        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {

        }
     /*   public string UserEmailMessage => LblUserEmail.Text;
        public bool UserEmailDislyed => LblUserEmail.Displayed;*/

    }
}
