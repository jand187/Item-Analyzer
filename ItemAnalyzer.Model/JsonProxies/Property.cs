using System.Collections.Generic;
using System.Linq;

namespace ItemAnalyzer.Model.JsonProxies
{
	public class Property
	{
		public string name { get; set; }
		public List<object> values { get; set; }
		public int displayMode { get; set; }
	}
}