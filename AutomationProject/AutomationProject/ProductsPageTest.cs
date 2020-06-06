using System;
using System.Threading;
using AutomationProject.PageObjects.AddAddressPage;
using AutomationProject.PageObjects.HomePage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationProject
{
    [TestClass]
    public class ProductsPageTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginPage(driver);
            loginPage.LoginApplication(new LoginBO());
            homePage = new HomePage(driver);
            
         }

        [TestMethod]
        public void Prodact0_Page_Load_Succsesfuly()
        {
          string s= driver.FindElement(By.Id("item_0_title_link")).Text;
    
            homePage.ProdusClick(0);
            Thread.Sleep(2000);
            string s1 = driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text;
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text.Equals(s));

        }
        [TestMethod]
        public void RemoveButton_ProdactPage0()
        {
            
            homePage.ProdusClick(0);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));

        }

        [TestMethod]
        public void Prodact1_Page_Load_Succsesfuly()
        {
            string s = driver.FindElement(By.Id("item_1_title_link")).Text;

            homePage.ProdusClick(1);
            Thread.Sleep(2000);
            string s1 = driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text;
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text.Equals(s));

        }
        [TestMethod]
        public void RemoveButton_ProdactPage1()
        {


            homePage.ProdusClick(1);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));

        }

        [TestMethod]
        public void Prodact2_Page_Load_Succsesfuly()
        {
            string s = driver.FindElement(By.Id("item_2_title_link")).Text;

            homePage.ProdusClick(2);
            Thread.Sleep(2000);
            string s1 = driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text;
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text.Equals(s));

        }
        [TestMethod]
        public void RemoveButton_ProdactPage2()
        {


            homePage.ProdusClick(2);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));

        }
        [TestMethod]
        public void Prodact3_Page_Load_Succsesfuly()
        {
            string s = driver.FindElement(By.Id("item_3_title_link")).Text;

            homePage.ProdusClick(3);
            Thread.Sleep(2000);
            string s1 = driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text;
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text.Equals(s));

        }
        [TestMethod]
        public void RemoveButton_ProdactPage3()
        {


            homePage.ProdusClick(3);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));

        }
        [TestMethod]
        public void Prodact4_Page_Load_Succsesfuly()
        {
            string s = driver.FindElement(By.Id("item_4_title_link")).Text;

            homePage.ProdusClick(4);
            Thread.Sleep(2000);
            string s1 = driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text;
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text.Equals(s));

        }
        [TestMethod]
        public void RemoveButton_ProdactPage05()
        {


            homePage.ProdusClick(5);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));

        }

        [TestMethod]
        public void Prodact5_Page_Load_Succsesfuly()
        {
            string s = driver.FindElement(By.Id("item_5_title_link")).Text;

            homePage.ProdusClick(5);
            Thread.Sleep(2000);
            string s1 = driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text;
            Assert.IsTrue(driver.FindElement(By.CssSelector("div[class='inventory_details_name'")).Text.Equals(s));

        }
        [TestMethod]
        public void RemoveButton_ProdactPage5()
        {


            homePage.ProdusClick(5);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("button[class='btn_secondary btn_inventory']")).Text.Equals("REMOVE"));

        }


        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
