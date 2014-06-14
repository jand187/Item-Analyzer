using System;
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
			var stash0 = httpTransport.GetStashJson();
			var stash1 = httpTransport.GetStashJson(index:1);

			return string.Format("{0}{2}{2}{2}{1}", stash0, stash1, Environment.NewLine);
		}
	}
}
