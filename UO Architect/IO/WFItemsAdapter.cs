using System;
using System.IO;
using UOArchitectInterface;
using System.Xml;
using System.Windows.Forms;

namespace UOArchitect
{
	public class WFItemsAdapter : BaseDesignAdapter
	{
		private static int[] m_LevelZ = new int[6]
			{
				0, 20, 40, 60, 80, 100
			};

		public WFItemsAdapter() : base("(*.xml)|*.xml", "World Forge Export")
		{
		}

		public override DesignData ImportDesign()
		{
			string filename = GetImportFileName();

			if(!File.Exists(filename))
				return null;

			DesignData design = new DesignData();
			DesignItemCol designItems = new DesignItemCol();

			char[] Separator = { ' ' };

			try
			{
				XmlDocument document = new XmlDocument();
				document.Load(filename);

				XmlNodeList itemNodes = document.SelectNodes("//export/tile");

				for(int i=0; i < itemNodes.Count; ++i)
				{
					XmlNode node = itemNodes[i];
					string Value = null;

					int id = 0;
					int x = 0;
					int y = 0;
					int z = 0;
					int hue = 0;

					Value = node.Attributes.GetNamedItem("id").Value;

					if(Value != null && Value.Length > 0)
					{
						id = int.Parse(Value);
					}

					Value = node.Attributes.GetNamedItem("x").Value;

					if(Value != null && Value.Length > 0)
					{
						x = int.Parse(Value);
					}

					Value = node.Attributes.GetNamedItem("y").Value;

					if(Value != null && Value.Length > 0)
					{
						y = int.Parse(Value);
					}

					Value = node.Attributes.GetNamedItem("z").Value;

					if(Value != null && Value.Length > 0)
					{
						z = int.Parse(Value);
					}

					Value = node.Attributes.GetNamedItem("hue").Value;

					if(Value != null && Value.Length > 0)
					{
						hue = int.Parse(Value);
					}
					
					designItems.Add(new DesignItem(id, x, y, z, GetZLevel(z), hue));
				}

				design.ImportItems(designItems, true, false);
			}
			catch(Exception e)
			{	
				design = null;
				MessageBox.Show("The import failed due to the following error.\n" + e.Message);
			}

			return design;
		}

		private int GetZLevel(int z)
		{
			if(z < m_LevelZ[1])
				return 0;
			else if(z < m_LevelZ[2])
				return 1;
			else if(z < m_LevelZ[3])
				return 2;
			else if(z < m_LevelZ[4])
				return 3;
			else if(z < m_LevelZ[5])
				return 4;
			else
				return 5;
		}

		public override void Export(DesignData design)
		{
			string filename = Utility.GetSaveFileName("(*.mlt)|*.mlt", "Multi Data File", "");

			if(filename.Length > 0)
			{
				if(!design.IsLoaded)
					design.Load();

				int zoffset = CalculateMinZ(design.Items);

				BinaryFileWriter writer = new BinaryFileWriter(File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None));

				for(int i = 0; i < design.Items.Count; ++i )
				{
					DesignItem item = design.Items[i];

					writer.WriteShort(item.ItemID);
					writer.WriteShort((short)item.X);
					writer.WriteShort((short)item.Y);
					writer.WriteShort((short)(item.Z - zoffset));
					writer.WriteShort(1);
					writer.WriteShort(item.Hue);
				}

				writer.Close();
			}
		}

		private int CalculateMinZ(DesignItemCol items)
		{
			int minZ = 99999;

			for(int i = 0; i < items.Count; ++i )
			{
				if(items[i].Z < minZ)
				{
					minZ = items[i].Z;
				}
			}

			return minZ;
		}
	}
}