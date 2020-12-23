using System;
using System.IO;
using System.Xml;

namespace UOArchitect
{
	internal class Config
	{
		public static string VERSION = "2.5";
		private static int _port = 2594;
		private static string _ipAddress = "127.0.0.1";
		private static string _userName = "";
		private static string _password = "";
		private static string _commandPrefix = "[";
		private static string _clientDirectory = "";
		private static bool _autoDetectClientLocation = true;
		private static string _multiIdxTarget;
		private static string _multiMulTarget;
		public static ServerListingCol ServerListings = new ServerListingCol();

		static Config()
		{
			Directory.GetCurrentDirectory();
			LoadSettings();
		}

		public static bool DoTargetMultiMulsExist
		{
			get
			{
				bool exists = true;

				if(!File.Exists(_multiIdxTarget))
					exists = false;

				if(!File.Exists(_multiMulTarget))
					exists = false;

				return exists;
			}
		}

		public static PatchInfo CreateMultiPatchInfo()
		{
			PatchInfo patch = new PatchInfo();

			patch.MultiIdx = _multiIdxTarget;
			patch.MultiMul = _multiMulTarget;

			return patch;
		}

		public static string MultiIdxTarget
		{
			get{ return _multiIdxTarget; }
			set{ _multiIdxTarget = value; }
		}

		public static string MultiMulTarget
		{
			get{ return _multiMulTarget; }
			set{ _multiMulTarget = value; }
		}

		public static int Port
		{
			get{ return _port; }
			set{ _port = value; }
		}

		public static string ServerIP
		{
			get{ return _ipAddress; }
			set{ _ipAddress = value; }
		}

		public static string UserName
		{	
			get{ return _userName; }
			set{ _userName = value; }
		}

		public static string Password
		{
			get{ return _password; }
			set{ _password = value; }
		}

		public static string ClientDirectory
		{
			get{ return _clientDirectory; }
			set
			{ 
				if(System.IO.Directory.Exists(value))
				{
					_autoDetectClientLocation = false;
					_clientDirectory = value; 
					Ultima.Client.Directories.Clear();
					Ultima.Client.Directories.Add(value);
				}
				else
				{
					_autoDetectClientLocation = true;
					Ultima.Client.Directories.Clear();
				}
			}
		}

		public static void IntializeSettings()
		{
			LoadSettings();
		}

		public static bool AutoDetectClientDirectory
		{
			get{ return _autoDetectClientLocation; }
			set
			{
				_autoDetectClientLocation = value; 
				
				if(value == true)
				{
					ClientDirectory = "";
				}
			}
		}

		public static string CommandPrefix
		{
			get{ return _commandPrefix; }
			set{ _commandPrefix = value; }
		}

		public static string ConfigFile
		{
			get{ return "UO Architect.xml"; }
		}

		public static void LoadSettings()
		{
			if(File.Exists(ConfigFile))
			{
				XmlDocument document = new XmlDocument();
				document.Load(ConfigFile);

				XmlNode rootNode = document.SelectSingleNode("settings");

				// load the UO client directory setting
				XmlNode clientDirectory = rootNode.SelectSingleNode("clientDirectory");

				if(clientDirectory != null)
				{
					string directory = clientDirectory.InnerText.Trim();

					if(System.IO.Directory.Exists(directory))
					{
						ClientDirectory = directory;
					}
					else
					{
						AutoDetectClientDirectory = true;
					}	
	
				}

				// parse the server command prefix setting
				XmlNode prefix = rootNode.SelectSingleNode("prefix");

				if(prefix == null || prefix.InnerText == String.Empty)
					_commandPrefix = "[";
				else
					_commandPrefix = prefix.InnerText.Trim();

				// parse the multi command prefix setting
				XmlNode multiPatch = rootNode.SelectSingleNode("multiPatch");

				if(multiPatch != null && multiPatch.Attributes.Count > 0)
				{
					_multiIdxTarget = multiPatch.Attributes.GetNamedItem("multiIdxTarget").Value;
					_multiMulTarget = multiPatch.Attributes.GetNamedItem("multiMulTarget").Value;
				}

				if(rootNode != null)
				{
					XmlNodeList serverNodeList = rootNode.SelectNodes("server");

					if(serverNodeList.Count > 0)
					{
						ServerListings.LoadListings(serverNodeList);
					}
				}
			}
		}

		public static void SaveSettings()
		{
			XmlDocument doc = new XmlDocument();
			XmlNode RootNode = doc.CreateElement("settings");
			XmlDeclaration declare = doc.CreateXmlDeclaration("1.0", "utf-8", "");
			doc.AppendChild(declare);
			doc.AppendChild(RootNode);

			SaveMiscSettings(doc, RootNode);
			ServerListings.SaveListings(doc, RootNode);

			// save the settings to disk
			doc.Save(ConfigFile);
		}

		private static void SaveMiscSettings(XmlDocument doc, XmlNode rootNode)
		{
			if(!Config.AutoDetectClientDirectory)
			{
				XmlNode node = doc.CreateElement("clientDirectory");
				node.InnerText = Config.ClientDirectory;
				rootNode.AppendChild(node);
			}

			XmlNode node2 = doc.CreateElement("prefix");
			node2.InnerText = Config.CommandPrefix;
			rootNode.AppendChild(node2);

			XmlNode multiPatch = doc.CreateElement("multiPatch");
			XmlAttribute attr = doc.CreateAttribute("multiIdxTarget");
			attr.Value = _multiIdxTarget;
			multiPatch.Attributes.Append(attr);

			attr = doc.CreateAttribute("multiMulTarget");
			attr.Value = _multiMulTarget;
			multiPatch.Attributes.Append(attr);

			rootNode.AppendChild(multiPatch);
		}
	}
}
