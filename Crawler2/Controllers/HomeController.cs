using Crawler2.Models;
using CrawlerBusinessServices.BusinessServices;
using CrawlerBusinessServices.Model;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crawler2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrawlerBusinessService _businessCrawler;

        public HomeController(ICrawlerBusinessService businessCrawler)
        {
            _businessCrawler = businessCrawler;
        }

        public ActionResult Index()
        {
            return View("Index", new CrawlerViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Submit(CrawlerViewModel request)
        {
            if (ModelState.IsValid)
            {
                var businessCrawlerResponse = await _businessCrawler.LoadBusinessCrawler(new BusinessCrawlerRequest { Url = request.Url });

                return View("Index", ConvertViewModelData(businessCrawlerResponse));
            }

            return View("Index", request);
        }

        public CrawlerViewModel ConvertViewModelData(BusinessCrawlerResponse businessCrawlerResponse)
        {
            var crawlerViewModel = new CrawlerViewModel();

            crawlerViewModel.Images = businessCrawlerResponse.Images;
            crawlerViewModel.Words = businessCrawlerResponse.Words;

            return crawlerViewModel;
        }

    }
}