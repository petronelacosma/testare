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
using System.Threading;
using System.Threading.Tasks;

namespace AutomationProject
{
    [TestClass]
    public class AdaugareTests
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
        public void TEST()
        {
            List<string> lista_iteme = homePage.test();
            homePage.Apasa_Buton_Cart();
            cartPage = new CartPage(driver);
            Assert.IsTrue(cartPage.Verificare(lista_iteme));
        }

        [TestMethod]
        public void Should_Add_Successfully()
        {
            //homePage.ProdusClick(0);
            //Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));
            /*
            homePage.Init_Dict_Btn_Add();
            List<string> ItemNames = homePage.getItemNames();
            homePage.Apasa_Buton_Add(ItemNames[1]);
            homePage.Apasa_Buton_Add(ItemNames[2]);
            homePage.Init_Dict_Btn_Remove();
            Assert.AreEqual("REMOVE", homePage.getButtonRemoveText(ItemNames[1]));
            Assert.AreEqual("REMOVE", homePage.getButtonRemoveText(ItemNames[2]));*/
        }
        /*
        [TestMethod]
        public void Should_Add_Successfully()
            {
            homePage.Apasa_Buton_Add(0);
            homePage.Apasa_Buton_Add(1);
            homePage.Apasa_Buton_Add(2);
            Assert.AreEqual("REMOVE", homePage.getButtonRemoveText(0));
            Assert.AreEqual("REMOVE", homePage.getButtonRemoveText(1));
            Assert.AreEqual("REMOVE", homePage.getButtonRemoveText(2));
            Assert.AreEqual(3, homePage.getNrItemCart());
            }
         
        [TestMethod]
        public void Should_Remove_Successfully()
            {
            homePage.Apasa_Buton_Add(1);
            homePage.Apasa_Buton_Remove(0);
            Assert.AreEqual("ADD TO CART", homePage.getButtonAddText(1));
            }
       */
        [TestCleanup]
        public void CleanUp()
            {
            driver.Quit();
            }
            

    }
}
