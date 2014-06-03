using System.Web;
using System.Web.Http;

namespace ItemAnalyzer.Website
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			GlobalConfiguration.Configure(HaveBoxConfig.Register);
		}
	}
}
