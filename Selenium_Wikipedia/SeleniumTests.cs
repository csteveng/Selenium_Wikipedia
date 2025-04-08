using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            driver.FindElement(By.XPath("//form[@role='search']")).Click();
            IWebElement searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("automation");
            searchInput.SendKeys(Keys.Enter);
            
            //Go to first search result for Wikipedia
            IWebElement wikiResultLink = driver.FindElement(By.XPath("//a[@href='https://en.wikipedia.org/wiki/Automation']//h3"));
            wikiResultLink.Click();

            //Verify year for the first automatic process
            IWebElement paragraph = driver.FindElement(By.XPath("//p[text()[contains(. , 'first completely automated industrial process')]]"));
            Assert.That(paragraph.Text, Does.Contain("Oliver Evans in 1785"));

            //Take screenshot for web page
            DateTime currentDate = DateTime.Now;
            Screenshot capture = ((ITakesScreenshot)driver).GetScreenshot();
            
            //Saving screenshot on my pictures folder
            capture.SaveAsFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), $"Screenshot {currentDate:MM-dd-yy}.png"));
        }

        [TearDown]
        public void TearDown() {
            driver.Close();
        }

    }
}