using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicalgorithmics
{
    class Utils
    {
        WebDriverWait wait;
        public Utils(WebDriverWait wait)
        {
            this.wait = wait;
        }
        public void Click(By selector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector)).Click();
        }
        public void Enter(By selector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector)).SendKeys(Keys.Enter);
        }
        public void SendKeys(By selector, String phrase)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector)).SendKeys(phrase);
        }
    }
}
