using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace Vezba_Selenium_Cas_30
{
    class TestCas33 : SeleniumBaseClass
    {

        [Test]
        public void Zadatak1Test()
        {
            this.NavigateTo("http://test.qa.rs/");
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.XPath("//div[@id='registerLinkPlaceholder']/a")));
            this.DoWait(1);
            IWebElement registerNew = this.FindElement(By.XPath("//div[@id='registerLinkPlaceholder']/a"));
            registerNew.Click();
            this.DoWait(1);
            IWebElement ime = this.FindElement(By.Name("ime"));
            this.SendKeys("Ivana", false, ime);
            this.DoWait(1);
            IWebElement prezime = this.FindElement(By.Name("prezime"));
            this.SendKeys("Anris", false, prezime);
            this.DoWait(1);
            IWebElement korisnicko = this.FindElement(By.Name("korisnicko"));
            this.SendKeys("anris", false, korisnicko);
            this.DoWait(1);
            IWebElement email = this.FindElement(By.Name("email"));
            this.SendKeys("example@blabla.com", false, email);
            this.DoWait(1);
            IWebElement tel = this.FindElement(By.Name("telefon"));
            this.SendKeys("123456789", false, tel);
            this.DoWait(1);
            IWebElement ulica = this.FindElement(By.XPath("(//div[@id='address']/div)[2]/input"));
            this.SendKeys("Bul Oslobojenja 123", false, ulica);
            this.DoWait(1);
            IWebElement drzava = this.FindElement(By.Name("zemlja"));
            var select = new SelectElement(drzava);
            select.SelectByValue("srb");
            this.DoWait(1);
            wait.Until(c => c.FindElement(By.Id("grad")));
            this.DoWait(1);
            IWebElement grad = this.FindElement(By.Id("grad"));
            select = new SelectElement(grad);
            select.SelectByIndex(9);
            this.DoWait(1);
            IWebElement pol = this.FindElement(By.Id("pol_z"));
            pol.Click();
            this.DoWait(1);
            IWebElement vesti = this.FindElement(By.Id("newsletter"));
            vesti.Click();
            this.DoWait(2);
            IWebElement registruj = this.FindElement(By.Name("register"));
            registruj.Click();
            this.DoWait(1);
            IWebElement uspeh = this.FindElement(By.XPath("//div[@class='alert alert-success']"));
            Assert.True(uspeh.Displayed);
            this.DoWait(3);
        }

        [Test]
        public void Zadatak2Test()
        {
            this.NavigateTo("http://shop.qa.rs/");
            IWebElement kolicina = this.FindElement(By.XPath("//h3[contains(text(),'PRO')]/parent::div/following-sibling::div[1]//select"));
            var select = new SelectElement(kolicina);
            select.SelectByValue("10");
            this.DoWait(1);
            IWebElement order = this.FindElement(By.XPath("//h3[contains(text(),'PRO')]/parent::div/following-sibling::div[1]//input[@type='submit']"));
            order.Click();

            int qty = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[2]")).Text);
            int price = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[3]")).Text.Substring(1));
            int subtotal = Convert.ToInt32(this.FindElement(By.XPath("(//table//td)[4]")).Text.Substring(1));

            Assert.AreEqual(qty * price, subtotal);

            this.DoWait(3);
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
