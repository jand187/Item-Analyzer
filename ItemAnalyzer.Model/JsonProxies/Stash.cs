using System.Collections.Generic;
using System.Linq;

namespace ItemAnalyzer.Model.JsonProxies
{
	public class Stash
	{
		public int numTabs { get; set; }
		public List<Item> items { get; set; }
		public List<Tab> tabs { get; set; }
	}
}
