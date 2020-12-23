using System;
using System.IO;
using UOArchitectInterface;

namespace UOArchitect
{
	public class UOARDataAdapter : BaseDesignAdapter
	{
		private const byte EXPORT_VERSION = 1;
		public UOARDataAdapter() : base("(*.uoa)|*.uoa", "UO Architect Design")
		{
		}

		public override DesignData ImportDesign()
		{
			string filename = GetImportFileName();

			if(!File.Exists(filename))
				return null;

			BinaryFileReader reader = new BinaryFileReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read));

			short version = reader.ReadShort();

			DesignData design = new DesignData();

			if(version == 1)
			{
				design.Name = reader.ReadString();
				design.Category = reader.ReadString();
				design.Subsection = reader.ReadString();
				design.Width = reader.ReadInt();
				design.Height = reader.ReadInt();
				design.UserWidth = reader.ReadInt();
				design.UserHeight = reader.ReadInt();

				int count = reader.ReadInt();

				for(int i = 0; i < count; ++i)
				{
					short index = reader.ReadShort();
					short x = reader.ReadShort();
					short y = reader.ReadShort();
					short z = reader.ReadShort();
					short level = reader.ReadShort();
					short hue = reader.ReadShort();

					design.Items.Add(new DesignItem(index, x, y, z, level, hue));
				}
			}	
			
			reader.Close();

			return design;
		}

		public override void Export(DesignData design)
		{
			string filename = GetExportFileName(design.Name);

			if(filename.Length > 0)
			{
				if(!design.IsLoaded)
					design.Load();

				BinaryFileWriter writer = new BinaryFileWriter(File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None));

				writer.WriteShort(EXPORT_VERSION);
				writer.WriteString(design.Name);
				writer.WriteString(design.Category);
				writer.WriteString(design.Subsection);
				writer.WriteInt(design.Width);
				writer.WriteInt(design.Height);
				writer.WriteInt(design.UserWidth);
				writer.WriteInt(design.UserHeight);

				// item count
				writer.WriteInt(design.Items.Count);

				for(int i = 0; i < design.Items.Count; ++i )
				{
					DesignItem item = design.Items[i];

					writer.WriteShort(item.ItemID);
					writer.WriteShort((short)item.X);
					writer.WriteShort((short)item.Y);
					writer.WriteShort((short)item.Z);
					writer.WriteShort(item.Level);
					writer.WriteShort(item.Hue);
				}

				writer.Close();
			}
		}


	}
}
