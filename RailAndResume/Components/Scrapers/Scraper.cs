using HtmlAgilityPack;

namespace RailAndResume.Components.Scrapers
{

    public abstract class Scraper
    {
        static readonly public int URL_CHAR_MIN = 17; // 18 because (https:// | 8) + (www. | 4) + (a | 1 AKA minimum second-level domain name length) + (.com | 4)
        public Task<HtmlDocument?> GrabWebPageAsync(string url)
        {
            /// <summary>
            /// Method <c>GrabWebPageAsync</c> Grabs a web page given a URL asynchronously
            /// </summary>

            HtmlWeb web;
            HtmlDocument? htmlDocument = null;

            web = new HtmlWeb();

            if (web != null && url != null && url.Length >= 1 )
            {
                htmlDocument = web.Load(url);
            }

            return Task.FromResult(htmlDocument);
        }

        public abstract void initialiseWebPage(); // force each class to make an intialiser for expected m_contents member

        public abstract void processContents();


    }
}