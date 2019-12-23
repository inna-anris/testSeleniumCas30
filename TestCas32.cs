using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Vezba_Selenium_Cas_30
{
    class TestCas32 : SeleniumBaseClass
    {

        [Test]
        public void Zadatak1Test()
        {
            this.NavigateTo("https://www.seleniumeasy.com/test/window-popup-modal-demo.html");
            this.DoWait(1);
            IWebElement tfb = this.FindElement(By.XPath("//div[@class='two-windows']/a"));
            this.DoWait(1);
            tfb.Click();
            this.DoWait(10);
            
            var popup = this.Driver.WindowHandles[1];
            this.Driver.SwitchTo().Window(popup);

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
