using System;
using System.Windows.Forms;
using UOArchitectInterface;
using Ultima;
using System.Threading;

namespace UOArchitect
{
	public enum ExtractMode
	{
		Area = 0,
		ItemSerials = 1
	}

	public class ItemExtracter
	{
		public delegate void DesignExtractEvent(DesignData design);
		public DesignExtractEvent OnExtracted;

		private DesignItemCol _items;
		private ExtractMode _mode;
		private int[] _itemSerials = null;
		private bool _multipleRects = false;
		private bool _nonStatic = true;
		private bool _static = true;
		private bool _frozen = true;
		private bool _hues = true;
		private bool _foundation = false;
		private bool _useMinZ = false;
		private bool _useMaxZ = false;
		private int _minZ = 0;
		private int _maxZ = 0;
		private int[] _levelZ = { 0, 7, 27, 47, 67, 87, 107 };
		private string _name = "New Design";
		private string _category = "Unassigned";
		private string _subsection = "Unassigned";

		#region Properties

		public bool UseMaxZ
		{
			get{ return _useMaxZ; }
			set{ _useMaxZ = value; }
		}

		public bool UseMinZ
		{
			get{ return _useMinZ; }
			set{ _useMinZ = value; }
		}

		public int MaxZ
		{
			get{ return _maxZ; }
			set{ _maxZ = value; }
		}

		public int MinZ
		{
			get{ return _minZ; }
			set{ _minZ = value; }
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
			get{ return _subsection; }
			set{ _subsection = value; }
		}

		public int[] LevelZ
		{
			get{ return _levelZ; }
			set{ _levelZ = value; }
		}

		public bool Hues
		{
			get{ return _hues; }
			set{ _hues = value; }
		}

		public bool Foundation
		{
			get{ return _foundation; }
			set{ _foundation = value; }
		}

		public bool Static
		{
			get{ return _static; }
			set{ _static = value; }
		}

		public bool NonStatic
		{
			get{ return _nonStatic; }
			set{ _nonStatic = value; }
		}

		public bool Frozen
		{
			get{ return _frozen; }
			set{ _frozen = value; }
		}

		public bool MultipleRects
		{
			get{ return _multipleRects; }
			set{ _multipleRects = value; }
		}

		public int Levels
		{
			get{ return _levelZ.Length; }
		}

		#endregion

		public void ExtractDesign()
		{
			_mode = ExtractMode.Area;
			ThreadPool.QueueUserWorkItem(new WaitCallback(StartExtraction));
		}

		public void ExtractDesign(int[] itemSerials)
		{
			_mode = ExtractMode.ItemSerials;
			_itemSerials = itemSerials;
			ThreadPool.QueueUserWorkItem(new WaitCallback(StartExtraction));
		}

		// Extract the user selected items
		private void StartExtraction(object state)
		{
			ExtractRequestArgs args = CreateExtractRequestArgs();
			// submit the request to the server
			ExtractResponse resp = Connection.ExtractDesign(args);

			if(resp == null)
			{
				RaiseExtractedEvent(null);
				return;
			}
			else
			{
				_items = resp.Items != null ? resp.Items : new DesignItemCol();
			}

			if(_frozen && _mode == ExtractMode.Area)
			{
				for(int i=0; i < resp.Rects.Count; ++i)
					ExtractFrozenItems(resp.Rects[i], resp.Map, _hues);
			}

			if(resp == null || resp.Items.Count == 0)
				RaiseExtractedEvent(null);

			DesignData design = null;

			if(resp.Items.Count > 0)
			{
				design = new DesignData(_name, _category, _subsection);
				design.ImportItems(resp.Items, true, _foundation);
			}

			RaiseExtractedEvent(design);
		}

		private void RaiseExtractedEvent(DesignData design)
		{
			if(OnExtracted != null)
				OnExtracted(design);
		}

		private void ExtractFrozenItems(Rect2D rect,string mapName, bool hued)
		{
			Map map = GetMapByName(mapName);

			if(map == null)
			{
				MessageBox.Show("Failed to extract the frozen items from the map " + mapName);
			}
			else
			{
				int xCount = rect.TopX + rect.Width;
				int yCount = rect.TopY + rect.Height;

				for(int x = rect.TopX; x < xCount; ++x)
				{
					for(int y = rect.TopY; y < yCount; ++y)
					{
						HuedTile[] tiles = map.Tiles.GetStaticTiles(x, y);

						if(tiles == null || tiles.Length == 0)
							continue;

						for(int i = 0; i < tiles.Length; ++i)
						{
							HuedTile tile = tiles[i];

							if(_useMinZ && tile.Z < _minZ)
								continue;
							else if(_useMaxZ && tile.Z > _maxZ)
								continue;

							DesignItem item = new DesignItem();

							item.ItemID = (short)(tile.ID ^ 0x4000);
							item.X = x;
							item.Y = y;
							item.Z = tile.Z;
							
							if(hued)
								item.Hue = (short)tile.Hue;

							if(_items.IndexOf(item) == -1)
								_items.Add(item);
						}
					}
				}
			}
		}

		private Map GetMapByName(string name)
		{
			Map map = null;

			switch(name.ToLower())
			{
				case "trammel":
					map = Map.Trammel;
					break;

				case "felucca":
					map = Map.Felucca;
					break;

				case "ilshenar":
					map = Map.Ilshenar;
					break;

				case "malas":
					map = Map.Malas;
					break;

				case "tokuno":
					map = Map.Tokuno;
					break;
			}	

			return map;
		}

		private ExtractRequestArgs CreateExtractRequestArgs()
		{
			ExtractRequestArgs args = new ExtractRequestArgs();

			args.ItemSerials = _itemSerials;
			args.NonStatic = _nonStatic;
			args.Static = _static;
			args.Frozen = _frozen;
			args.MaxZSet = _useMaxZ;
			args.MaxZ = (short)_maxZ;
			args.MinZSet = _useMinZ;
			args.MinZ = (short)_minZ;
			args.Foundation = _foundation;
			args.ExtractHues = _hues;
			args.MultipleRects = _multipleRects;

			return args;
		}
	}
}
