using System;
using System.IO;
using UOArchitectInterface;
using System.Collections;

namespace UOArchitect
{
	public class UOARBatchDataAdapter
	{
		private const byte EXPORT_VERSION = 2;
		private const string _filter = "(*.uoa)|*.uoa";
		private const string _title = "UO Architect Design";

		private long _itemCount = 0;

		public long Count
		{
			get{ return _itemCount; }
		}

		public ArrayList ImportDesigns()
		{
			ArrayList designs = new ArrayList();
			string[] filenames = GetImportFileNames();

			if(filenames == null)
				return designs;

			foreach(string filename in filenames)
			{
				if(!File.Exists(filename))
					continue;

				BinaryFileReader reader = new BinaryFileReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read));

				short version = reader.ReadShort();
			
				switch(version)
				{
					case 1:
						// file contains only one design (old format)
						designs.Add(ImportDesign(reader, version));
						break;

					case 2:
						// file may contain multiple designs
						int designCount = reader.ReadShort();

						for(int i=0; i < designCount; ++i)
							designs.Add(ImportDesign(reader, version));

						break;
				}

				reader.Close();
			}

			return designs;
		}

		private DesignData ImportDesign(BinaryFileReader reader, short version)
		{
			DesignData design = new DesignData();

			switch(version)
			{
				case 1:
				case 2:
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

						_itemCount++;
					}
					break;
			}

			return design;
		}

		public void ExportDesigns(ArrayList designs)
		{
			ExportDesigns(designs, "");
		}

		public void ExportDesigns(ArrayList designs, string defaultFile)
		{
			if(designs.Count == 0)
				return;

			string filename = GetExportFileName(defaultFile);

			if(filename.Length > 0)
			{
				BinaryFileWriter writer = new BinaryFileWriter(File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None));

				// write file version
				writer.WriteShort(EXPORT_VERSION);
				// writer design count
				writer.WriteShort((short)designs.Count);

				for(int i=0; i < designs.Count; ++i)
				{
					DesignData design = (DesignData)designs[i];

					if(!design.IsLoaded)
						design.Load();

					ExportDesign(design, writer);
					design.Unload();
				}
				
				writer.Close();
				System.Windows.Forms.MessageBox.Show(string.Format("{0} designs were exported.", designs.Count));
			}
		}

		public void ExportDesign(DesignData design, BinaryFileWriter writer)
		{
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
		}

		protected string[] GetImportFileNames()
		{
			return Utility.BrowseForFiles(_filter, _title);
		}

		protected string GetExportFileName()
		{
			return GetExportFileName("");
		}

		protected string GetExportFileName(string defaultName)
		{
			return Utility.GetSaveFileName(_filter, _title, defaultName);
		}

	}
}
