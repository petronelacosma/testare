using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.PageObjects.CheckoutOverview
{
    public class CheckoutOverview
    {
        private IWebDriver driver;

        public CheckoutOverview(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "h3[data-test='error']")]
        private IWebElement LblHeaderOverveaw { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='subheader']")]
        private IWebElement LblHeaderOverveaw1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn_section cart_button]")]
        private IWebElement BtnFinish { get; set; }

        public string SuccessfullyCreatedMessage => LblHeaderOverveaw1.Text;
        public string NotSuccessfullyCreatedMessage => LblHeaderOverveaw.Text;
        public CheckoutComplete.CheckoutComplete NavigateToAddressesPage()
        {
            BtnFinish.Click();
            return new CheckoutComplete.CheckoutComplete(driver);
        }
    }
}
