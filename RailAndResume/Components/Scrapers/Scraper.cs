using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RailAndResume.Components.Scrapers
{

    public abstract class Scraper
    {
        static readonly public int URL_CHAR_MIN = 17; // 18 because (https:// | 8) + (www. | 4) + (a | 1 AKA minimum second-level domain name length) + (.com | 4)
        static readonly public int LOAD_WAIT = 3;     // How long each selenium instance will wait before a website can be processed (this is for dynamic websites)
        public abstract void processContents();

        public ChromeDriver InitialiseDriver() {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            ChromeDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(LOAD_WAIT);

            return driver;
        }

    }
}