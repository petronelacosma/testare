using AutomationProject.PageObjects.AddAddressPage;
using AutomationProject.PageObjects.CartPage;
using AutomationProject.PageObjects.ChackeoutPage.InputData;
using AutomationProject.PageObjects.ChackoutComplete;
using AutomationProject.PageObjects.ChackoutOverveaw;
using AutomationProject.PageObjects.HomePage;
using CheckoutPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationProject
{
    [TestClass]
    public class CheckoutTest
    {
        private IWebDriver driver;
        private ChackoutComplete addCheckoutPage;
        private CheckoutPage.CheckoutPage checkoutPage;
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            //login
            var loginPage = new LoginPage(driver);
            loginPage.LoginApplication(new LoginBO());
            //homepage
            var inventory = new HomePage(driver);
            inventory.CartPage();
            //cart
            var cart = new CartPage(driver);
            cart.ClickCheckout();
            //nu e fct in homepage care sa ma duca la cart
            checkoutPage = new CheckoutPage.CheckoutPage(driver);
            //checkout
            /*var checkoutPage = cart.NavigateToAddAddressPage();
            //checkout overview

            var checkoutOverview = new ChackoutOverveaw(driver);
            addCheckoutPage = checkoutOverview.NavigateToAddressesPage();*/
        }

        [TestMethod]
        public void Checkout_Page_Test()
        {
            var addCheckoutPageBo = new CheckoutPageBO
            {
                FirstName = "test",
                ZipCode = "test"
            };
            var addCheckoutDetails = checkoutPage.AddInformation(addCheckoutPageBo);
            Thread.Sleep(2000);
            Assert.AreEqual("Checkout: Overview", addCheckoutDetails.SuccessfullyCreatedMessage);
        }

        [TestMethod]
        public void Should_Not_Go_Next_Empty_FirstName()
        {
            var addCheckoutPageBo = new CheckoutPageBO
            {
                FirstName = "",
                ZipCode = "test"
            };
            var addCheckoutDetails = checkoutPage.AddInformation(addCheckoutPageBo);
            Thread.Sleep(2000);
            Assert.AreEqual("Error: First Name is required", addCheckoutDetails.NotSuccessfullyCreatedMessage);
        }

        [TestMethod]
        public void Should_Not_Go_Next_Empty_LastName()
        {
            var addCheckoutPageBo = new CheckoutPageBO
            {
                FirstName = "test",
                LastName = "",
                ZipCode = "test"
            };
            var addCheckoutDetails = checkoutPage.AddInformation(addCheckoutPageBo);
            Thread.Sleep(2000);
            Assert.AreEqual("Error: Last Name is required", addCheckoutDetails.NotSuccessfullyCreatedMessage);
        }

        [TestMethod]
        public void Should_Not_Go_Next_Empty_ZIPcode()
        {
            var addCheckoutPageBo = new CheckoutPageBO
            {
                FirstName = "test",
                LastName = "test",
                ZipCode = ""
            };
            var addCheckoutDetails = checkoutPage.AddInformation(addCheckoutPageBo);
            Thread.Sleep(2000);
            Assert.AreEqual("Error: Postal Code is required", addCheckoutDetails.NotSuccessfullyCreatedMessage);
        }

        [TestMethod]
        public void Should_Not_Go_Next_Empty_Form()
        {
            var addCheckoutPageBo = new CheckoutPageBO
            {
                FirstName = "",
                LastName = "",
                ZipCode = ""
            };
            var addCheckoutDetails = checkoutPage.AddInformation(addCheckoutPageBo);
            Thread.Sleep(2000);
            Assert.AreEqual("Error: First Name is required", addCheckoutDetails.NotSuccessfullyCreatedMessage);
        }


        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}