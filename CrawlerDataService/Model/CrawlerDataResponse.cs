using System.Collections.Generic;

namespace CrawlerDataServices.Model
{
    public class CrawlerDataResponse
    {
        public CrawlerDataResponse()
        {
            Images = new List<string>();
        }

        public IList<string> Images { get; set; }

        public string[] Words { get; set; }
    }
}
