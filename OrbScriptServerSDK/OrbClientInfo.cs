using System;

namespace OrbServerSDK
{
	[Serializable]
	public class OrbClientInfo
	{
		protected string m_UserName;
		protected string m_ClientID;

		public OrbClientInfo(string clientID, string userName)
		{
			m_UserName = userName;
			m_ClientID = clientID;
		}

		public string UserName
		{
			get{ return m_UserName; }
		}

		public string ClientID
		{
			get{ return m_ClientID; }
		}
		
	}
}
