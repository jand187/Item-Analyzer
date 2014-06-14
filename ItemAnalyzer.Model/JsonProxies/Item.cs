using System.Collections.Generic;
using System.Linq;

namespace ItemAnalyzer.Model.JsonProxies
{
	public class Item
	{
		public bool verified { get; set; }
		public int w { get; set; }
		public int h { get; set; }
		public string icon { get; set; }
		public bool support { get; set; }
		public string league { get; set; }
		public List<object> sockets { get; set; }
		public string name { get; set; }
		public string typeLine { get; set; }
		public bool identified { get; set; }
		public bool corrupted { get; set; }
		public List<Property> properties { get; set; }
		public List<string> explicitMods { get; set; }
		public string descrText { get; set; }
		public int frameType { get; set; }
		public int x { get; set; }
		public int y { get; set; }
		public string inventoryId { get; set; }
		public List<object> socketedItems { get; set; }
		public List<Requirement> requirements { get; set; }
		public List<string> implicitMods { get; set; }
		public string secDescrText { get; set; }
		public List<AdditionalProperty> additionalProperties { get; set; }
	}
}