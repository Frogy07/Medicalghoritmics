using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medicalgorithmics
{
    class Page
    {
        IWebDriver driver;
        WebDriverWait wait;
        Utils utils; 

        public Page(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
            utils = new Utils(wait);
        }

        public void GoToMainPage()
        {
            driver.Url = "https://www.medicalgorithmics.pl/";
            driver.Manage().Window.Maximize();
        }

        public void CloseCookieBar()
        {
            String cookie_id = "cn-accept-cookie";
            utils.Click(By.Id(cookie_id));
        }

        public void SwitchLanguage(String lang)
        {
            String xpath = "//a//span[contains(text(), '" + lang.ToUpper() + "')]";
            utils.Click(By.XPath(xpath));
        }

        public void GoToContactPage()
        {
            String xpath = ".//*[@href='https://www.medicalgorithmics.pl/kontakt']";
            utils.Click(By.XPath(xpath));
        }

        public void GoToMediaPackPage()
        {
            IWebElement mediapack = driver.FindElement(By.XPath(".//*[@href='https://www.medicalgorithmics.pl/media-pack/']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(mediapack);
            actions.Perform();
            mediapack.SendKeys(Keys.Enter);
        }

        public void DownloadLogos()
        {
            String xpath = "//h1//a[@href='https://www.medicalgorithmics.pl/wp-content/uploads/2018/10/logotypy.zip']";
            utils.Enter(By.XPath(xpath));
        }



    }


}
