using System;
using System.Drawing;
using Ultima;
using System.Data;

namespace UOArchitect
{
	public class HouseComponent : IComparable
	{
		private int m_Index, m_Z, m_Height;
		private int m_BaseIndex, m_Count;
		private int m_Hue = 0;
		private Bitmap m_Image;

		public int Index{ get{ return m_Index; } }
		public int Z{ get{ return m_Z; } }
		public int Height{ get{ return m_Height; } }
		public Bitmap Image{ get{ return m_Image; } }

		public int Hue
		{
			get{ return m_Hue; }
			set
			{
				ApplyHue(value);
			}
		}

		public int BaseIndex{ get{ return m_BaseIndex; } }
		public int Count{ get{ return m_Count; } }

		public HouseComponent( int index, int z )
		{
			m_Index = index;
			m_Z = z;

			m_Height = TileData.ItemTable[index].CalcHeight;
			m_Image = Art.GetStatic( index );

			// apply hue to image
			ApplyHue(0);

			m_BaseIndex = index;
			m_Count = 1;
		}

		private void ApplyHue(int hue)
		{
			if(m_Image == null || hue != m_Hue)
				m_Image = (Bitmap)Art.GetStatic(m_Index).Clone();

			if(hue == m_Hue)
				return;

			m_Hue = hue;

			if(m_Hue > 0)
			{
				Hues.GetHue(m_Hue).ApplyTo(m_Image, false);
			}
		}

		public HouseComponent( int index, int z, int baseIndex, int count )
		{
			m_Index = index;
			m_Z = z;

			m_Height = TileData.ItemTable[index].CalcHeight;
			m_Image = Art.GetStatic( index );

			m_BaseIndex = baseIndex;
			m_Count = count;
		}

		public int CompareTo( object obj )
		{
			HouseComponent hc = (HouseComponent)obj;

			if ( m_Z < hc.m_Z )
				return -1;
			else if ( hc.m_Z < m_Z )
				return 1;
			else if ( m_Height < hc.m_Height )
				return -1;
			else if ( hc.m_Height < m_Height )
				return 1;

			return 0;
		}
	}
}