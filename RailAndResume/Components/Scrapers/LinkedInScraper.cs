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
            ReadOnlyCollection<IWebElement> elements = m_driver.FindElements(By.ClassName("job-search-card"));
            List<Job> jobs = new List<Job>();


            foreach (IWebElement element in elements)
            {
                string? contents = element.GetAttribute("innerText");
                ReadOnlyCollection<IWebElement> links = element.FindElements(By.TagName("a"));

                if (contents != null)
                {

                    string[] splitContents = contents.Split("\n");
                    string link = "N/A";

                    if (links != null)
                    {
                        string? tempLink = links.First().GetAttribute("href");
                        link = tempLink == null ? "N/A" : tempLink;

                    }

                    Job job = new Job(
                            splitContents[0],
                            splitContents[2],
                            link
                    );

                    jobs.Add(job);
                }
            }

            m_driver.Close();

            return jobs;

        }
    }
}
