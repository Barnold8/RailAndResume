using HtmlAgilityPack;

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


        private HtmlDocument? m_contents;
        private string m_url;

        public TrainLineScraper(string url) {
            m_url = url;
        }

        public override async void initialiseWebPage() {

            if (m_url != null && m_url.Length >= Scraper.URL_CHAR_MIN)
            {
                m_contents = await this.GrabWebPageAsync(m_url);
            }
            else {

                if (m_url == null)
                {
                    throw new ArgumentException(
                        string.Format("Parameter cannot be null | Variable name {0}", nameof(m_url))
                    );
                }
                else {
                    throw new ArgumentException(
                        string.Format("Parameter cannot be of length 0 | Variable length {0}", m_url.Length)
                    );
                }
            }

        }

        public override void processContents()
        {
            Console.WriteLine(m_contents.DocumentNode.OuterHtml);
        }

    }
}
