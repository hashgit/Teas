using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using TeaStall.ApplicationBuilder;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace TeaStall.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = ContainerManager.BuildContainerWithApi(typeof(WebApiApplication).Assembly);
            // Create the depenedency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container) as IDependencyResolver;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
