using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_Wikipedia.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver driver;
        IWebElement searchForm => driver.FindElement(By.XPath("//form[@role='search']"));
        IWebElement searchInput => driver.FindElement(By.Name("q"));
        IWebElement resultWikiLink => driver.FindElement(By.XPath("//a[@href='{0}']//h3"));

        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchForValue(string value)
        {
            searchForm.Click();
            searchInput.SendKeys(value);
            searchInput.SendKeys(Keys.Enter);
        }

        public void ClickResultLink()
        {
            resultWikiLink.Click();
        }
    }
}
