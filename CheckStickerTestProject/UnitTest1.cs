using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Collections.Generic;



namespace CheckStickerTestProject
{
    [TestClass]
    public class CheckStickerClass
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [TestInitialize]
        public void Init()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }


        [TestMethod]
        public void CheckEveryProductHasStickerTest()
        {
            driver.Url = "http://litecart/";

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".middle .content")));

            var products = driver.FindElements(By.CssSelector("[class^=product]"));

            foreach (var product in products)
            {
                var sticker = product.FindElements(By.CssSelector("[class^=sticker]"));
                Assert.IsTrue(sticker.Count == 1);
            }
        }


        [TestCleanup]
        public void Finish()
        {
            driver.Quit();
            //driver = null;
        }
    }
}
