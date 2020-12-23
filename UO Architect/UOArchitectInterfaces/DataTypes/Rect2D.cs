using System;

namespace UOArchitectInterface
{
	[Serializable]
	public class Rect2D
	{
		public int TopX = 0;
		public int TopY = 0;
		public int Width = 0;
		public int Height = 0;

		public Rect2D(int topx, int topy, int width, int height)
		{
			TopX = topx;
			TopY = topy;
			Width = width;
			Height = height;
		}
	}
}
