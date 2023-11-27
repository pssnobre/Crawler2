using CrawlerBusinessServices.BusinessServices;
using CrawlerDataServices.DataServices;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Crawler2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            var container = new UnityContainer();
            container.RegisterType<ICrawlerBusinessService, CrawlerBusinessService>();
            container.RegisterType<ICrawlerDataService, CrawlerDataService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
