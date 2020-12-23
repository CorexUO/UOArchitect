using System;
using System.Threading;

namespace OrbServerSDK
{
	public abstract class OrbCommand : MarshalByRefObject
	{
		public abstract void OnCommand(OrbClientInfo clientInfo, OrbCommandArgs args);
	}
}
