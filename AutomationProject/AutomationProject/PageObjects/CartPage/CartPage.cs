using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.PageObjects.CartPage
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }



        [FindsBy(How = How.CssSelector, Using = "div[class='cart_list']")]
        private IList<IWebElement> LstCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='btn_action checkout_button']")]
        private IWebElement BtnCheckout { get; set; }

        private By remove = By.CssSelector("[button[class='btn_secondary cart_button]");
        private IWebElement BtnDestroy(string itemName) =>
            LstCart.FirstOrDefault(element => element.Text.Contains(itemName))?.FindElement(remove);

        [FindsBy(How = How.CssSelector, Using = "div[class='inventory_item_name']")]
        private IList<IWebElement> item_names { get; set; }

        public bool Verificare(List<string> selected_items)
        {
            for (int i = 0; i < selected_items.Count; i++)
            {
                if (selected_items[i] != item_names[i].Text)
                {
                    return false;
                }
            }
            return true;
        }
        public void ClickCheckout()
        {
            BtnCheckout.Click();
        }

        public void RemoveItem(string itemName)
        {
            BtnDestroy(itemName).Click();
           
        }

        public CheckoutPage.CheckoutPage NavigateToAddAddressPage()
        {
            BtnCheckout.Click();
            return new CheckoutPage.CheckoutPage(driver);
        }


    }
}
