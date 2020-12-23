using System;
using OrbServerSDK;
using TestUtilityIntefaces;
using Server.Engines.OrbRemoteServer;

namespace Server.Engines.TestUtility
{
	// subclass the orbCommand class to implement your own command. Commands do not return any
	// data back to the test utility.
	public class SendMessage : OrbCommand
	{
		public static void Initialize()
		{
			// register the command with the OrbServer
			OrbServer.Register("SendMessage", typeof(SendMessage), AccessLevel.Counselor, true);
		}

		// override the abstract OnCommand method. This method is called by the scripted OrbServer class
		public override void OnCommand(OrbClientInfo clientInfo, OrbCommandArgs args)
		{
			// cast the clientInfo into the OrbClientState subclass that contains addition info
			// such as the OrbClientID, Account, and logged in char if online.
			OrbClientState client = (OrbClientState)clientInfo;

			// cast the args to the appropriate subclass
			SendMessageArgs msgArgs = (SendMessageArgs)args;

			if(client.OnlineMobile != null)
			{
				// send the message to the logged in character
				client.OnlineMobile.SendMessage(msgArgs.Message);
			}
		}

	}
}
