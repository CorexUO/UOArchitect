using System;
using UOArchitectInterface;

namespace UOArchitect
{
	[Serializable]
	public class DesignData
	{
		public delegate void SavedEvent();

		public SavedEvent OnSaved;
		private const short DESIGN_VERSION = 1;
		public const int Levels = 5;

		private string _name = "";
		private string _category = "";
		private string _subcategory = "";
		private int _width = 0;
		private int _height = 0;
		private int _userWidth = 0;
		private int _userHeight = 0;
		private long _filePosition = 0;
		private int _recordCount = 0;
		private DesignItemCol _items = new DesignItemCol();

		private static int[] m_LevelZ = new int[Levels]
			{
				0, 7, 27, 47, 67
			};

		public static int[] LevelZ{ get{ return m_LevelZ; } }

		public DesignData()
		{
			_name = "New Design";
			_category = "Unassigned";
			_subcategory = "Unassigned";
		}

		public DesignData(string name, string category, string subsection)
		{
			_name = name;
			_category = category; 
			_subcategory = subsection;
		}

		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		public string Category
		{
			get{ return _category; }
			set{ _category = value; }
		}

		public string Subsection
		{
			get{ return _subcategory; }
			set{ _subcategory = value; }
		}

		public int Width
		{
			get{ return _width; }
			set{ _width = value; }
		}

		public int Height
		{
			get{ return _height; }
			set{ _height = value; }
		}

		public int UserWidth
		{
			get{ return _userWidth; }
			set{ _userWidth = value; }
		}

		public int UserHeight
		{
			get{ return _userHeight; }
			set{ _userHeight = value; }
		}

		public DesignItemCol Items
		{
			get{ return _items; }
		}

		public void SetItems(DesignItemCol items, bool UseCalculations)
		{
			_items = items;

			if(UseCalculations)
			{	
				UpdateSize();
			}	
		}

		private void UpdateSize()
		{
			_width = _items.Width;
			_height = _items.Height;
			_userWidth = _items.Width;
			_userHeight = _items.Height;
		}

		// import design from extracted design data
		public void ImportItems(DesignItemCol items, bool calculateOffsets, bool foundation)
		{
			if(items.Count == 0)
				return;

			_items.Clear();

			for(int i=0; i < items.Count; ++i)
			{
				DesignItem item = items[i];

				int xoffset = 0;
				int yoffset = 0;
				int zoffset = 0;

				if(!foundation)
					item.Z += LevelZ[1];

				if(calculateOffsets)
				{
					xoffset = item.X - items.OriginX;
					yoffset = item.Y - items.OriginY;
					zoffset = item.Z - items.OriginZ;
				}
				else
				{
					xoffset = item.X;
					yoffset = item.Y;
					zoffset = item.Z;
				}

				_items.Add(new DesignItem(item.ItemID, xoffset, yoffset, zoffset, GetZLevel(zoffset), item.Hue));
			}

			UpdateSize();
		}

		private int GetZLevel(int z)
		{
			if(z < LevelZ[1])
				return 0;
			else if(z < LevelZ[2])
				return 1;
			else if(z < LevelZ[3])
				return 2;
			else if(z < LevelZ[4])
				return 3;
			else
				return 4;
		}

		public long FilePosition
		{
			get{ return _filePosition; }
			set{ _filePosition = value; }
		}

		public int RecordCount
		{
			get{ return _recordCount; }
			set{ _recordCount = value; }
		}

		public bool IsLoaded
		{
			get{ return _items.Count > 0; }
		}

		public bool IsNewRecord
		{
			get{ return (_filePosition == 0 && _recordCount == 0); }
		}

		public void Load()
		{
			Unload();
			HouseDesignData.LoadDesign(this);
		}

		public void Unload()
		{
			_items.Clear();
		}

		public void Save()
		{
			Save(IsNewRecord);
		}

		public void Save(bool newRecord)
		{
			if(!IsLoaded)
				Load();

			if(newRecord)
			{
				HouseDesignData.SaveNewDesign(this);
			}
			else
			{
				HouseDesignData.UpdateDesign(this);
			}

			if(OnSaved != null)
				OnSaved();
		}

		// this method patches the current design data to the multi muls
		public int PatchToMultiMuls(PatchInfo patchInfo)
		{
			if(!this.IsLoaded)
				this.Load();

			MultiPatcher patcher = new MultiPatcher(patchInfo);
			
			// patch this design to the target multi muls
			int index = patcher.PatchMulti(this, null);

			// unload the multi data
			this.Unload();

			return index;
		}

	}
}
