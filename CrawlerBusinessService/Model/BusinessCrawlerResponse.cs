using System.Collections.Generic;

namespace CrawlerBusinessServices.Model
{
    public class BusinessCrawlerResponse
    {
        public BusinessCrawlerResponse()
        {
            Images = new List<string>();
        }

        public IEnumerable<string> Images { get; set; }

        public IEnumerable<Word> Words { get; set; }
    }

    public partial class Word
    {
        public int WordCount { get; set; }
        public string WordDescription { get; set; }
        public bool IsBold { get; set; }
    }
}
