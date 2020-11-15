using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicalgorithmics
{
    class Search
    {
        IWebDriver driver;
        WebDriverWait wait;
        Utils utils;

        public Search(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
            utils = new Utils(wait);
        }

        public void FindPhrase(String phrase)
        {
            utils.Click(By.CssSelector("a.search_button"));
            utils.SendKeys(By.CssSelector(".qode_search_field"), phrase);
            utils.Enter(By.CssSelector("a.qode_search_submit"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(), 'Wyniki wyszukiwania')]")));

        }

        public void CountResults(int expectedCount)
        {
            int resultsCount = driver.FindElements(By.XPath("//h3")).Count;
            Assert.AreEqual(expectedCount, resultsCount);
        }

        public void CheckPhrase(String expectedPhrase, int expectedCount)
        {
            var titles = driver.FindElements(By.XPath("//h3"));
            int count = 0;
            foreach (var title in titles)
            {
                if (title.Text.Equals(expectedPhrase))
                {
                    count++;
                }
            }
            Assert.AreEqual(count, expectedCount);
        }

        public void ClickNextPage()
        {
            Actions actions = new Actions(driver);
            var next_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".next a i")));
            actions.MoveToElement(next_button);
            actions.Perform();
            next_button.Click();
        }

        public void VerifyPageNumber(int expectedNumber)
        {
            By selector = By.XPath("//li//span[contains(text(), '" + expectedNumber + "')]");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }
    }
}
