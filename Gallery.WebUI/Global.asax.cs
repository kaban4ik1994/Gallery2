using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Gallery.WebUI.Mappings;

namespace Gallery.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitilizeMapper();
        }

        private static void InitilizeMapper()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DepartamentMappingProfile>();
            }
        );
            Mapper.AssertConfigurationIsValid();
        }
    }
}
