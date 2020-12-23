using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace OrbServerSDK
{
	[Serializable]
	public class OrbClient 
	{
		private static OrbConnection m_Connection = null;
		private static string m_UserName;
		private static string m_Password;
		private static string m_ClientID;

		public static bool IsConnected
		{
			get{ return m_Connection != null ? true : false; }
		}

		static OrbClient()
		{
			// generate a new ID for this client 
			m_ClientID = Guid.NewGuid().ToString();

			ChannelServices.RegisterChannel( new TcpClientChannel());
		}

		private static void CreateConnectionObject(string serverIP, int port )
		{
			m_Connection = (OrbConnection)Activator.GetObject(typeof(OrbConnection)
				, string.Format("tcp://{0}:{1}/OrbConnection", serverIP, port.ToString()));
		}

		public static string ResolveDNS(string server)
		{
			IPHostEntry hostEntry = Dns.Resolve(server); 
			IPAddress[] ipAddresses = hostEntry.AddressList; 
				
			return ipAddresses[0].ToString();
		}

		public static void Disconnect()
		{
			if(IsConnected)
			{
				m_Connection.Disconnect(m_ClientID);
				m_Connection = null;
			}
		}

		public static LoginResult LoginToServer(string user, string password, string serverName, int port)
		{
			m_UserName = user;
			m_Password = password;

			LoginResult result;

			try
			{
				if(!IsConnected)
				{
					// resolve the server name to an IP address
					string serverIP = ResolveDNS(serverName);

					// create the remote instance of the OrbConnection object
					CreateConnectionObject(serverIP, port);
				}

				result = m_Connection.LoginToServer(new OrbClientInfo(m_ClientID, m_UserName), m_Password);
			}
			catch(Exception e)
			{
				result = new LoginResult(LoginCodes.ConnectionFailure, "Connection Failed\n" + e.Message, e);
			}

			if(result.Code != LoginCodes.Success)
			{
				m_Connection = null;
			}
				
			return result;
		}

		public static void SendCommand(string alias, OrbCommandArgs args)
		{
			bool success = true;
			string reason = null;

			if(!IsConnected)
			{
				reason = "A connection is required before this command can be sent to the server.";
				success = false;
			}
				
			try
			{
				m_Connection.SendCommand(alias, new OrbClientInfo(m_ClientID, m_UserName), args);
				success = true;
			}
			catch(Exception e)
			{
				reason = "Connection to the server was lost.\nException: " + e.Message ;
				success = false;
			}

			if(!success)
				MessageBox.Show(reason, "Command Failed");
		}

		public static OrbResponse SendRequest(string alias, OrbRequestArgs args)
		{
			bool success = true;
			string reason = null;
			OrbResponse response = null;

			if(!IsConnected)
			{
				reason = "A connection is required before this request can be sent to the server.";
				success = false;
			}
				
			try
			{
				response = m_Connection.SendRequest(alias, new OrbClientInfo(m_ClientID, m_UserName), args);
				success = true;
			}
			catch
			{
				reason = "Connection to the server was lost.";
				success = false;
			}

			if(!success)
			{
				MessageBox.Show(reason, "Command Failed");
			}

			return response;
		}
	}
}
