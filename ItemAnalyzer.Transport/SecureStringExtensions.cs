using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace ItemAnalyzer.Transport
{
	public static class SecureStringExtensions
	{
		public static string UnWrap(this SecureString secret)
		{
			if (secret == null)
				throw new ArgumentNullException("secret");

			var ptr = Marshal.SecureStringToCoTaskMemUnicode(secret);
			try
			{
				return Marshal.PtrToStringUni(ptr);
			}
			finally
			{
				Marshal.ZeroFreeCoTaskMemUnicode(ptr);
			}
		}
	}
}
