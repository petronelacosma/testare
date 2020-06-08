using AutomationProject.Controls;
using AutomationProject.PageObjects.AddAddressPage;
using AutomationProject.PageObjects.CartPage;
using AutomationProject.PageObjects.HomePage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject
{
    [TestClass]
    public class AddToCartTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;
        private CartPage cartPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/index.html");
            var menuItemControl = new LoggedInMenuItemControl(driver);
            loginPage = new LoginPage(driver);
            loginPage.LoginApplication(new LoginBO());
            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void Should_Change_Add_Buttons_Succesfully()
        {
            homePage.Init_Buttons();

            homePage.Press_Button_Nr(1);
            homePage.Press_Button_Nr(3);
            homePage.Press_Button_Nr(5);

            Assert.IsTrue(homePage.Button_Nr_Is_Remove(1));
            Assert.IsTrue(homePage.Button_Nr_Is_Remove(3));
            Assert.IsTrue(homePage.Button_Nr_Is_Remove(5));
            Assert.IsTrue(homePage.Button_Nr_Is_Add(0));
            Assert.IsTrue(homePage.Button_Nr_Is_Add(2));
            Assert.IsTrue(homePage.Button_Nr_Is_Add(4));
        }

        [TestMethod]
        public void Should_Change_Remove_Buttons_Succesfully()
        {
            homePage.Init_Buttons();

            homePage.Press_Button_Nr(0);
            homePage.Press_Button_Nr(3);
            homePage.Press_Button_Nr(4);

            homePage.Press_Button_Nr(3);
            homePage.Press_Button_Nr(4);

            Assert.IsTrue(homePage.Button_Nr_Is_Add(4));
            Assert.IsTrue(homePage.Button_Nr_Is_Add(3));
            Assert.IsTrue(homePage.Button_Nr_Is_Remove(0));
        }

        [TestMethod]

        public void Cart_Nr_Displayed_Correctly()
        {
            homePage.Init_Buttons();

            homePage.Press_Button_Nr(1);
            homePage.Press_Button_Nr(5);
            homePage.Press_Button_Nr(2);

            Assert.AreEqual(3, homePage.getNrItemCart());

            homePage.Press_Button_Nr(5);
            homePage.Press_Button_Nr(2);

            Assert.AreEqual(1, homePage.getNrItemCart());

        }

        [TestMethod]
        public void Correct_Items_In_Cart()
        {
            homePage.Init_Buttons();
            List<string> Item_List = homePage.Add_Some_Items();

            homePage.Press_Cart_Button();
            cartPage = new CartPage(driver);

            Assert.IsTrue(cartPage.Are_Same_Items(Item_List));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }      
}
