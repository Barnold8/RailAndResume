using OpenQA.Selenium;
using RailAndResume.Models;
using System.Collections.ObjectModel;

namespace RailAndResume.Components.Scrapers
{
    public class TotalJobsScraper : Scraper
    {

        public TotalJobsScraper(string url) : base(url) { }
        private string FixLocation(string location)
        {
            return location.Contains(",") ? location.Split(",")[1] : location;
        }

        public override List<Job> ProcessContents()
        {
            List<Job> jobs = new List<Job>();
            if (m_driver != null) {
                ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.CssSelector("[data-at='job-item']"));

                foreach (IWebElement element in elements)
                {
                    IWebElement jobCard = element.FindElements(By.TagName("div"))[0];
                    ReadOnlyCollection<IWebElement> links = element.FindElements(By.CssSelector("[data-at='job-item-title']"));

                    string[] jobCardContents = jobCard.Text.Split("\n");
                    string? jobCardLink = GrabLink(links);

                    Job job = new Job(
                        jobCardContents[0],
                        FixLocation(jobCardContents[2]),
                        jobCardLink
                    );

                    if (ValidJob(job)) { jobs.Add(job); }
                }
            }
            return jobs;
        }
    }
}
