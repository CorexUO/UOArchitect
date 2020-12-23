using System;
using System.Collections;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public class MoveItemsArgs : OrbCommandArgs 
	{
		private int[] _itemSerials;
		private short _xoffset = 0;
		private short _yoffset = 0;
		private short _zoffset = 0;

		public short Xoffset
		{
			get{ return _xoffset; }
			set{ _xoffset = value; }
		}

		public short Yoffset
		{
			get{ return _yoffset; }
			set{ _yoffset = value; }
		}

		public short Zoffset
		{
			get{ return _zoffset; }
			set{ _zoffset = value; }
		}

		public MoveItemsArgs(int[] itemSerials)
		{
			_itemSerials = itemSerials;
		}

		public int Count
		{
			get{ return _itemSerials != null ? _itemSerials.Length : 0; }
		}

		public int[] ItemSerials
		{
			get{ return _itemSerials; }
			set{ _itemSerials = value; }
		}

	}
}
