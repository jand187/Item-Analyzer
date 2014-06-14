using System.Linq;
using System.Net;
using ItemAnalyzer.Transport.Properties;

namespace ItemAnalyzer.Transport
{
	public interface IHttpTransport
	{
		string GetStashJson(string league = "Standard", int index = 0);
	}

	public class HttpTransport : IHttpTransport
	{
		private readonly IAuthentication authentication;

		public HttpTransport(IAuthentication authentication)
		{
			this.authentication = authentication;
		}

		public string GetStashJson(string league = "Standard", int index = 0)
		{
			authentication.Authenticate();
			var request = authentication.GetHttpRequest(HttpMethod.Get, string.Format(Settings.Default.StashURL, league, index));
			var webResponse = (HttpWebResponse) request.GetResponse();
			return webResponse.ReadAll();
		}
	}
}
