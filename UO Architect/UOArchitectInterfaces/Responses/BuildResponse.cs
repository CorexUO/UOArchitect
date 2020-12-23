using System;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public class BuildResponse : OrbResponse
	{
		private int[] _itemSerials;

		public int Count
		{
			get{ return _itemSerials != null ? _itemSerials.Length : 0; }
		}

		public int[] ItemSerials
		{
			get{ return _itemSerials; }
		}

		public BuildResponse(int[] itemSerials)
		{
			_itemSerials = itemSerials;
		}
	}
}
