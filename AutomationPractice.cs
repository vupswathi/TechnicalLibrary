using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;

namespace MyShop
{
    [TestClass]
    public class AutomationPractice
    {
        [TestMethod]
        public void SeasonSale()
        {
            Sale.Goto();
        }
    }

    public class Sale
    {
        static string url = "http://automationpractice.com/index.php";


        public static void Goto()
        {
            Sale.Goto(url);
        }

        private static void Goto(string url)

        {
            IWebDriver driver = new ChromeDriver();
            XmlDocument data = new XmlDocument();
            data.Load("ShoppingCart.xml");
            XmlNode node = data.SelectSingleNode("/ShoppingList");
            driver.Url = url;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Actions action = new Actions(driver);

            var Item1 = driver.FindElement(By.XPath(node["openitem1"].InnerText));
            action.MoveToElement(Item1);
            Item1.Click();

            var Item1cart = driver.FindElement(By.XPath(node["Item1xpath"].InnerText));            
            action.MoveToElement(Item1cart);
            Item1cart.Click();

            var Continue = driver.FindElement(By.XPath(node["ContinueShopping"].InnerText));
            Continue.Click();

            var Home = driver.FindElement(By.XPath(node["Homepage"].InnerText));
            action.MoveToElement(Home);
            Home.Click();

            var Item2 = driver.FindElement(By.XPath(node["openitem2"].InnerText));
            action.MoveToElement(Item2);
            Item2.Click();

            var Item2cart = driver.FindElement(By.XPath(node["Item2xpath"].InnerText));
            action.MoveToElement(Item2cart);
            Item2cart.Click();

            var ProceedCO = driver.FindElement(By.XPath(node["ProceedCheckout"].InnerText));
            action.MoveToElement(ProceedCO);
            ProceedCO.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(node["ProceedNext"].InnerText)));
            var ProceedNextStep = driver.FindElement(By.LinkText(node["ProceedNext"].InnerText));
            ProceedNextStep.Click();

            var CreateEmail = driver.FindElement(By.Id(node["CreateEmailID"].InnerText));
            action.MoveToElement(CreateEmail);
            string Email = node["EmailAddress"].InnerText;
            CreateEmail.SendKeys(Email);
            var CreateAcc = driver.FindElement(By.Id(node["CreateAccID"].InnerText));
            CreateAcc.Submit();

            var Mrs = driver.FindElement(By.Id(node["MrsID"].InnerText));
            Mrs.Click();

            var name = driver.FindElement(By.Id(node["firstnameID"].InnerText));
            Thread.Sleep(1000);
            action.MoveToElement(name);
            string first = node["firstname"].InnerText;
            name.SendKeys(first);

            var lastnm = driver.FindElement(By.Id(node["lastnameID"].InnerText));
            string middle = node["lastname"].InnerText;
            lastnm.SendKeys(middle);

            var email = driver.FindElement(By.Id(node["emailID"].InnerText));
            email.Click();

            var password = driver.FindElement(By.Id(node["PasswordID"].InnerText));
            action.MoveToElement(password);
            string passwd = node["password"].InnerText;
            password.SendKeys(passwd);

            var AddrText = driver.FindElement(By.Id(node["AddrTextID"].InnerText));
            string Text = node["Address"].InnerText;
            AddrText.SendKeys(Text);

            var City = driver.FindElement(By.Id(node["CityID"].InnerText));
            action.MoveToElement(City);
            string suburbtext = node["suburb"].InnerText;
            City.SendKeys(suburbtext);

            var Country = driver.FindElement(By.Id(node["CountryID"].InnerText));
            Country.Click();
            Thread.Sleep(1000);
            var USA = driver.FindElement(By.XPath(node["Country"].InnerText));
            USA.Click();

            var state = driver.FindElement(By.Id(node["stateID"].InnerText));
            state.Click();
            Thread.Sleep(1000);
            var nsw = driver.FindElement(By.XPath(node["state"].InnerText));
            nsw.Click();

            var postcode = driver.FindElement(By.Id(node["postcodeID"].InnerText));
            action.MoveToElement(postcode);
            string postcd = node["postcode"].InnerText;
            postcode.SendKeys(postcd);

            var Telephone = driver.FindElement(By.Id(node["TelephoneID"].InnerText));
            action.MoveToElement(Telephone);
            string Number = node["Telnumber"].InnerText;
            Telephone.SendKeys(Number);

            var Register = driver.FindElement(By.Id(node["RegisterID"].InnerText));
            Register.Click();

            var ProceedAddCO = driver.FindElement(By.XPath(node["AddProceedCO"].InnerText));
            action.MoveToElement(ProceedAddCO);
            ProceedAddCO.Click();

            var AgreeTC = driver.FindElement(By.Id(node["AgreeTerms"].InnerText));
            action.MoveToElement(AgreeTC);
            AgreeTC.Click();

            var proceedshipping = driver.FindElement(By.XPath(node["proceedshipping"].InnerText));
            proceedshipping.Click();

            var PaybyCard = driver.FindElement(By.XPath(node["WirePay"].InnerText));
            PaybyCard.Click();

            var ConfirmOrder = driver.FindElement(By.XPath(node["ConfirmOrder"].InnerText));
            ConfirmOrder.Click();
        }

    }
}
