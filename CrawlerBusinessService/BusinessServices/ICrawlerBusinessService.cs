using CrawlerBusinessServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerBusinessServices.BusinessServices
{
    public interface ICrawlerBusinessService
    {
        Task<BusinessCrawlerResponse> LoadBusinessCrawler(BusinessCrawlerRequest request);

    }
}
