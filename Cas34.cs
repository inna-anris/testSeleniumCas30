using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Vezba_Selenium_Cas_30
{
    class Cas34 : SeleniumBaseClass
    {

        [Test]
        public void QaRsTest()
        {
            this.NavigateTo("http://shop.qa.rs/");
            IWebElement kolicina = this.FindElement(By.XPath("//h3[contains(text(),'SMALL')]/parent::div/following-sibling::div[1]//select"));
            var select = new SelectElement(kolicina);
            select.SelectByValue("6");
            int ocekivanaCena = Convert.ToInt32(this.FindElement(By.XPath("//h3[contains(text(),'SMALL')]/parent::div/following-sibling::div[2]")).Text.Substring(1));
            this.DoWait(1);
            IWebElement order = this.FindElement(By.XPath("//h3[contains(text(),'SMALL')]/parent::div/following-sibling::div[1]//input[@type='submit']"));
            order.Click();
              
            int qty = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[2]")).Text);
            int price = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[3]")).Text.Substring(1));
            int subtotal = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[4]")).Text.Substring(1));
            
            Assert.AreEqual(ocekivanaCena, price);
            
            Assert.AreEqual(subtotal, qty * price);

            this.DoWait(3);
            this.DoWait(1);
        }

        [Test]
        public void EmmiMonitori()
        {
            this.NavigateTo("https://www.emmi.rs/");
            this.DoWait(1);
            IWebElement monitori = this.FindElement(By.XPath("//a[@title='Monitori']"));
            monitori.Click();
            this.DoWait(1);
            IWebElement brend = this.FindElement(By.Name("brandId"));
            var select = new SelectElement(brend);
            select.SelectByText("HP");
            this.DoWait(1);
            IWebElement tip = this.FindElement(By.Name("tip"));
            select = new SelectElement(tip);
            select.SelectByText("TN");
            this.DoWait(1);
            IWebElement trazi = this.FindElement(By.XPath("//input[@value='traži']"));
            trazi.Click();
            this.DoWait(1);
            IWebElement omen = this.FindElement(By.XPath("//a[contains(text(), 'OMEN')]"));
            omen.Click();
            this.DoWait(1);
            IWebElement price = this.FindElement(By.XPath("//div[@class='price']"));
            var cena = price.Text.Trim();
            Assert.AreEqual("29.990", cena);

            this.DoWait(2);

        }

        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}
