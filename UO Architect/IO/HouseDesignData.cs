using System;
using System.IO;
using System.Collections;
using UOArchitectInterface;

namespace UOArchitect
{
	public class HouseDesignData
	{
		public delegate void SaveNewDesignEvent(DesignData design);
		public delegate void RefreshDesignsList();

		private static readonly string INDEX_FILE;
		private static readonly string BIN_FILE;
		private static readonly string SAVE_DIR;
		private static readonly string BACKUP_DIR;
		private static readonly string TMP_INDEX_FILE;
		private static readonly string TMP_BIN_FILE;
		private static readonly string BACKUP_INDEX_FILE;
		private static readonly string BACKUP_BIN_FILE;

		private static readonly int INDEX_FILE_VERSION = 0;
		private static readonly int COMPONENT_VERSION = 1;

		public static SaveNewDesignEvent OnNewDesignSaved;
		public static RefreshDesignsList OnRefreshDesignsList;
		private static ArrayList m_DesignHeaders;
		private static ArrayList m_UnsavedDesigns = new ArrayList();

		public static ArrayList DesignHeaders
		{
			get{ return m_DesignHeaders; }
		}

		static HouseDesignData()
		{
			string currentDir = Directory.GetCurrentDirectory();

			if(!currentDir.EndsWith(@"\"))
				currentDir += @"\";

			SAVE_DIR = currentDir + @"Save\";
			BACKUP_DIR = SAVE_DIR + @"Backup\";
			INDEX_FILE = SAVE_DIR + "Designs.idx";
			BIN_FILE = SAVE_DIR + "Designs.bin";
			TMP_INDEX_FILE = SAVE_DIR + "DesignsIdx.tmp";
			TMP_BIN_FILE = SAVE_DIR + "DesignsBin.tmp";
			BACKUP_INDEX_FILE = BACKUP_DIR + "Designs.idx";
			BACKUP_BIN_FILE = BACKUP_DIR + "Designs.bin";

			LoadDesignHeaders();
		}

		public static void BatchSaveNewDesigns(ArrayList newDesigns)
		{
			m_UnsavedDesigns.AddRange(newDesigns);
			SaveData();

			if(OnRefreshDesignsList != null)
				OnRefreshDesignsList();
		}

		public static void SaveNewDesign(DesignData design)
		{
			m_UnsavedDesigns.Add(design);
			SaveData();

			if(OnNewDesignSaved != null)
				OnNewDesignSaved(design);
		}

		public static void UpdateDesign(DesignData design)
		{
			if(!design.IsNewRecord)
			{
				int index = m_DesignHeaders.IndexOf(design);

				if(index != -1)
				{
					m_DesignHeaders.RemoveAt(index);
				}
			}
			
			m_UnsavedDesigns.Add(design);
			SaveData();
		}

		public static void DeleteDesign(DesignData header)
		{
			int index = m_DesignHeaders.IndexOf(header);

			if(index != -1)
			{
				m_DesignHeaders.RemoveAt(index);
				SaveData();
			}
		}

		private static void SaveData()
		{
			if(!Directory.Exists(SAVE_DIR))
				Directory.CreateDirectory(SAVE_DIR);

			if(!Directory.Exists(BACKUP_DIR))
				Directory.CreateDirectory(BACKUP_DIR);
			
			try
			{
				WriteBinFile();
				WriteHeaderFile();

				ReplaceSaveFiles();
			}
			catch(Exception e)
			{
				if(File.Exists(TMP_INDEX_FILE))
					File.Delete(TMP_INDEX_FILE);

				if(File.Exists(TMP_BIN_FILE))
					File.Delete(TMP_BIN_FILE);

				System.Windows.Forms.MessageBox.Show("An error occurred while saving your changes. Recovered last save files");
				System.Windows.Forms.MessageBox.Show(String.Format("Exception Message: {0}\nStack Trace: {1}", e.Message, e.StackTrace));
			}

			// Refresh the category list
			CategoryList.Refresh();
		}

		private static void WriteBinFile()
		{
			bool fileExists = File.Exists(BIN_FILE);
			BinaryFileWriter binWriter = new BinaryFileWriter(File.Open(TMP_BIN_FILE, FileMode.Create, FileAccess.Write, FileShare.None));

			if(fileExists)
			{
				BinaryFileReader oldBinReader = new BinaryFileReader(File.Open(BIN_FILE, FileMode.Open, FileAccess.Read, FileShare.None));
				WriteSavedComponentData(oldBinReader, binWriter);
				oldBinReader.Close();
			}

			foreach(DesignData unsavedDesign in m_UnsavedDesigns)
			{
				unsavedDesign.FilePosition = binWriter.Position;
				unsavedDesign.RecordCount = unsavedDesign.Items.Count;
				WriteUpdatedDesignComponentData(unsavedDesign.Items, binWriter);
				m_DesignHeaders.Add(unsavedDesign);
			}

			m_UnsavedDesigns.Clear();

			binWriter.Close();
		}

		private static void ReplaceSaveFiles()
		{
			if(File.Exists(INDEX_FILE))
				File.Copy(INDEX_FILE, BACKUP_INDEX_FILE, true);

			if(File.Exists(TMP_INDEX_FILE))
			{
				File.Copy(TMP_INDEX_FILE, INDEX_FILE, true);
				File.Delete(TMP_INDEX_FILE);
			}

			if(File.Exists(BIN_FILE))
				File.Copy(BIN_FILE, BACKUP_BIN_FILE, true);

			if(File.Exists(TMP_BIN_FILE))
			{
				File.Copy(TMP_BIN_FILE, BIN_FILE, true);
				File.Delete(TMP_BIN_FILE);
			}
		}

		private static void WriteSavedComponentData(BinaryFileReader oldBinReader, BinaryFileWriter binWriter)
		{
			for(int i=0; i < m_DesignHeaders.Count; ++i)
			{
				DesignData header = (DesignData)m_DesignHeaders[i];

				oldBinReader.Seek(header.FilePosition, SeekOrigin.Begin);
				// update record start position
				header.FilePosition = binWriter.Position;

				// write component data
				WriteSavedComponentData(header, oldBinReader, binWriter);
			}
		}

		private static void WriteUpdatedDesignComponentData(DesignItemCol designItems, BinaryFileWriter binWriter)
		{
			for(int i = 0; i < designItems.Count; ++i)
			{
				binWriter.WriteInt(COMPONENT_VERSION);
				binWriter.WriteInt(designItems[i].ItemID);
				binWriter.WriteInt(designItems[i].X);
				binWriter.WriteInt(designItems[i].Y);
				binWriter.WriteInt(designItems[i].Z);
				binWriter.WriteInt(designItems[i].Level); // level
				binWriter.WriteInt(designItems[i].Hue);
			}
		}

		private static void WriteSavedComponentData(DesignData header, BinaryFileReader oldFileReader, BinaryFileWriter writer)
		{
			int count = header.RecordCount;

			for(int j=0; j < count; ++j)
			{	
				int ver = oldFileReader.ReadInt();

				switch(ver)
				{
					case 0:
						writer.WriteInt(ver); // version
						writer.WriteInt(oldFileReader.ReadInt()); // index
						writer.WriteInt(oldFileReader.ReadInt()); // x
						writer.WriteInt(oldFileReader.ReadInt()); // y
						writer.WriteInt(oldFileReader.ReadInt()); // z
						writer.WriteInt(oldFileReader.ReadInt()); // level
						break;

					case 1:
						writer.WriteInt(ver); // version
						writer.WriteInt(oldFileReader.ReadInt()); // index
						writer.WriteInt(oldFileReader.ReadInt()); // x
						writer.WriteInt(oldFileReader.ReadInt()); // y
						writer.WriteInt(oldFileReader.ReadInt()); // z
						writer.WriteInt(oldFileReader.ReadInt()); // level
						writer.WriteInt(oldFileReader.ReadInt()); // hue
						break;

				}

			}
		}

		private static void WriteHeaderFile()
		{
			BinaryFileWriter writer = new BinaryFileWriter(File.Open(TMP_INDEX_FILE, FileMode.Create, FileAccess.Write, FileShare.None));
				
			writer.WriteInt(m_DesignHeaders.Count); // count
			writer.WriteInt(INDEX_FILE_VERSION); // file version

			for(int i=0; i < m_DesignHeaders.Count; ++i)
			{
				DesignData header = (DesignData)m_DesignHeaders[i];

				writer.WriteString(header.Name);
				writer.WriteString(header.Category);
				writer.WriteString(header.Subsection);
				writer.WriteInt(header.Width);
				writer.WriteInt(header.Height);
				writer.WriteInt(header.UserWidth);
				writer.WriteInt(header.UserHeight);
				writer.WriteLong(header.FilePosition);
				writer.WriteInt(header.RecordCount);
			}

			writer.Close();
	
		}

		public static void LoadDesign(DesignData designHeader)
		{
			if(File.Exists(BIN_FILE))
			{
				BinaryFileReader reader = new BinaryFileReader(File.Open(BIN_FILE, FileMode.Open, FileAccess.Read, FileShare.Read));

				try
				{
					reader.Seek(designHeader.FilePosition, SeekOrigin.Begin);

					int count = designHeader.RecordCount;

					// load the house components
					int index, x, y, z, level, hue;

					for(int i=0; i < count; ++i)
					{
						index = 0;
						x = 0;
						y = 0;
						z = 0;
						level = 0;
						hue = 0;

						int compVersion = reader.ReadInt();

						switch(compVersion)
						{
							case 0:
								index = reader.ReadInt();
								x = reader.ReadInt();
								y = reader.ReadInt();
								z = reader.ReadInt();
								level = reader.ReadInt();
								break;

							case 1:
								index = reader.ReadInt();
								x = reader.ReadInt();
								y = reader.ReadInt();
								z = reader.ReadInt();
								level = reader.ReadInt();
								hue = reader.ReadInt();
								break;

						}

						designHeader.Items.Add(new DesignItem(index, x, y, z, level, hue));
					}
				}
				catch(Exception e)
				{
					System.Windows.Forms.MessageBox.Show("Unable to load design\n" + e.Message);
				}
				finally
				{
					reader.Close();
				}
			}

		}

		public static void LoadDesignHeaders()
		{
			if(File.Exists(INDEX_FILE))
			{
				BinaryFileReader reader = new BinaryFileReader(File.Open(INDEX_FILE, FileMode.Open, FileAccess.Read, FileShare.Read));

				try
				{
					int count = reader.ReadInt();
					int version = reader.ReadInt();

					m_DesignHeaders = new ArrayList(count);

					for(int i=0; i < count; ++i)
					{
						DesignData header = new DesignData();

						switch(version)
						{
							case 0:
								header.Name = reader.ReadString();
								header.Category = reader.ReadString();
								header.Subsection = reader.ReadString();
								header.Width = reader.ReadInt();
								header.Height = reader.ReadInt();
								header.UserWidth = reader.ReadInt();
								header.UserHeight = reader.ReadInt();
								header.FilePosition = reader.ReadLong();
								header.RecordCount = reader.ReadInt();
								break;

						}

						m_DesignHeaders.Add(header);
					}
				}
				catch(Exception e)
				{
					m_DesignHeaders.Clear();
					System.Windows.Forms.MessageBox.Show("Unable to load the designs\n" + e.Message);
				}
				finally
				{
					reader.Close();
				}
			}
			else
			{
				m_DesignHeaders = new ArrayList();
			}
		}
	}
}
