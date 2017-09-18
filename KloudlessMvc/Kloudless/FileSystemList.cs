using System;
using System.Collections.Generic;
using System.Collections;

namespace KloudlessMvc.Kloudless
{
	public class FileSystemList : IEnumerable
	{
		public int count { get; set; }
		public string page { get; set; }
		public string nextPage { get; set; }
		public List<FileSystem> objects { get; set; }


		#region IEnumerable implementation
		public IEnumerator GetEnumerator ()
		{
			return objects.GetEnumerator ();
		}
		#endregion
	}
}

