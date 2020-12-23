using System;
using System.Collections;
using UOArchitectInterface;

namespace UOArchitectInterface
{
	[Serializable]
	public class DesignItemCol : CollectionBase 
	{
		private int _width = 0;
		private int _height = 0;
		private int _originX = 0;
		private int _originY = 0;
		private int _originZ = 0;
		private bool _recalculateSize = true;
	
		public int Add(DesignItem item)
		{
			int index = List.Add(item);
			_recalculateSize = true;

			return index;
		}

		public void Remove(DesignItem item)
		{
			List.Remove(item);
			_recalculateSize = true;
		}

		public DesignItem this[int index]
		{
			get{ return (DesignItem)List[index]; }
		}

		public int IndexOf(DesignItem item)
		{
			return List.IndexOf(item);
		}

		public int Width
		{
			get
			{
				if(_recalculateSize)
					CalculateSize();

				return _width; 
			}
	
		}

		public int Height
		{
			get
			{
				if(_recalculateSize)
					CalculateSize();

				return _height; 
			}
	
		}

		public int OriginX
		{
			get
			{
				if(_recalculateSize)
					CalculateSize();

				return _originX; 
			}
		}

		public int OriginY
		{
			get
			{
				if(_recalculateSize)
					CalculateSize();

				return _originY; 
			}
		}

		public int OriginZ
		{
			get
			{
				if(_recalculateSize)
					CalculateSize();

				return _originZ; 
			}
		}

		private void CalculateSize()
		{
			int maxX = -99999;
			int maxY = -99999;
			int minX = 999999;
			int minY = 999999;
			int minZ = 999999;

			if(List.Count == 0)
			{
				ClearCalculations();
				return;
			}
	
			for(int i = 0; i < List.Count; ++i)
			{
				DesignItem item = (DesignItem)List[i];

				maxX = item.X > maxX ? item.X : maxX;
				maxY = item.Y > maxY ? item.Y : maxY;
				minX = item.X < minX ? item.X : minX;
				minY = item.Y < minY ? item.Y : minY;
				minZ = item.Z < minZ ? item.Z : minZ;
			}	

			_originX = minX;
			_originY = minY;
			_originZ = minZ;
			_width = (maxX - minX) + 1;
			_height = (maxY - minY) + 1;

			_recalculateSize = false;
		}

		private void ClearCalculations()
		{
			_originX = 0;
			_originY = 0;
			_originZ = 0;
			_width = 0;
			_height = 0;

			_recalculateSize = false;
		}
	}
}
