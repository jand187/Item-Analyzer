using System.Linq;
using System.Web;
using System.Web.Http;
using HaveBox;
using HaveBox.WebExtensions;
using ItemAnalyzer.Website.Api;

namespace ItemAnalyzer.Website
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);

			GlobalConfiguration.Configuration.DependencyResolver = new HaveBoxDependencyResolver(CreateContainerAndBootstrap());
		}

		private IContainer CreateContainerAndBootstrap()
		{
			var container = new Container();
			container.Configure(x => { x.For<UpdateController>().Use<UpdateController>(); });

			return container;
		}
	}
}
