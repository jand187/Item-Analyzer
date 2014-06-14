using System.Linq;
using System.Security;

namespace ItemAnalyzer.Model
{
	public class Credentials
	{
		private string password;

		public string Username { get; set; }

		public string Password
		{
			set
			{
				SecurePassword = new SecureString();
				value.ToCharArray().ToList().ForEach(SecurePassword.AppendChar);
			}
		}

		public SecureString SecurePassword { get; set; }
	}
}
