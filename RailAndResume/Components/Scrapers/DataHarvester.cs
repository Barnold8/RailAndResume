using Microsoft.AspNetCore.Components;


namespace RailAndResume.Components.Scrapers
{
    public class DataHarvester
    {
        private readonly protected List<Scraper> m_jobScrapers;
        private readonly protected Scraper? m_trainScraper;

        public DataHarvester(List<Scraper> jobScrapers, Scraper trainScraper)
        {

            m_jobScrapers = jobScrapers;
            m_trainScraper = trainScraper;

        }
    }
}
