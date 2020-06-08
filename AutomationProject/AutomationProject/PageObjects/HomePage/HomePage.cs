using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.PageObjects.HomePage
{
    public class HomePage
    {
        private IWebDriver driver;
        private IList<IWebElement> Buttons;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn_primary btn_inventory']")]
        private IList<IWebElement> buttons_Add { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn_secondary btn_inventory']")]
        private IList<IWebElement> buttons_Remove { get; set; }

        

        [FindsBy(How = How.CssSelector, Using = "div[class='cart_list']")]
        private IList<IWebElement> LstCart { get; set; }

        // public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);
        [FindsBy(How = How.CssSelector, Using = "a[class='shopping_cart_link fa-layers fa-fw']")]
        private IWebElement BtnFinish { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class='fa-layers-counter shopping_cart_badge']")]
        private IWebElement NrItemCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='inventory_item_name']")]
        private IList<IWebElement> Item_Names { get; set; }

        //produse inventar
        [FindsBy(How = How.CssSelector, Using = "a[id='item_0_title_link']")]
        private IWebElement Prod0 { get; set; }

        [FindsBy(How = How.Id, Using = "item_1_title_link")]
        private IWebElement Prod1 { get; set; }

        [FindsBy(How = How.Id, Using = "item_2_title_link")]
        private IWebElement Prod2 { get; set; }

        [FindsBy(How = How.Id, Using = "item_3_title_link")]
        private IWebElement Prod3 { get; set; }

        [FindsBy(How = How.Id, Using = "item_4_title_link")]
        private IWebElement Prod4 { get; set; }

        [FindsBy(How = How.Id, Using = "item_5_title_link")]
        private IWebElement Prod5 { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div[class='inventory_item_name']")]
        private IList<IWebElement> item_names { get; set; }

        private Dictionary<string, IWebElement> dictionary_Btn_Add = new Dictionary<string, IWebElement>();
        private Dictionary<string, IWebElement> dictionary_Btn_Remove = new Dictionary<string, IWebElement>();

        public void CartPage()
        {
            BtnFinish.Click();
        }


        public void Init_Buttons()
        {
            Buttons = driver.FindElements(By.XPath("//div[@class='inventory_list']//button"));
        }

        public void Press_Button_Nr(int index)
        {
            Buttons[index].Click();
        }
        public bool Button_Nr_Is_Add(int index)
        {
            if (Buttons[index].Text == "ADD TO CART")
            {
                return true;
            }
            return false;
        }

        public bool Button_Nr_Is_Remove(int index)
        {
            if (Buttons[index].Text == "REMOVE")
            {
                return true;
            }
            return false;
        }

        public List<string> Add_Some_Items()
        {
            List<string> Item_List = new List<string>();

            Buttons[1].Click();
            Buttons[2].Click();
            Buttons[3].Click();
            Buttons[5].Click();
            Buttons[1].Click();

            Item_List.Add(Item_Names[2].Text);
            Item_List.Add(Item_Names[3].Text);
            Item_List.Add(Item_Names[5].Text);

            return Item_List;
        }

        public void Press_Cart_Button()
        {
            BtnFinish.Click();
        }

        public int getNrItemCart()
        {
            return Int32.Parse(NrItemCart.Text);
        }
        public void ProdusClick(int nr)
        {
            switch(nr)
            {
                case 0:
                    Prod0.Click();

                    break;
                case 1:
                    Prod1.Click();
                    break;
                case 2:
                    Prod2.Click();
                    break;
                case 3:
                    Prod3.Click();
                    break;
                case 4:
                    Prod4.Click();
                    break;
                case 5:
                    Prod5.Click();
                    break;

            }
            
        }

    }
}
