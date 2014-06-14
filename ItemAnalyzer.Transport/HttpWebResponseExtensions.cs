using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ItemAnalyzer.Transport
{
	public static class HttpWebResponseExtensions
	{
		public static string ReadAll(this HttpWebResponse response)
		{
			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
