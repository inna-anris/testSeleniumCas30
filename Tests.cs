using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Vezba_Selenium_Cas_30
{
    class Tests : SeleniumBaseClass
    {

        public Tests()
        {
            //this.log.FileName = @"C:\Kurs\Selenium_Cas29.txt";
        }

        [Test]
        public void TestFormInputs()
        {
            this.NavigateTo("http://test.qa.rs/");
            this.DoWait(2);
            IWebElement novi = this.FindElement(By.XPath("//a[@href='/new']"));
            novi.Click();

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
            IWebElement drzava = this.FindElement(By.Name("zemlja"));
            var select = new SelectElement(drzava);
            select.SelectByValue("srb");
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
