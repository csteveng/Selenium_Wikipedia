using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Wikipedia.Pages;

namespace Selenium_Wikipedia
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(
                "--incognito",
                "--no-sandbox",
                "--headless");

            driver = new ChromeDriver(options);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void VerifyYearFromFirstResult()
        {
            //Open browser on google url
            driver.Navigate().GoToUrl("https://www.google.com/");

            //Search results for automation
            GooglePage googlePage = new GooglePage(driver);
            googlePage.SearchForValue("Automation");

            //Go to first search result for Wikipedia
            googlePage.ClickResultLink();

            //Verify year for the first automatic process
            WikipediaPage wikipediaPage = new WikipediaPage(driver);
            string paragraph = wikipediaPage.GetParagraphText();
            Assert.That(paragraph, Does.Contain("Oliver Evans in 1785"));

            //Take screenshot for web page
            wikipediaPage.TakeScreenshot("Screenshot");
        }

        [TearDown]
        public void TearDown() {
            driver.Close();
            driver.Quit();
        }

    }
}