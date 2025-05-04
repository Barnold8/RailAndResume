using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using RailAndResume.Models;

namespace RailAndResume.Components.Scrapers
{
    public class IndeedScraper : Scraper
    {
        public IndeedScraper(string url) : base(url) { }

        public override List<Job> ProcessContents()
        {

            ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.ClassName("job-search-card"));
            List<Job> jobs = new List<Job>();


            return jobs;

        }
    }
}
