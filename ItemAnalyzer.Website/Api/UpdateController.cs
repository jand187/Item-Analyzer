using System.Linq;
using System.Web.Http;
using ItemAnalyzer.Transport;

namespace ItemAnalyzer.Website.Api
{
	public class UpdateController : ApiController
	{
		private readonly IHttpTransport httpTransport;

		public UpdateController(IHttpTransport httpTransport)
		{
			this.httpTransport = httpTransport;
		}

		public string GetStash()
		{
			return httpTransport.GetInventory().Name;
		}
	}
}
