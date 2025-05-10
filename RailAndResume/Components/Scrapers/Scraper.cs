using System.Collections.ObjectModel;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RailAndResume.Models;

namespace RailAndResume.Components.Scrapers
{

    public abstract class Scraper
    {
        static readonly public int URL_CHAR_MIN = 17;  // 18 because (https:// | 8) + (www. | 4) + (a | 1 AKA minimum second-level domain name length) + (.com | 4)
        static readonly public int LOAD_WAIT = 3;     // How long each selenium instance will wait before a website can be processed (this is for dynamic websites)
        private readonly int NAME_LENGTH = 3;


        protected IWebDriver? m_driver { get; set; }

       
        public Scraper(string url)
        {
            if (string.IsNullOrEmpty(url) || url.Length < URL_CHAR_MIN)
            {
                throw new ArgumentException($"Invalid URL: '{url}'. URL must be at least {URL_CHAR_MIN} characters long.");
            }

            m_driver = InitialiseDriver();
            NavigateToUrl(url);
        }

        
        protected virtual IWebDriver InitialiseDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); 
            ChromeDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(LOAD_WAIT);
            return driver;
        }

        public abstract List<Job> ProcessContents();

        public virtual void Dispose()
        {
            m_driver?.Quit();
            m_driver?.Dispose();
            m_driver = null;
        }

        protected bool ValidJob(Job job)
        {
            if (job == null) return false;

            if (job.jobName == null || job.jobName.Length < NAME_LENGTH) return false;

            if (job.jobLink == null || job.jobLink.Length < URL_CHAR_MIN) return false;

            if (job.jobLocation == null || job.jobLocation.Length < NAME_LENGTH) return false;

            return true;
        }

        protected void NavigateToUrl(string url)
        {
            m_driver?.Navigate().GoToUrl(url);
        }

        protected string GrabLink(ReadOnlyCollection<IWebElement> links)
        {
            string link = "N/A";

            if (links != null)
            {
                string? tempLink = links.First().GetAttribute("href");
                link = tempLink == null ? "N/A" : tempLink;
            }
            return link;

        }

    }
}