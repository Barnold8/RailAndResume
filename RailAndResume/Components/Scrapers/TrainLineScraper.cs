using System.Collections.ObjectModel;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RailAndResume.Components.Scrapers
{

    public class TrainLineScraper : Scraper
    {

        //url https://traintimes.org.uk/AAA/BBB/22:45/2025-06-30/22:45/2025-06-30
        // AAA = Start station
        // BBB = End station
        // Then followed by time leaving
        // Followed by date leaving
        // Then followed by time arriving
        // Following by date arriving


        private ChromeDriver m_driver;

        public TrainLineScraper(string url) {

            m_driver = InitialiseDriver();
            m_driver.Navigate().GoToUrl(url);

           
        }

 

        public override void processContents()
        {

            ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.ClassName("results"));

            foreach (IWebElement element in elements)
            {
                Console.WriteLine(element.Text);
            }

        }

    }
}
