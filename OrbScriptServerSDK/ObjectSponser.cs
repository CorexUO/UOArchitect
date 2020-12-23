using System;
using System.Runtime.Remoting.Lifetime;

namespace OrbServerSDK
{
	[Serializable]
	public class ObjectSponser : ISponsor 
	{
		public TimeSpan Renewal(ILease lease)
		{
			return TimeSpan.FromMinutes(10);
		}
	}
}
