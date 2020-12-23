using System;
using System.Collections;
using System.Xml;

namespace UOArchitect
{
	public class ServerListingCol : CollectionBase 
	{
		public void LoadListings(XmlNodeList serverNodeList)
		{
			Clear();
			Deserialize(serverNodeList);
		}

		public void SaveListings(XmlDocument document, XmlNode serversNode)
		{
			foreach(ServerListing listing in List)
			{
				serversNode.AppendChild(listing.Serialize(document));
			}
		}

		private void Deserialize(XmlNodeList serverNodeList)
		{
			foreach(XmlNode serverNode in serverNodeList)
			{
				List.Add(new ServerListing(serverNode));
			}
		}

		public int Add(ServerListing listing)
		{
			return List.Add(listing);
		}

		public void Remove(ServerListing listing)
		{
			List.Remove(listing);
		}		
			
		public ServerListing this[int index]
		{
			get{ return (ServerListing)List[index]; }
		}

		public ServerListing GetListingByID(string id)
		{
			for(int i=0; i < List.Count; ++i)
			{
				ServerListing listing = (ServerListing)List[i];

				if(listing.GUID == id)
					return listing;
			}

			return null;
		}
	}
}
