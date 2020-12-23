using System;
using OrbServerSDK;
using System.Drawing;

namespace UOArchitectInterface
{
	[Serializable]
	public class ExtractRequestArgs : OrbRequestArgs 
	{
		public short MinZ = 0;
		public short MaxZ = 0;
		public bool MaxZSet = false;
		public bool MinZSet = false;
		public bool ExtractHues = true;
		public bool Foundation = false;
		public bool NonStatic = true;
		public bool Static = true;
		public bool Frozen = true;
	}
}
