using System;
using System.Xml;

namespace UOArchitect
{
	public class ServerListing
	{
		public string GUID;
		public string ServerName;
		public string UserName;
		public string Password;
		public string ServerIP;
		public int Port;
		public bool SavePassword = false;

		public bool IsValid
		{
			get
			{
				bool isValid = true;

				if(ServerIP == null || ServerIP.Length == 0)
					isValid = false;
				else if(UserName == null || UserName.Length == 0)
					isValid = false;
				else if(Port <= 0)
					isValid = false;

				return isValid;
			}
		}

		public ServerListing(XmlNode listingNode)
		{
			GUID = Guid.NewGuid().ToString();

			if(listingNode != null)
			{
				Deserialize(listingNode);
			}
		}

		public ServerListing(string server, string ip, int port, string username)
		{
			ServerName = server;
			ServerIP = ip;
			Port = port;
			UserName = username;
		}

		private void Deserialize(XmlNode listingNode)
		{
			GUID = listingNode.Attributes.GetNamedItem("id").Value;

			foreach(XmlNode node in listingNode.ChildNodes)
			{
				switch(node.Name.ToLower())
				{
					case "name":
						ServerName = node.InnerText.Trim();
						break;

					case "password":
						Password = node.InnerText.Trim();
						break;

					case "ip":
						ServerIP = node.InnerText.Trim();
						break;

					case "acct":
						UserName = node.InnerText.Trim();
						break;

					case "port":
						try
						{
							Port = int.Parse(node.InnerText.Trim());
						}
						catch
						{
							Port = 0;
						}
						break;
				}
			}

		}

		public XmlNode Serialize(XmlDocument document)
		{
			XmlNode serverNode = document.CreateElement("server");

			XmlAttribute attr = document.CreateAttribute("id");
			attr.Value = GUID;
			serverNode.Attributes.Append(attr);

			XmlNode node = document.CreateElement("name");
			node.InnerText = ServerName;
			serverNode.AppendChild(node);

			node = document.CreateElement("password");
			node.InnerText = Password;
			serverNode.AppendChild(node);

			node = document.CreateElement("ip");
			node.InnerText = ServerIP;
			serverNode.AppendChild(node);

			node = document.CreateElement("port");
			node.InnerText = Port.ToString();
			serverNode.AppendChild(node);

			node = document.CreateElement("acct");
			node.InnerText = UserName;
			serverNode.AppendChild(node);

			return serverNode;
		}

	}
}
