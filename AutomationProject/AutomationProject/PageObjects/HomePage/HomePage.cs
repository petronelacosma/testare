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

        public HomePage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn_primary btn_inventory']")]
        private IList<IWebElement> buttons_Add { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn_secondary btn_inventory']")]
        private IList<IWebElement> buttons_Remove { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='shopping_cart_link fa-layers fa-fw']")]
        private IWebElement BtnCart{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='cart_list']")]
        private IList<IWebElement> LstCart { get; set; }

        // public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);
        [FindsBy(How = How.CssSelector, Using = "span[class='fa-layers-counter shopping_cart_badge']")]
        private IWebElement NrItemCart { get; set; }

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
            BtnCart.Click();
        }
        public List<string> getItemNames()
        {
            List<string> ItemNames = new List<string>();
            for (int i = 0; i < item_names.Count; i++)
            {
                ItemNames.Add(item_names[i].Text);
            }
            return ItemNames;
        }

        public void Init_Dict_Btn_Add()
        {
            for (int i = 0; i < buttons_Add.Count; i++)
            {
                dictionary_Btn_Add[item_names[i].Text] = buttons_Add[i];
            }
        }

        public void Init_Dict_Btn_Remove()
        {
            for (int i = 0; i < buttons_Remove.Count; i++)
            {
                dictionary_Btn_Remove[item_names[i].Text] = buttons_Remove[i];
                Console.WriteLine(item_names[i].Text);
            }
        }

        public List<string> test()
        {
            List<string> lista_iteme = new List<string>();
            Init_Dict_Btn_Add();
            dictionary_Btn_Add[item_names[1].Text].Click();
            lista_iteme.Add(item_names[1].Text);
            dictionary_Btn_Add[item_names[4].Text].Click();
            lista_iteme.Add(item_names[4].Text);
            return lista_iteme;
        }
        public void Apasa_Buton_Cart()
        {
            BtnCart.Click();
        }

        public void Apasa_Buton_Add(string ItemName)
        {
            dictionary_Btn_Add[ItemName].Click();

        }

        public void Apasa_Buton_Remove(string ItemName)
        {
            dictionary_Btn_Remove[ItemName].Click();
        }
        public string getButtonAddText(string ItemName)
        {
            return dictionary_Btn_Add[ItemName].Text;
        }

        public string getButtonRemoveText(string ItemName)
        {
            return dictionary_Btn_Remove[ItemName].Text;
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
