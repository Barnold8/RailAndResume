using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace RailAndResume.Components.Scrapers
{
    public class LinkedInScraper : Scraper
    {

        private ChromeDriver m_driver;

        public LinkedInScraper(string url)
        {

            m_driver = InitialiseDriver();
            m_driver.Navigate().GoToUrl(url);

        }

        public override void processContents()
        {
            ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.TagName("li"));

            foreach (IWebElement element in elements)
            {

                Console.WriteLine("Element: {0}", element.GetAttribute("innerHTML"));
            }

            m_driver.Close();
        }

        public string returnContents()
        {

            ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.ClassName("base-card"));

            string f = elements.Count.ToString();

            foreach (IWebElement element in elements)
            {
                f += element.GetAttribute("innerHTML") + "\n\n\n\n\n";

            }

            m_driver.Close();

            return f;

        }

    }
}
