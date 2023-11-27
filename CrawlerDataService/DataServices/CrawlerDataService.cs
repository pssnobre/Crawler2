using CrawlerDataServices.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerDataServices.DataServices
{
    public class CrawlerDataService : ICrawlerDataService
    {
        public async Task<CrawlerDataResponse> LoadCrawlerData(CrawlerDataRequest request)
        {
            var crawlerResponse = new CrawlerDataResponse();

            crawlerResponse.Images = await GetCrawlerImages(request.Url);
            crawlerResponse.Words = await GetCrawlerWords(request.Url);

            return crawlerResponse;
        }

        private async Task<List<string>> GetCrawlerImages(string url)
        {
            var images = new List<string>();

            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var nodes = htmlDocument.DocumentNode.SelectNodes("//img[@src]");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        var imageUrl = node.GetAttributeValue("src", "");
                        images.Add(imageUrl);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occoured: {ex.Message}");
            }

            return images;
        }

        private async Task<string[]> GetCrawlerWords(string url)
        {
            var countWords = new string[0];

            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var text = htmlDocument.DocumentNode.InnerText;

                countWords = Regex.Split(text, @"\W+");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occoured: {ex.Message}");
            }

            return countWords;
        }
    }
}
