using CrawlerBusinessServices.Model;
using CrawlerDataServices.DataServices;
using CrawlerDataServices.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerBusinessServices.BusinessServices
{
    public class CrawlerBusinessService : ICrawlerBusinessService
    {
        private ICrawlerDataService _crarwlerDataService;

        public CrawlerBusinessService(ICrawlerDataService crarwlerDataService)
        {
            _crarwlerDataService = crarwlerDataService;
        }      


        public async Task<BusinessCrawlerResponse> LoadBusinessCrawler(BusinessCrawlerRequest businessCrawlerRequest)
        {
            var crawlerDataResponse = await _crarwlerDataService.LoadCrawlerData(new CrawlerDataRequest { Url = businessCrawlerRequest.Url });

            return ConvertCrawlerServiceData(crawlerDataResponse);
        }

        public BusinessCrawlerResponse ConvertCrawlerServiceData(CrawlerDataResponse serviceDataCrawlerResponse)
        {
            var crawlerBusinessResponse = new BusinessCrawlerResponse();

            crawlerBusinessResponse.Images = serviceDataCrawlerResponse.Images;
            crawlerBusinessResponse.Words = CategorizeWordCount(CountWords(serviceDataCrawlerResponse.Words));

            return crawlerBusinessResponse;
        }

        public Dictionary<string, int> CountWords(string[] words)
        {
            var countWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    var wordLowerCase = word.ToLower();

                    if (countWords.ContainsKey(wordLowerCase))
                    {
                        countWords[wordLowerCase]++;
                    }
                    else
                    {
                        countWords[wordLowerCase] = 1;
                    }
                }
            }

            return countWords;
        }

        public IEnumerable<Word> CategorizeWordCount(Dictionary<string, int> countWords)
        {
            var words = new List<Word>();
            
            var wordCount = countWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var count = 0;
            foreach (var item in wordCount)
            {
                words.Add(new Word { WordDescription = item.Key, WordCount = item.Value, IsBold = count < 10 });
                count++;
            }

            return words.OrderByDescending(x => x.WordCount);
        }
    }
}
