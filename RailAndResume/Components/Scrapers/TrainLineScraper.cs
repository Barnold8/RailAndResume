using System.Collections.ObjectModel;
using System.Xml.Linq;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RailAndResume.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RailAndResume.Components.Scrapers
{

    public class TrainLineScraper : Scraper
    {

        //url https://traintimes.org.uk/LDN/NOT/06:00/2025-06-30/22:45/2025-06-30
        // LDN = Start station (This case, London (LDN))
        // NOT = End station   (This case, Nottingham (NOT))
        // Then followed by time leaving
        // Followed by date leaving
        // Then followed by time arriving
        // Following by date arriving


        private ChromeDriver m_driver;

        public TrainLineScraper(string url) {

            m_driver = InitialiseDriver();
            m_driver.Navigate().GoToUrl(url);

        }

        public override List<Job> processContents()
        {
            throw new NotImplementedException();
        }
    }
}
