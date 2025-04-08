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
            driver = new ChromeDriver();
        }

        [Test]
        public void VerifyYearFromFirstResult()
        {
        }

        [TearDown]
        public void TearDown() {
            driver.Dispose();
        }

    }
}