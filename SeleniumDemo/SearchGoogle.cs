using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumDemo
{
    [TestClass]
    public class SearchGoogle
    {
        [TestMethod]
        public void searchForCheese()

        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),chromeOptions))
            {

                driver.Navigate().GoToUrl("http://www.google.com");

                IWebElement query = driver.FindElement(By.Name("q"));

                query.SendKeys("Queso");

                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("Queso", StringComparison.OrdinalIgnoreCase));

                Assert.AreEqual(driver.Title, "Queso - Buscar con Google");

            }
        }
    }
}
