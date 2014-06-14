using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using ItemAnalyzer.Model;
using ItemAnalyzer.Transport.Properties;
using Newtonsoft.Json;

namespace ItemAnalyzer.Transport
{
	public class Authentication
	{
		private readonly CookieContainer credentialCookies;

		public Authentication()
		{
			credentialCookies = new CookieContainer();
		}

		public bool Authenticate()
		{
			var credentials = GetCredentials();
			var hashValue = GetHash();

			var request = GetHttpRequest(HttpMethod.Post, Settings.Default.LoginURL);
			request.AllowAutoRedirect = false;

			var data = GetRequestData(credentials, hashValue);

			request.ContentLength = data.Length;

			var postStream = request.GetRequestStream();
			postStream.Write(data, 0, data.Length);

			var response = (HttpWebResponse) request.GetResponse();

			if (response.StatusCode != HttpStatusCode.Found)
				throw new Exception();

			return true;
		}

		private static byte[] GetRequestData(Credentials credentials, string hashValue)
		{
			var data = new StringBuilder();
			data.Append("login_email=" + Uri.EscapeDataString(credentials.Username));
			data.Append("&login_password=" + Uri.EscapeDataString(credentials.SecurePassword.UnWrap()));
			data.Append("&hash=" + hashValue);
			var byteData = Encoding.UTF8.GetBytes(data.ToString());
			return byteData;
		}

		private static Credentials GetCredentials()
		{
			var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Settings.Default.Credentials);
			var credentialsText = File.ReadAllText(filename);
			var credentials = JsonConvert.DeserializeObject<Credentials>(credentialsText);
			return credentials;
		}

		private string GetHash()
		{
			var request = GetHttpRequest(HttpMethod.Get, Settings.Default.LoginURL);
			var responseText = GetContentsFromStream(request.GetResponse());
			var hashValue = Regex.Match(responseText, Settings.Default.HashRegEx).Groups["hash"].Value;
			return hashValue;
		}

		private string GetContentsFromStream(WebResponse response)
		{
			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}

		private HttpWebRequest GetHttpRequest(string method, string url)
		{
			var request = (HttpWebRequest) HttpWebRequest.Create(url);

			request.CookieContainer = credentialCookies;
			request.UserAgent =
				"User-Agent: Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; .NET4.0E; .NET CLR 1.1.4322)";
			request.Method = method;
			request.ContentType = "application/x-www-form-urlencoded";

			return request;
		}
	}
}
