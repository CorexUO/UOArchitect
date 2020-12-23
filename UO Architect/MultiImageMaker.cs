using System;
using System.Drawing;
using System.IO;
using Ultima;
using System.Collections;

namespace UOArchitect
{
	public sealed class DesignImageMaker
	{
		private struct MultiTileEntry2
		{
			public short m_ItemID;

			public short m_OffsetX;

			public short m_OffsetY;

			public short m_OffsetZ;

			public int m_Flags;

		}

		private Point m_Min;

		private Point m_Max;

		private Point m_Center;

		private int m_Width;

		private int m_Height;

		private Tile[][][] m_Tiles;

		public readonly static DesignImageMaker Empty = new DesignImageMaker();


		public Point Min
		{
			get
			{
				return m_Min;
			}
		}

		public Point Max
		{
			get
			{
				return m_Max;
			}
		}

		public Point Center
		{
			get
			{
				return m_Center;
			}
		}

		public int Width
		{
			get
			{
				return m_Width;
			}
		}

		public int Height
		{
			get
			{
				return m_Height;
			}
		}

		public Tile[][][] Tiles
		{
			get
			{
				return m_Tiles;
			}
		}

		public Bitmap GetImage()
		{
			Bitmap bitmap4;

			if (m_Width == 0 || m_Height == 0)
			{
				bitmap4 = null;
			}
			else
			{
				int i1 = 1000;
				int j1 = 1000;
				int k1 = -1000;
				int i2 = -1000;

				for (int j2 = 0; j2 < m_Width; j2++)
				{
					for (int k2 = 0; k2 < m_Height; k2++)
					{
						Tile[] tiles1 = m_Tiles[j2][k2];

						for (int i3 = 0; i3 < (int)tiles1.Length; i3++)
						{
							Bitmap bitmap1 = Art.GetStatic(tiles1[i3].ID - 16384);

							if (bitmap1 != null)
							{
								int j3 = (j2 - k2) * 22;
								int k3 = (j2 + k2) * 22;
								j3 -= bitmap1.Width / 2;
								k3 -= tiles1[i3].Z * 4;
								k3 -= bitmap1.Height;
								if (j3 < i1)
								{
									i1 = j3;
								}
								if (k3 < j1)
								{
									j1 = k3;
								}
								j3 += bitmap1.Width;
								k3 += bitmap1.Height;
								if (j3 > k1)
								{
									k1 = j3;
								}
								if (k3 > i2)
								{
									i2 = k3;
								}
							}
						}
					}
				}

				Bitmap bitmap2 = new Bitmap(k1 - i1, i2 - j1);
				Graphics graphics = Graphics.FromImage(bitmap2);

				for (int i4 = 0; i4 < m_Width; i4++)
				{
					int i6;

					for (int j4 = 0; j4 < m_Height; j4++)
					{
						Tile[] tiles2 = m_Tiles[i4][j4];

						for (int k4 = 0; k4 < (int)tiles2.Length; k4++)
						{
							Bitmap bitmap3 = Art.GetStatic(tiles2[k4].ID - 16384);

							if (bitmap3 != null)
							{
								int i5 = (i4 - j4) * 22;
								int j5 = (i4 + j4) * 22;
								i5 -= bitmap3.Width / 2;
								j5 -= tiles2[k4].Z * 4;
								j5 -= bitmap3.Height;
								i5 -= i1;
								j5 -= j1;
								graphics.DrawImageUnscaled(bitmap3, i5, j5, bitmap3.Width, bitmap3.Height);
							}
						}

						int k5 = (i4 - j4) * 22;

						i6 = (i4 + j4) * 22;
						k5 -= i1;
						i6 -= j1;
					}
				}

				graphics.Dispose();
				bitmap4 = bitmap2;
			}
			return bitmap4;
		}

		public DesignImageMaker(BinaryReader reader, int count)
		{
			Point point;

			m_Max = point = Point.Empty;
			m_Min = point;
			MultiTileEntry2[] multiTileEntrys = new MultiTileEntry2[count];

			for (int i1 = 0; i1 < count; i1++)
			{
				multiTileEntrys[i1].m_ItemID = reader.ReadInt16();
				multiTileEntrys[i1].m_OffsetX = reader.ReadInt16();
				multiTileEntrys[i1].m_OffsetY = reader.ReadInt16();
				multiTileEntrys[i1].m_OffsetZ = reader.ReadInt16();
				multiTileEntrys[i1].m_Flags = reader.ReadInt32();
				MultiTileEntry2 multiTileEntry = multiTileEntrys[i1];

				if (multiTileEntry.m_OffsetX < m_Min.X)
				{
					m_Min.X = multiTileEntry.m_OffsetX;
				}
				if (multiTileEntry.m_OffsetY < m_Min.Y)
				{
					m_Min.Y = multiTileEntry.m_OffsetY;
				}
				if (multiTileEntry.m_OffsetX > m_Max.X)
				{
					m_Max.X = multiTileEntry.m_OffsetX;
				}
				if (multiTileEntry.m_OffsetY > m_Max.Y)
				{
					m_Max.Y = multiTileEntry.m_OffsetY;
				}
			}

			m_Center = new Point(-m_Min.X, -m_Min.Y);
			m_Width = m_Max.X - m_Min.X + 1;
			m_Height = m_Max.Y - m_Min.Y + 1;
			TileList[][] tileLists = new TileList[m_Width][];
			m_Tiles = new Tile[m_Width][][];

			for (int j1 = 0; j1 < m_Width; j1++)
			{
				tileLists[j1] = new TileList[m_Height];
				m_Tiles[j1] = new Tile[m_Height][];
				for (int k1 = 0; k1 < m_Height; k1++)
				{
					tileLists[j1][k1] = new TileList();
				}
			}

			for (int i2 = 0; i2 < (int)multiTileEntrys.Length; i2++)
			{
				int j2 = multiTileEntrys[i2].m_OffsetX + m_Center.X;
				int k2 = multiTileEntrys[i2].m_OffsetY + m_Center.Y;
				tileLists[j2][k2].Add((short)((multiTileEntrys[i2].m_ItemID & 16383) + 16384), (sbyte)multiTileEntrys[i2].m_OffsetZ);
			}

			for (int i3 = 0; i3 < m_Width; i3++)
			{
				for (int j3 = 0; j3 < m_Height; j3++)
				{
					m_Tiles[i3][j3] = tileLists[i3][j3].ToArray();
					if ((int)m_Tiles[i3][j3].Length > 1)
					{
						Array.Sort(m_Tiles[i3][j3]);
					}
				}
			}
		}

		public DesignImageMaker(HouseDesign design, int MaxZ)
		{
			int count = design.FileHeader.RecordCount;
			Point point;

			m_Max = point = Point.Empty;
			m_Min = point;

			int index = 0;

			MultiTileEntry2[] multiTileEntrys = new MultiTileEntry2[count];

			for ( int i = 0; i < HouseDesign.Levels; ++i )
			{
				for ( int x = 0; x < design.Width; ++x )
				{
					for ( int y = 0; y < design.Height; ++y )
					{
						ArrayList list = design.Components[x][y][i];

						foreach ( HouseComponent hc in list )
						{
							if(MaxZ > 0 && hc.Z >= MaxZ)
								continue;

							multiTileEntrys[index].m_ItemID = (short)hc.Index;
							multiTileEntrys[index].m_OffsetX = (short)x;
							multiTileEntrys[index].m_OffsetY = (short)y;
							multiTileEntrys[index].m_OffsetZ = (short)hc.Z;
							multiTileEntrys[index].m_Flags = 0;
							MultiTileEntry2 multiTileEntry = multiTileEntrys[index];

							if (multiTileEntry.m_OffsetX < m_Min.X)
							{
								m_Min.X = multiTileEntry.m_OffsetX;
							}
							if (multiTileEntry.m_OffsetY < m_Min.Y)
							{
								m_Min.Y = multiTileEntry.m_OffsetY;
							}
							if (multiTileEntry.m_OffsetX > m_Max.X)
							{
								m_Max.X = multiTileEntry.m_OffsetX;
							}
							if (multiTileEntry.m_OffsetY > m_Max.Y)
							{
								m_Max.Y = multiTileEntry.m_OffsetY;
							}

							index++;
						}
					}
				}
			}

			m_Center = new Point(-m_Min.X, -m_Min.Y);
			m_Width = m_Max.X - m_Min.X + 1;
			m_Height = m_Max.Y - m_Min.Y + 1;
			TileList[][] tileLists = new TileList[m_Width][];
			m_Tiles = new Tile[m_Width][][];

			for (int j1 = 0; j1 < m_Width; j1++)
			{
				tileLists[j1] = new TileList[m_Height];
				m_Tiles[j1] = new Tile[m_Height][];
				for (int k1 = 0; k1 < m_Height; k1++)
				{
					tileLists[j1][k1] = new TileList();
				}
			}

			for (int i2 = 0; i2 < (int)multiTileEntrys.Length; i2++)
			{
				int j2 = multiTileEntrys[i2].m_OffsetX + m_Center.X;
				int k2 = multiTileEntrys[i2].m_OffsetY + m_Center.Y;
				tileLists[j2][k2].Add((short)((multiTileEntrys[i2].m_ItemID & 16383) + 16384), (sbyte)multiTileEntrys[i2].m_OffsetZ);
			}

			for (int i3 = 0; i3 < m_Width; i3++)
			{
				for (int j3 = 0; j3 < m_Height; j3++)
				{
					m_Tiles[i3][j3] = tileLists[i3][j3].ToArray();
					if ((int)m_Tiles[i3][j3].Length > 1)
					{
						Array.Sort(m_Tiles[i3][j3]);
					}
				}
			}
		}

		private DesignImageMaker()
		{
			m_Tiles = new Tile[0][][];
		}

	}

}
