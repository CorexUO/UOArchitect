using System;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public class ExtractResponse : OrbResponse 
	{
		private DesignItemCol _items;
		public short TopX;
		public short TopY;
		public short Height;
		public short Width;
		public string Map;

		public ExtractResponse(DesignItemCol items)
		{
			_items = items;
		}

		public DesignItemCol Items
		{
			get{ return _items; }
		}
	}
}
