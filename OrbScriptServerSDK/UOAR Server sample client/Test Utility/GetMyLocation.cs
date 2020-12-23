using System;
using OrbServerSDK;
using TestUtilityIntefaces;
using Server.Engines.OrbRemoteServer;

namespace Server.Engines.TestUtility
{
	// Subclass the OrbRequest class to implement this request. Requests differ from
	// commands because the request can send a response back to the utility, but commands don't.
	public class GetMyLocation : OrbRequest 
	{
		public static void Initialize()
		{
			// Register this request with the scripted OrbServer and set its alias, type, accesslevel, and whether or not
			// it requires the user to be logged into the UO Client or not.
			OrbServer.Register("GetMyLocation", typeof(GetMyLocation), AccessLevel.Counselor, true);
		}

		public override void OnRequest(OrbClientInfo clientInfo, OrbRequestArgs args)
		{
			// cast the clientInfo into the OrbClientState subclass that contains addition info
			// such as the OrbClientID, Account, and logged in char if online.
			OrbClientState client = (OrbClientState)clientInfo;

			if(client.OnlineMobile != null)
			{
				// char is logged in, return its location
				GetLocationResponse resp = new GetLocationResponse();
				resp.X = client.OnlineMobile.Location.X;
				resp.Y = client.OnlineMobile.Location.Y;
				resp.Z = client.OnlineMobile.Location.Z;

				// send the response back to the test utility
				SendResponse(resp);
			}
			else
			{
				// char is offline, return null
				SendResponse(null);
			}
		}

	}
}
