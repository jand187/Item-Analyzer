using System.Collections.Generic;
using System.Linq;

namespace ItemAnalyzer.Model.JsonProxies
{
	public class Requirement
	{
		public string name { get; set; }
		public List<List<object>> values { get; set; }
		public int displayMode { get; set; }
	}
}