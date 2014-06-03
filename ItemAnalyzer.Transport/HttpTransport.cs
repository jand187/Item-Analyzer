using System.Linq;
using ItemAnalyzer.Model;

namespace ItemAnalyzer.Transport
{
	public interface IHttpTransport
	{
		InventoryPage GetInventory();
	}

	public class HttpTransport : IHttpTransport
	{
		public InventoryPage GetInventory()
		{
			return new InventoryPage
			{
				Id = 1,
				Name = "first page"
			};
		}
	}
}
