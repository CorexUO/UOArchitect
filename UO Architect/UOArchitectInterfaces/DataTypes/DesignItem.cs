using System;

namespace UOArchitectInterface
{
	[Serializable]
	public class DesignItem
	{
		private short _itemID = 0;
		private int _x = 0;
		private int _y = 0;
		private int _z = 0;
		private short _level = 0;
		private short _hue = 0;

		public DesignItem()
		{
		}

		public DesignItem(int itemID, int x, int y, int z, int level, int hue)
		{
			_itemID = (short)itemID;
			_x = x;
			_y = y;
			_z = z;
			_level = (short)level;
			_hue = (short)hue;
		}	

		public short ItemID
		{
			get{ return _itemID; }
			set{ _itemID = value; }
		}

		public int X
		{
			get{ return _x; }
			set{ _x = value; }
		}

		public int Y
		{
			get{ return _y; }
			set{ _y = value; }
		}

		public int Z
		{
			get{ return _z; }
			set{ _z = value; }
		}

		public short Level
		{
			get{ return _level; }
			set{ _level = value; }
		}

		public short Hue
		{
			get{ return _hue; }
			set{ _hue = value; }
		}
	}
}
