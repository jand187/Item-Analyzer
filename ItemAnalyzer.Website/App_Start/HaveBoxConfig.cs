using System.Web.Http;
using System.Web.Http.Dispatcher;
using HaveBox;
using HaveBox.SubConfigs;
using ItemAnalyzer.Transport;
using ItemAnalyzer.Website.Api;
using ItemAnalyzer.Website.HaveBox;

namespace ItemAnalyzer.Website
{
	public class HaveBoxConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var container = new Container();
			container.Configure(cfg =>
			{
				cfg.For<UpdateController>().Use<UpdateController>();
				cfg.MergeConfig(new SimpleScanner(typeof (HttpTransport).Assembly));
			});
			config.Services.Replace(typeof (IHttpControllerActivator), new HaveBoxControllerActivator(container));
		}
	}
}
