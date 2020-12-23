using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using Ultima;
using UOArchitectInterface;
using System.Drawing;

namespace UOArchitect
{
	public class HouseDesign
	{
		private const short DESIGN_VERSION = 1;
		public const int Levels = 7;

		private static int[] m_LevelZ = new int[Levels]
			{
				0, 7, 27, 47, 67, 87, 107
			};

		public static int[] LevelZ{ get{ return m_LevelZ; } }

		private string m_Name;
		private string m_Category;
		private string m_SubSection;

		private int m_Width, m_Height;
		private int m_UserWidth, m_UserHeight;
		private ArrayList[][][] m_Components;

		// store ref to the file header if loaded from the design data
		private DesignData m_FileHeader;
		public int Width{ get{ return m_Width; } }
		public int Height{ get{ return m_Height; } }

		public int UserWidth{ get{ return m_UserWidth; } }
		public int UserHeight{ get{ return m_UserHeight; } }

		public string Name
		{
			get{ return m_Name; }
			set{ m_Name = value; }
		}

		public string Category
		{ 
			get{ return m_Category; } 
			set{ m_Category = value; }
		}

		public string SubSection
		{ 
			get{ return m_SubSection; } 
			set{ m_SubSection = value; }
		}

		public DesignData FileHeader
		{
			get{ return m_FileHeader; }
		}

		public bool IsNewRecord
		{
			get { return m_FileHeader == null ? true : false; }
		}

		public bool UnsavedProperties
		{
			get
			{
				if(m_FileHeader == null)
					return true;
				else if(m_Name != m_FileHeader.Name)
					return true;
				else if(m_Category != m_FileHeader.Category)
					return true;
				else if(m_SubSection != m_FileHeader.Subsection)
					return true;
				else
					return false;
			}
		}
		
		public ArrayList[][][] Components{ get{ return m_Components; } }
		public int xc, yc;


		#region Contructors

		public HouseDesign()
		{
			m_Name = "New Design";
			m_Category = "Unassigned";
			m_SubSection = "Unassigned";
			Clear();
		}

		public HouseDesign(DesignData fileHeader)
		{
			m_FileHeader = fileHeader;
			m_Name = fileHeader.Name;
			m_Category = fileHeader.Category;
			m_SubSection = fileHeader.Subsection;
			m_Width = fileHeader.Width;
			m_Height = fileHeader.Height;
			m_UserWidth = fileHeader.UserWidth;
			m_UserHeight = fileHeader.UserHeight;
		
			m_Components = null;
			Clear();

			if(fileHeader == null)
				return;

			if(!m_FileHeader.IsLoaded)
				m_FileHeader.Load();

			for(int i=0; i < fileHeader.Items.Count; ++i)
			{
				DesignItem item = fileHeader.Items[i];

				HouseComponent hc = new HouseComponent(item.ItemID, item.Z);
				hc.Hue = item.Hue;

				m_Components[item.X][item.Y][GetZLevel(item.Z)].Add(hc);
			}

			Sort();

			// unload design items to conserve memory
			m_FileHeader.Unload();
		}

		public HouseDesign( string name, int width, int height )
		{
			m_Name = name;
			m_Category = "Unassigned";
			m_SubSection = "Unassigned";

			m_UserWidth = width;
			m_UserHeight = height;

			m_Width = width;
			m_Height = height + 1;

			Clear();
			BuildFoundation();
		}

		#endregion

		#region Export Methods

		// used to convert components into collection of design items
		private void ExportDesignItems(ref DesignData design)
		{
			for ( int i = 0; i < HouseDesign.Levels; ++i )
			{
				for ( int x = 0; x < design.Width; ++x )
				{
					for ( int y = 0; y < design.Height; ++y )
					{
						ArrayList list = m_Components[x][y][i];

						foreach ( HouseComponent hc in list )
						{
							design.Items.Add(new DesignItem(hc.Index, x, y, hc.Z, i, hc.Hue));
						}
					}
				}
			}
		}

		public void ExportRunUOScript()
		{
			StringBuilder sb;

			using ( StreamReader ip = new StreamReader( "Internal/scriptbase.txt" ) )
				sb = new StringBuilder( ip.ReadToEnd() );

			bool firstLine = true;
			bool blankLine = false;

			StringBuilder components = new StringBuilder();

			ArrayList list = Compress();

			for ( int i = 0; i < list.Count; ++i )
			{
				BuildEntry entry = (BuildEntry)list[i];

				if ( entry.m_Width == 1 && entry.m_Height == 1 )
				{
					blankLine = false;
					if ( entry.m_Count == 1 )
						components.AppendFormat( "\r\n\t\t\tAddComponent( new AddonComponent( 0x{0:X4} ), {1}, {2}, {3} );", entry.m_Index, entry.m_X, entry.m_Y, entry.m_Z );
					else
						components.AppendFormat( "\r\n\t\t\tAddComponent( new AddonComponent( Utility.Random( 0x{0:X4}, {4} ) ), {1}, {2}, {3} );", entry.m_Index, entry.m_X, entry.m_Y, entry.m_Z, entry.m_Count );
				}
				else
				{
					if ( !firstLine && !blankLine )
						components.AppendFormat( "\r\n" );

					bool xLoop = ( entry.m_Width != 1 );
					bool yLoop = ( entry.m_Height != 1 );
					bool randomIndex = ( entry.m_Count != 1 );
					bool xOffset = ( entry.m_X != 0 );
					bool yOffset = ( entry.m_Y != 0 );

					if ( xLoop )
						components.AppendFormat( "\r\n\t\t\tfor ( int x = 0; x < {0}; ++x )", entry.m_Width );

					if ( yLoop )
					{
						if ( xLoop )
							components.AppendFormat( "\r\n\t\t\t\tfor ( int y = 0; y < {0}; ++y )", entry.m_Height );
						else
							components.AppendFormat( "\r\n\t\t\tfor ( int y = 0; y < {0}; ++y )", entry.m_Height );
					}

					string xString, yString;

					if ( !xLoop )
						xString = entry.m_X.ToString();
					else if ( !xOffset )
						xString = "x";
					else
						xString = String.Format( "{0} + x", entry.m_X );

					if ( !yLoop )
						yString = entry.m_Y.ToString();
					else if ( !yOffset )
						yString = "y";
					else
						yString = String.Format( "{0} + y", entry.m_Y );

					if ( randomIndex )
					{
						if ( xLoop && yLoop )
							components.AppendFormat( "\r\n\t\t\t\t\tAddComponent( new AddonComponent( Utility.Random( 0x{0:X4}, {4} ) ), {1}, {2}, {3} );", entry.m_Index, xString, yString, entry.m_Z, entry.m_Count );
						else
							components.AppendFormat( "\r\n\t\t\t\tAddComponent( new AddonComponent( Utility.Random( 0x{0:X4}, {4} ) ), {1}, {2}, {3} );", entry.m_Index, xString, yString, entry.m_Z, entry.m_Count );
					}
					else
					{
						if ( xLoop && yLoop )
							components.AppendFormat( "\r\n\t\t\t\t\tAddComponent( new AddonComponent( 0x{0:X4} ), {1}, {2}, {3} );", entry.m_Index, xString, yString, entry.m_Z );
						else
							components.AppendFormat( "\r\n\t\t\t\tAddComponent( new AddonComponent( 0x{0:X4} ), {1}, {2}, {3} );", entry.m_Index, xString, yString, entry.m_Z );
					}

					components.AppendFormat( "\r\n" );
					blankLine = true;
				}

				firstLine = false;
			}

			sb.Replace( "~NAME~", Name );
			sb.Replace( "~CLASSNAME~", Safe( Name ) );
			sb.Replace( "~COMPONENTS~", components.ToString() );

			using ( StreamWriter op = new StreamWriter( String.Format( "{0}.cs", Safe( Name ) ) ) )
				op.Write( sb.ToString() );
		}

		private static int ReadEnc7( BinaryReader bin )
		{
			int v = 0;
			int shift = 0;
			byte b;

			do
			{
				b = bin.ReadByte();
				v |= (b & 0x7F) << shift;
				shift += 7;
			} while ( b >= 0x80 );

			return v;
		}

		private static void WriteEnc7( BinaryWriter bin, int num )
		{
			uint v = (uint) num;

			while ( v >= 0x80 ) 
			{
				bin.Write( (byte) (v | 0x80) );
				v >>= 7;
			}

			bin.Write( (byte) v);
		}

		#endregion

		public void Save()
		{
			Save( (m_FileHeader != null ? false : true) );
		}

		public void Save(bool New)
		{
			if(m_FileHeader == null || New)
			{
				m_FileHeader = new DesignData(m_Name, m_Category, m_SubSection);
				m_FileHeader.Width = m_Width;
				m_FileHeader.Height = m_Height;
				m_FileHeader.UserWidth = m_UserWidth;
				m_FileHeader.UserHeight = m_UserHeight;
				
				ExportDesignItems(ref m_FileHeader);

				HouseDesignData.SaveNewDesign(m_FileHeader);
			}
			else
			{
				m_FileHeader.Items.Clear();
				m_FileHeader.Width = m_Width;
				m_FileHeader.Height = m_Height;
				m_FileHeader.UserWidth = m_UserWidth;
				m_FileHeader.UserHeight = m_UserHeight;
				ExportDesignItems(ref m_FileHeader);

				HouseDesignData.UpdateDesign(m_FileHeader);
			}
		}

		public bool GetBaseCount( TileSet root, int index, out int baseIndex, out int count )
		{
			for ( int i = 0; i < root.Entries.Count; ++i )
			{
				object o = root.Entries[i];

				if ( o is TileSet )
				{
					if ( GetBaseCount( (TileSet)o, index, out baseIndex, out count ) )
						return true;
				}
				else if ( o is TileSetEntry )
				{
					TileSetEntry tse = (TileSetEntry)o;

					if ( index >= tse.BaseIndex && index < tse.BaseIndex + tse.Count && Array.IndexOf( tse.Tiles, index ) >= 0 )
					{
						baseIndex = tse.BaseIndex;
						count = tse.Count;
						return true;
					}
				}
			}

			baseIndex = index;
			count = 1;

			return false;
		}

		public ArrayList Compress()
		{
			ArrayList list = new ArrayList();

			for ( int i = 0; i < HouseDesign.Levels; ++i )
			{
				for ( int x = 0; x < m_Width; ++x )
				{
					for ( int y = 0; y < m_Height; ++y )
					{
						ArrayList comps = m_Components[x][y][i];

						for ( int j = 0; j < comps.Count; ++j )
						{
							HouseComponent hc = (HouseComponent)comps[j];

							list.Add( new BuildEntry( x, y, hc.Z, hc.BaseIndex, hc.Count, i ) );
						}
					}
				}
			}

			bool combined, thisCombined;

			do
			{
				combined = false;

				for ( int i = 0; i < list.Count; ++i )
				{
					BuildEntry be = (BuildEntry)list[i];
					thisCombined = false;

					for ( int j = 0; !thisCombined && j < list.Count; ++j )
					{
						BuildEntry te = (BuildEntry)list[j];

						if ( i != j && be.CombineWith( te ) )
						{
							list.RemoveAt( i );
							--i;
							combined = thisCombined = true;
						}
					}
				}
			} while ( combined );

			return list;
		}

		public string Safe( string ip )
		{
			ip = ip.Trim();

			if ( ip.Length == 0 )
				return "NoName";

			for ( int i = 0; i < ip.Length; ++i )
			{
				if ( !Char.IsLetterOrDigit( ip, i ) )
					ip = ip.Replace( ip[i].ToString(), "" );
			}

			if ( ip.Length == 0 )
				return "NoName";

			if ( !Char.IsLetter( ip, 0 ) )
				ip = "_" + ip;

			return ip;
		}

		private class Plane
		{
			public int m_Z;
			public int m_Level;
			public ArrayList m_List;

			public Plane( int z, int level )
			{
				m_Z = z;
				m_Level = level;
				m_List = new ArrayList();
			}
		}

		public void Sort()
		{
			for ( int x = 0; x < m_Width; ++x )
				for ( int y = 0; y < m_Height; ++y )
					for ( int i = 0; i < Levels; ++i )
						if ( m_Components[x][y][i].Count > 1 )
							m_Components[x][y][i].Sort();
		}

		public void Clear()
		{
			bool assign = ( m_Components == null );

			if ( assign )
				m_Components = new ArrayList[m_Width][][];

			for ( int x = 0; x < m_Width; ++x )
			{
				if ( assign )
					m_Components[x] = new ArrayList[m_Height][];

				for ( int y = 0; y < m_Height; ++y )
				{
					if ( assign )
						m_Components[x][y] = new ArrayList[Levels];

					for ( int i = 0; i < Levels; ++i )
					{
						if ( assign )
							m_Components[x][y][i] = new ArrayList();
						else
							m_Components[x][y][i].Clear();
					}
				}
			}
		}

		public void BuildFoundation()
		{
			AddComponent( 0, 0, 0, 0x66 );
			AddComponent( m_UserWidth - 1, m_UserHeight - 1, 0, 0x65 );

			for ( int x = 1; x < m_UserWidth; ++x )
			{
				AddComponent( x, m_UserHeight, 0, 0x751 );
				AddComponent( x, 0, 0, 0x63 );

				if ( x < m_UserWidth - 1 )
					AddComponent( x, m_UserHeight - 1, 0, 0x63 );
			}

			for ( int y = 1; y < m_UserHeight; ++y )
			{
				AddComponent( 0, y, 0, 0x64 );

				if ( y < m_UserHeight - 1 )
					AddComponent( m_UserWidth - 1, y, 0, 0x64 );
			}

			TileSetEntry te = new TileSetEntry( 0x31F4, 4 );

			for ( int x = 1; x < m_UserWidth; ++x )
				for ( int y = 1; y < m_UserHeight; ++y )
					AddComponent( x, y, LevelZ[1], 0, te.GetRandomIndex(), te.BaseIndex, te.Count, 0 );
		}

		public void AddComponent( int x, int y, int level, int index )
		{
			AddComponent( x, y, LevelZ[level], level, index );
		}

		public void AddComponent( int x, int y, int level, int index, HouseComponent hc )
		{
			AddComponent( x, y, LevelZ[level], level, index, hc );
		}


		public void AddComponent( int x, int y, int z, int level, int index )
		{
			AddComponent( x, y, z, level, index, index, 1, 0 );
		}

		public void AddComponent( int x, int y, int z, int level, int index, HouseComponent hc )
		{
			AddComponent( x, y, z, level, index, index, 1, hc.Hue );
		}

		public void AddComponent( int x, int y, int z, int level, int index, int baseIndex, int count)
		{
			AddComponent(x, y, z, level, index, baseIndex, count, 0);
		}

		public void AddComponent( int x, int y, int z, int level, int index, int baseIndex, int count, int hue )
		{
			if ( x >= 0 && x < m_Width && y >= 0 && y < m_Height && level >= 0 && level < Levels )
			{
				ArrayList list = m_Components[x][y][level];

				HouseComponent nc = new HouseComponent( index, z, baseIndex, count );
				nc.Hue = hue;

				for ( int i = 0; i < list.Count; ++i )
				{
					HouseComponent hc = (HouseComponent)list[i];

					if ( hc.Z == z && hc.Height == 0 && nc.Height == 0 )
					{
						list[i] = nc;
						list.Sort();
						return;
					}
					else if ( hc.Z == z && hc.Height != 0 && nc.Height != 0 )
					{
						list[i] = nc;
						list.Sort();
						return;
					}
				}

				list.Add( nc );
				list.Sort();
			}
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
			else if(z < LevelZ[5])
				return 4;
			else if(z < LevelZ[6])
				return 5;
			else
				return 6;
		}

		public Bitmap GetPreviewImage(int level)
		{
			int xMin = int.MaxValue, yMin = int.MaxValue;
			int xMax = int.MinValue, yMax = int.MinValue;

			for ( int i = 0; i <= level; ++i )
			{
				for ( int x = 0, vx = 0; x < m_Width; ++x, vx += 22 )
				{
					int px = vx, py = vx;

					for ( int y = 0; y < m_Height; ++y, px -= 22, py += 22 )
					{
						ArrayList components = m_Components[x][y][i];

						for ( int j = 0; j < components.Count; ++j )
						{
							HouseComponent hc = (HouseComponent)components[j];

							Bitmap img = hc.Image;

							int dx = px - (img.Width / 2);
							int dy = py - (hc.Z * 4) - img.Height;

							if ( dx < xMin )
								xMin = dx;

							if ( dy < yMin )
								yMin = dy;

							dx += img.Width;
							dy += img.Height;

							if ( dx > xMax )
								xMax = dx;

							if ( dy > yMax )
								yMax = dy;
						}
					}
				}
			}

			if ( xMin == int.MaxValue || yMin == int.MaxValue || xMax == int.MinValue || yMax == int.MinValue )
				return new Bitmap( 0, 0 );

			Bitmap bmp = new Bitmap( xMax - xMin, yMax - yMin );
			Graphics g = Graphics.FromImage( bmp );

			int xOffset = -xMin;
			int yOffset = -yMin;

			for ( int i = 0; i <= level; ++i )
			{
				for ( int x = 0, vx = 0; x < m_Width; ++x, vx += 22 )
				{
					int px = vx + xOffset, py = vx + yOffset;

					for ( int y = 0; y < m_Height; ++y, px -= 22, py += 22 )
					{
						ArrayList components = m_Components[x][y][i];

						for ( int j = 0; j < components.Count; ++j )
						{
							HouseComponent hc = (HouseComponent)components[j];

							g.DrawImage( hc.Image, px - (hc.Image.Width / 2), py - (hc.Z * 4) - hc.Image.Height );
						}
					}
				}
			}

			g.Dispose();

			return bmp;
		}

	}

	public class BuildEntry : IComparable
	{
		public int m_X, m_Y, m_Width, m_Height, m_Z, m_Index, m_Count;
		public int m_PairIndex, m_Level;
		public int m_Hue = 0;

		public BuildEntry( int x, int y, int z, int index, int count, int level )
		{
			m_X = x;
			m_Y = y;
			m_Width = 1;
			m_Height = 1;
			m_Z = z;
			m_Index = index;
			m_Count = count;
			m_Level = level;
		}

		public bool CombineWith( BuildEntry e )
		{
			if ( m_Level == e.m_Level && m_Z == e.m_Z && m_X == (e.m_X + e.m_Width) && m_Y == e.m_Y && m_Height == e.m_Height && m_Index == e.m_Index && e.m_Count == m_Count )
			{
				e.m_Width += m_Width;
				return true;
			}
			else if ( m_Level == e.m_Level && m_Z == e.m_Z && m_Y == (e.m_Y + e.m_Height) && m_X == e.m_X && m_Width == e.m_Width && m_Index == e.m_Index && e.m_Count == m_Count )
			{
				e.m_Height += m_Height;
				return true;
			}

			return false;
		}

		public void Send()
		{
			if ( m_Count == 1 )
				Client.SendText( "[TileRXYZ {0} {1} {2} {3} {4} Static {5}", m_X, m_Y, m_Width, m_Height, m_Z, m_Index );
			else
				Client.SendText( "[TileRXYZ {0} {1} {2} {3} {4} Static {5} {6}", m_X, m_Y, m_Width, m_Height, m_Z, m_Index, m_Count );
		}

		public void Append( StringBuilder sb )
		{
			if ( m_Count == 1 )
				sb.AppendFormat( "[TileRXYZ {0} {1} {2} {3} {4} Static {5}\r\n", m_X, m_Y, m_Width, m_Height, m_Z, m_Index );
			else
				sb.AppendFormat( "[TileRXYZ {0} {1} {2} {3} {4} Static {5} {6}\r\n", m_X, m_Y, m_Width, m_Height, m_Z, m_Index, m_Count );
		}

		public int CompareTo(object obj)
		{
			BuildEntry be = (BuildEntry)obj;

			if ( m_Y < be.m_Y )
				return -1;
			else if ( be.m_Y < m_Y )
				return 1;
			else if ( m_X < be.m_X )
				return -1;
			else if ( be.m_X < m_X )
				return 1;

			return 0;
		}
	}
}