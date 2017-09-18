using System;
using System.Collections.Generic;

namespace KloudlessMvc.Kloudless
{
	public class FileSystem
	{
		public string id { get; set; }
		public string name { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }
		public string type { get; set; }
		public int account { get; set; }
		public FileSystem parent { get; set; }
		public List<FileSystem> ancestors { get; set; }
		public string path { get; set; }
		public string mimeType { get; set; }
		public Boolean downloadable { get; set; }
		public string rawId { get; set; }
		public Dictionary<string, string> owner { get; set; } // Should be a User object
	}
}

