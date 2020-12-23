using System;
using System.IO;
using UOArchitectInterface;
using System.Collections;

namespace UOArchitect
{
	public class MultiCacheDataImporter
	{
		private const byte EXPORT_VERSION = 2;
		private const string _filter = "(*.dat)|*.dat";
		private const string _title = "UO MultiCache.dat";

		private long _itemCount = 0;

		public long Count
		{
			get{ return _itemCount; }
		}

		public ArrayList ImportDesigns()
		{
			ArrayList designs = new ArrayList();
			string filename = GetImportFileName();

			if(filename == null || !File.Exists(filename))
				return designs;

			try
			{
				using(StreamReader reader = new StreamReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read)))
				{
					string line;
					char[] delimiter = new char[]{ '\t' };
					DesignData design = null;
					DesignItemCol designItems = new DesignItemCol();
					
					while ((line = reader.ReadLine()) != null)
					{
						if(line.Length == 0)
							continue;

						string[] Values = line.Split(delimiter);

						if(Values.Length > 5) // this is the multi header line
						{
							if(design != null && designItems.Count > 0)
							{
								design.ImportItems(designItems, true, true);
								designs.Add(design);
								design = null;
								designItems.Clear();
							}

							design = new DesignData("Multi " + designs.Count + 1, "multicache", "misc");
						}
						else if(Values.Length == 5)  // this is a multi component
						{
							if(design != null)
							{
								DesignItem item = new DesignItem();

								item.ItemID = Convert.ToInt16(Values[0]);
								item.X = Convert.ToInt32(Values[2]);
								item.Y = Convert.ToInt32(Values[3]);
								item.Z = Convert.ToInt32(Values[4]);

								if(item.ItemID != 1)
								{
									designItems.Add(item);
								}
							}
						}
					}
					
					reader.Close();

					if(design != null && designItems.Count > 0)
					{
						design.ImportItems(designItems, true, true);
						designs.Add(design);
					}
				}
			}
			catch
			{
			}

			return designs;
		}

		protected string GetImportFileName()
		{
			return Utility.BrowseForFile(_filter, _title);
		}
	}
}
