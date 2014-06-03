using System.Web.Http;
using ItemAnalyzer.Transport;

namespace ItemAnalyzer.Website.Api
{
	public class UpdateController : ApiController
	{
		private readonly IHttpTransport _httpTransport;

		public UpdateController(IHttpTransport httpTransport)
		{
			_httpTransport = httpTransport;
		}

		public string GetStash()
		{
			return _httpTransport.GetInventory().Name;
		}
	}
}
