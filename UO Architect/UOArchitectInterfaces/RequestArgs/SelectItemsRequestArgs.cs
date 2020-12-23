using System;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public enum SelectTypes
	{
		Area,
		Item
	}

	[Serializable]
	public class SelectItemsRequestArgs : OrbRequestArgs 
	{
		private SelectTypes _SelectType;
		private bool _multiple = false;
		private bool _useMinZ = false;
		private bool _useMaxZ = false;
		private int _minZ = 0;
		private int _maxZ = 0;

		public SelectItemsRequestArgs(SelectTypes type)
		{
			_SelectType = type;
		}

		public SelectTypes SelectType
		{
			get{ return _SelectType; }
		}

		public bool UseMaxZ
		{
			get{ return _useMaxZ; }
			set{ _useMaxZ = value; }
		}

		public bool UseMinZ
		{
			get{ return _useMinZ; }
			set{ _useMinZ = value; }
		}

		public int MaxZ
		{
			get{ return _maxZ; }
			set{ _maxZ = value; }
		}

		public int MinZ
		{
			get{ return _minZ; }
			set{ _minZ = value; }
		}

		public bool Multiple
		{
			get{ return _multiple; }
			set{ _multiple = value; }
		}

	}

	[Serializable]
	public class SelectItemsResponse : OrbResponse
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

		public SelectItemsResponse(int[] itemSerials)
		{
			_itemSerials = itemSerials;
		}
	}
}
