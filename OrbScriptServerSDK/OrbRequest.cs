using System;
using System.Threading;

namespace OrbServerSDK
{
	public abstract class OrbRequest : MarshalByRefObject
	{
		private OrbResponse m_Response;
		private ManualResetEvent m_Reset;

		public OrbResponse Response
		{
			get{ return m_Response; }
		}

		public ManualResetEvent ResetEvent
		{
			get{ return m_Reset; }
			set{ m_Reset = value; }
		}

		public abstract void OnRequest(OrbClientInfo clientInfo, OrbRequestArgs args);

		public void SendResponse(OrbResponse response)
		{
			m_Response = response;

			if(m_Reset != null)
				m_Reset.Set();
		}
	}
}
