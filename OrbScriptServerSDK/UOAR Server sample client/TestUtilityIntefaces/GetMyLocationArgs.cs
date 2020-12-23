using System;
using OrbServerSDK;

namespace TestUtilityIntefaces
{
	// Since we don't need to pass arguments to the GetMyLocation request we will define an empty arguments class. In reality
	// you could pass null to the OrbClient SendRequest method for the arguments instead.

	[Serializable] // *** REQUIRED ***
	public class GetMyLocationArgs : OrbRequestArgs 
	{
	}


	// Define a subclass to store the scripted request's return data.

	[Serializable] // *** REQUIRED ***
	public class GetLocationResponse : OrbResponse 
	{
		public int X;
		public int Y;
		public int Z;

		public override string ToString()
		{
			return string.Format("Location: X={0}, Y={1}, Z={2}", X, Y, Z);
		}

	}
}
