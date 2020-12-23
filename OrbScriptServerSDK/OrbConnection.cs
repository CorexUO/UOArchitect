using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Threading;

namespace OrbServerSDK
{
	public class OrbConnection : MarshalByRefObject
	{
		public delegate LoginCodes LoginEvent(OrbClientInfo client, string password);
		public delegate void DisconnectEvent(string clientID);

		public delegate OrbResponse ExecuteRequestEvent(string alias, OrbClientInfo client, OrbRequestArgs args);
		public delegate void ExecuteCommandEvent(string alias, OrbClientInfo client, OrbCommandArgs args);

		public static LoginEvent OnLogin;
		public static DisconnectEvent OnDisconnect;
		public static ExecuteCommandEvent OnExecuteCommand;
		public static ExecuteRequestEvent OnExecuteRequest;

		public OrbConnection()
		{
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}

		public LoginResult LoginToServer(OrbClientInfo clientInfo, string password)
		{
			LoginCodes code;
			string message = null;
			Exception exception = null;

			if(OnLogin != null)
			{
				try
				{
					code = OnLogin(clientInfo, password);

					switch(code)
					{
						case LoginCodes.InvalidAccount:
							message = "Invalid username or password";
							break;

						case LoginCodes.NotAuthorized:
							message = "This account has been blocked by the server admin.";
							break;

						case LoginCodes.ConnectionFailure:
							message = "Connection to the server failed.";
							break;
					}
				}
				catch(Exception e)
				{
					code = LoginCodes.ConnectionFailure;
					message = "Login failed. Connection Lost.";
					exception = e;
				}
			}
			else
			{
				code = LoginCodes.ConnectionFailure;
				message = "Login failed. Connection Lost.";
			}

			return new LoginResult(code, message, exception);
		}

		public void Disconnect(string clientID)
		{
			if(OnDisconnect != null)
				OnDisconnect(clientID);
		}

		public void SendCommand(string alias, OrbClientInfo client, OrbCommandArgs args)
		{
			if(OnExecuteCommand != null)
				OnExecuteCommand(alias, client, args);
		}

		public OrbResponse SendRequest(string alias, OrbClientInfo client, OrbRequestArgs args)
		{
			OrbResponse response = null;

			try
			{
				if(OnExecuteRequest != null)
					response = OnExecuteRequest(alias, client, args);
			}
			catch
			{
			}

			return response;
		}
	}
}
