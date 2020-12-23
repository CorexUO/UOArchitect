using System;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public class BuildRequestArgs : OrbRequestArgs 
	{
		DesignItemCol _items = null;

		public DesignItemCol Items
		{
			get{ return _items; }
		}

		public BuildRequestArgs(DesignItemCol items)
		{
			_items = items;
		}
		
	}
}
