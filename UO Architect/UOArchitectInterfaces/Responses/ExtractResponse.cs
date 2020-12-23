using System;
using OrbServerSDK;
using System.Collections;

namespace UOArchitectInterface
{
	[Serializable]
	public class ExtractResponse : OrbResponse 
	{
		private Rect2DCol _rects = new Rect2DCol();
		private DesignItemCol _items;
		public string Map;

		public ExtractResponse(DesignItemCol items)
		{
			_items = items;
		}

		public DesignItemCol Items
		{
			get{ return _items; }
			set{ _items = value; }
		}

		public Rect2DCol Rects
		{
			get{ return _rects; }
			set{ _rects = value; }
		}
	}
}
