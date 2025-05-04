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

        
        protected void NavigateToUrl(string url)
        {
            m_driver?.Navigate().GoToUrl(url);
        }

        
        public abstract List<Job> ProcessContents();

        public virtual void Dispose()
        {
            m_driver?.Quit();
            m_driver?.Dispose();
            m_driver = null;
        }
    }
}