
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Medicalgorithmics
{
    class TestExecution
    {
        IWebDriver driver;
        Page page;
        WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            String driverPath = Directory.GetCurrentDirectory().Replace("bin\\Debug", "chromedriver");
            driver = new ChromeDriver(driverPath);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            page = new Page(driver, wait);
        }

        [Test] 
        public void DownloadLogosTest()
        {
            const String directoryPath = "C:\\Downloads\\";
            const String zipName = "logotypy.zip";
            const String fileName = "MA_logo_standard_claim_MONO.pdf";
            page.GoToMainPage();
            page.CloseCookieBar();
            page.SwitchLanguage("PL");
            page.GoToContactPage();
            page.GoToMediaPackPage();
            page.DownloadLogos();
            Downloads downloads = new Downloads(directoryPath);
            downloads.FindZip(zipName);
            downloads.ExtractAndFindFile(zipName, fileName);

        }

        [Test]
        public void SearchTest()
        {
            const String expectedPhrase = "PocketECG CRS – telerehabilitacja kardiologiczna";
            page.GoToMainPage();
            page.CloseCookieBar();        
            Search search = new Search(driver, wait);
            search.FindPhrase("Pocket ECG CRS");
            search.CountResults(10);
            search.CheckPhrase(expectedPhrase, 1);
            search.ClickNextPage();
            search.VerifyPageNumber(2);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
