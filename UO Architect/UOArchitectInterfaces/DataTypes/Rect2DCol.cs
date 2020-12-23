using System;
using System.Collections;

namespace UOArchitectInterface
{
	[Serializable]
	public class Rect2DCol : CollectionBase 
	{
		public int Add(Rect2D rect)
		{
			return List.Add(rect);
		}

		public void Remove(Rect2D rect)
		{
			List.Remove(rect);
		}

		public Rect2D this[int index]
		{
			get{ return (Rect2D)List[index]; }	
			set{ List[index] = value; }
		}
	}
}
