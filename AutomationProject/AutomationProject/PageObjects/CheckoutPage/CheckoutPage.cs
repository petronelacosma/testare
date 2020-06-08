using System;
using System.Collections.Generic;
using AutomationProject.PageObjects.ChackeoutPage.InputData;
using AutomationProject.PageObjects.CheckoutOverview;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace CheckoutPage
{
    public class CheckoutPage
    {
        private IWebDriver driver;

        public CheckoutPage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement TxtLastName { get; set; }


        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement TxtZipCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[class='btn_primary cart_button']")]
        private IWebElement BtnContinue { get; set; }
        public CheckoutOverview AddInformation(CheckoutPageBO addInformationCheckoutBO)
        {
            TxtFirstName.SendKeys(addInformationCheckoutBO.FirstName);
            TxtLastName.SendKeys(addInformationCheckoutBO.LastName);
            TxtZipCode.SendKeys(addInformationCheckoutBO.ZipCode);
            BtnContinue.Click();
            return new CheckoutOverview(driver);
        }

    }
}
