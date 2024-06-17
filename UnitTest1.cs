using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;


        [TestMethod]
        [TestCategory("Firefox")]
        public void TheBingSearchTest()
        {
            driver.Navigate().GoToUrl(appURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.IsFalse(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://azure.microsoft.com/en-us/";

            string browser = "";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new EdgeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
