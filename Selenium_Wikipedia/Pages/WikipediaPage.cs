using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium_Wikipedia.Pages
{
    public class WikipediaPage
    {
        private readonly IWebDriver driver;
        IWebElement resultParagraph => driver.FindElement(By.XPath("//p[text()[contains(. , 'first completely automated industrial process')]]"));

        public WikipediaPage(IWebDriver driver) {
            this.driver = driver;
        }

        public string GetParagraphText () => resultParagraph.Text;

        public void TakeScreenshot(string pictureName)
        {
            DateTime currentDate = DateTime.Now;
            Screenshot capture = ((ITakesScreenshot)driver).GetScreenshot();
            capture.SaveAsFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), $"{pictureName} {currentDate:MM-dd-yy}.png"));
        }
    }
}
