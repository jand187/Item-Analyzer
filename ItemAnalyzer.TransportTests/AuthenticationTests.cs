using System.Linq;
using FluentAssertions;
using ItemAnalyzer.Transport;
using Xunit;

namespace ItemAnalyzer.TransportTests
{
	public class AuthenticationTests
	{
		private readonly Authentication target;

		public AuthenticationTests()
		{
			target = new Authentication();
		}

		[Fact]
		public void Authenticate_should_return_true_on_correct_credentials()
		{
			var result = target.Authenticate();

			result.Should().BeTrue();
		}
	}
}
