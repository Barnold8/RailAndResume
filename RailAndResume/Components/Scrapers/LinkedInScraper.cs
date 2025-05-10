using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RailAndResume.Models;
using System.Collections.ObjectModel;

namespace RailAndResume.Components.Scrapers
{
    public class LinkedInScraper : Scraper
    {
        public LinkedInScraper(string url) : base(url) { }

        public override List<Job> ProcessContents()
        {
            List<Job> jobs = new List<Job>();
            if (m_driver != null) {
                ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.ClassName("job-search-card"));

                foreach (IWebElement element in elements)
                {
                    string? contents = element.GetAttribute("innerText");
                    ReadOnlyCollection<IWebElement> links = element.FindElements(By.TagName("a"));

                    if (contents != null)
                    {

                        string[] splitContents = contents.Split("\n");
                        string link = GrabLink(links);

                        Job job = new Job(
                                splitContents[0],
                                splitContents[2],
                                link
                        );

                        if (ValidJob(job))
                        {
                            jobs.Add(job);
                        }
                    }
                }
                Dispose();
            }
            return jobs;
        }
    }
}
