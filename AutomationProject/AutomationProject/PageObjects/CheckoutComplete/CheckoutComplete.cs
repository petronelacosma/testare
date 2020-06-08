using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.PageObjects.CheckoutComplete
{
    public class CheckoutComplete
    {
        private IWebDriver driver;

        public CheckoutComplete(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='subheader']")]
        private IWebElement LblHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h2[class='complete-header']")]
        private IWebElement LblMeassage { get; set; }

      
    }
}
