using System;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public class DeleteCommandArgs : OrbCommandArgs 
	{
		private int[] _itemSerials;

		public DeleteCommandArgs(int[] ItemSerials)
		{
			_itemSerials = ItemSerials;
		}

		public int[] ItemSerials
		{
			get{ return _itemSerials; }
		}

		public int Count
		{
			get{ return _itemSerials != null ? _itemSerials.Length : 0; }
		}
	}
}
