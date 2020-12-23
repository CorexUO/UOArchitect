using System;
using OrbServerSDK;

namespace UOArchitectInterface
{
	[Serializable]
	public class GetLocationResp : OrbResponse 
	{
		public int X = 0;
		public int Y = 0;
		public int Z = 0;

		public GetLocationResp()
		{
		}

		public GetLocationResp(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}
}
