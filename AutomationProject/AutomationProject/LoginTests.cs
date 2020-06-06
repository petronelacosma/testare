using System.Threading;
using AutomationProject;
using AutomationProject.Controls;
using AutomationProject.PageObjects.AddAddressPage;
using AutomationProject.PageObjects.HomePage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Html5;

[TestClass]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;

    [TestInitialize]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/index.html");
        loginPage = new LoginPage(driver);
    }

    [TestMethod]
    public void Should_Login_Successfully_Standard_User()
    {
        loginPage.LoginApplication(new LoginBO());
        var homePage = new LoginPage(driver);
        //IWebStorage webStorage = (IWebStorage)new Augmenter().augment(driver);
        //ISessionStorage sessionStorage = webStorage.getSessionStorage();
        //IWebStorage webStorage = (IWebStorage)driver;
        //webStorage.getSessionStorage().clear();
        //ISessionStorage sesh = webStorage.SessionStorage;
        // var username = sesh.GetItem("session-username");
        // var ProductName = sessionStorage.getItem('ProductName');
        //Assert.IsTrue(homePage.menuItemControl.Equals("standard_user"));

        // Assert.AreEqual("standard_user", username);

        // Assert.IsTrue(homePage.menuItemControl.UserEmailDislyed);
        //Assert.IsTrue(homePage.menuItemControl.UserEmailDislyed);
        Assert.IsTrue(driver.FindElement(By.Id("shopping_cart_container")).Displayed);
    }



    [TestMethod]
    public void Should_Login_Successfully_Performance_Glitch_User()
    {

        var loginBo = new LoginBO
        {
            UserName = "performance_glitch_user"
        };
        loginPage.LoginApplication(loginBo);
        var homePage = new LoginPage(driver);
        Assert.IsTrue(driver.FindElement(By.Id("shopping_cart_container")).Displayed);


    }
    [TestMethod]
    public void Should_Login_Successfully_Problem_User()
    {

        var loginBo = new LoginBO
        {
            UserName = "problem_user"
        };
        loginPage.LoginApplication(loginBo);
        var homePage = new LoginPage(driver);
        Assert.IsTrue(driver.FindElement(By.Id("shopping_cart_container")).Displayed);

    }

    [TestMethod]
    public void Should_Not_Login_Successfully_Locked_Out_User()
    {
        var loginBo = new LoginBO
        {
            UserName = "locked_out_user"
        };
        loginPage.LoginApplication(loginBo);
        var homePage = new LoginPage(driver);

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Sorry, this user has been locked out."));
    }


    [TestMethod]
    public void Should_Not_Login_With_Incorrect_Username()
    {
        var loginBo = new LoginBO
        {
            UserName = "ilinca_user"
        };
        loginPage.LoginApplication(loginBo);

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Username and password do not match any user in this service"));
    }

    [TestMethod]
    public void Should_Not_Login_With_Incorrect_Password()
    {
        var loginBo = new LoginBO
        {
            Password = "incorrectPassword"
        };
        loginPage.LoginApplication(loginBo);

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Username and password do not match any user in this service"));
    }

    [TestMethod]
    public void Should_Not_Login_With_Invalid_Credentials()
    {
        var loginBo = new LoginBO
        {
            UserName = "ilinca_user",
            Password = "incorrectPassword"
        };
        loginPage.LoginApplication(loginBo);

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Username and password do not match any user in this service"));
    }

    [TestMethod]
    public void Should_Not_Login_With_No_Password_Performance_Glitch_User()
    {
        loginPage.FillEmailAndSignIn("performance_glitch_user");

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Password is required"));
    }

    [TestMethod]
    public void Should_Not_Login_With_No_Password_Standard_User()
    {
        loginPage.FillEmailAndSignIn("standard_user");

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Password is required"));
    }

    [TestMethod]
    public void Should_Not_Login_With_No_Password_Problem_User()
    {
        loginPage.FillEmailAndSignIn("problem_user");

        Assert.IsTrue(loginPage.FailLoginMessageText.Equals("Epic sadface: Password is required"));
    }

    [TestCleanup]
    public void CleanUp()
    {
        driver.Quit();
    }
}