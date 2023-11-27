using CrawlerDataServices.Model;
using System.Threading.Tasks;

namespace CrawlerDataServices.DataServices
{
    public interface ICrawlerDataService
    {
        Task<CrawlerDataResponse> LoadCrawlerData(CrawlerDataRequest crawler);
    }
}
