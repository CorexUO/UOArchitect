using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using Ultima;

namespace UOArchitect
{
	public class TileSet
	{
		private ArrayList m_Entries;
		private Bitmap m_Image, m_SelectedImage;
		private string m_Name;
		private object m_ID;

		public ArrayList Entries{ get{ return m_Entries; } }
		public Bitmap Image{ get{ return m_Image; } }
		public Bitmap SelectedImage{ get{ return m_SelectedImage; } }
		public string Name{ get{ return m_Name; } }

		public static readonly TileSet Toolbox = LoadFromXml( "Internal/toolbox.xml" );

		public static TileSet LoadFromXml( string filePath )
		{
			using ( StreamReader sw = new StreamReader( filePath ) )
			{
				//StreamReader sw = new StreamReader( filePath );
				XmlDocument xml = new XmlDocument();

				//xml.Load( sw );
				xml.Load( filePath );
				XmlElement rootNode = xml["root"];

				TileSet root = new TileSet( (string)null );

				foreach ( XmlElement e in rootNode )
					root.AddSet( new TileSet( e ) );

				return root;
			}
		}

		public TileSet( XmlElement e )
		{
			m_Entries = new ArrayList();

			string id = e.GetAttribute( "id" );
			string name = e.GetAttribute( "name" );

			try
			{
				int index = Convert.ToInt32( id );

				m_ID = index;
				m_Name = name;
				m_Image = Art.GetStatic( index );
			}
			catch
			{
				m_ID = id;
				m_Name = name;
				m_Image = new Bitmap( "Internal/Graphics/" + id + "_reg.png" );
				m_SelectedImage = new Bitmap( "Internal/Graphics/" + id + "_sel.png" );
			}

			foreach ( XmlNode node in e )
			{
				if ( node is XmlElement )
				{
					if ( node.Name == "group" )
						AddSet( new TileSet( (XmlElement)node ) );
					else if ( node.Name == "entry" )
						m_Entries.Add( new TileSetEntry( (XmlElement)node ) );
				}
			}
		}

		public TileSet( string name ) : this( name, null, null )
		{
		}

		public TileSet( string name, string fname ) : this( name, new Bitmap( "Internal/Graphics/" + fname + "_reg.png" ), new Bitmap( "Internal/Graphics/" + fname + "_sel.png" ) )
		{
			m_ID = fname;
		}

		public TileSet( string name, int index ) : this( name, Art.GetStatic( index ), null )
		{
			m_ID = index;
		}

		public TileSet( string name, Bitmap image, Bitmap selectedImage )
		{
			m_Name = name;
			m_Image = image;
			m_SelectedImage = selectedImage;
			m_Entries = new ArrayList();
		}

		public void Save( XmlTextWriter xml )
		{
			if ( m_ID != null )
			{
				xml.WriteStartElement( "group" );
				xml.WriteAttributeString( "id", m_ID==null?"":m_ID.ToString() );
				xml.WriteAttributeString( "name", m_Name );
			}

			foreach ( object o in m_Entries )
			{
				if ( o is TileSet )
					((TileSet)o).Save( xml );
				else if ( o is TileSetEntry )
					((TileSetEntry)o).Save( xml );
			}

			if ( m_ID != null )
				xml.WriteEndElement();
		}

		public void AddEntry( int index )
		{
			m_Entries.Add( new TileSetEntry( index ) );
		}

		public void AddEntry( int index, int count )
		{
			m_Entries.Add( new TileSetEntry( index, count ) );
		}

		public void AddEntry( int[] tiles )
		{
			m_Entries.Add( new TileSetEntry( tiles ) );
		}

		public void AddSet( TileSet tileSet )
		{
			m_Entries.Add( tileSet );
		}
	}

	public class TileSetEntry
	{
		private static Random m_Random = new Random();

		private int[] m_Tiles;
		private Bitmap m_Image;

		private bool m_Destroy;

		private int m_BaseIndex, m_Count;

		public int[] Tiles{ get{ return m_Tiles; } }
		public Bitmap Image{ get{ return m_Image; } }

		public int BaseIndex{ get{ return m_BaseIndex; } }
		public int Count{ get{ return m_Count; } }

		public bool Destroy{ get{ return m_Destroy; } }

		public static Random Random{ get{ return m_Random; } }

		public void Save( XmlTextWriter xml )
		{
			xml.WriteStartElement( "entry" );
			xml.WriteAttributeString( "index", m_BaseIndex.ToString() );

			if ( m_Count != 1 )
				xml.WriteAttributeString( "count", m_Count.ToString() );

			xml.WriteEndElement();
		}

		public TileSetEntry( XmlElement e )
		{
			string index = e.GetAttribute( "index" );
			string count = e.GetAttribute( "count" );

			m_BaseIndex = Convert.ToInt32( index );
			m_Count = (count=="")? 1: Convert.ToInt32( count );

			if ( m_Count == 0 )
			{
				m_Image = new Bitmap( "Internal/Graphics/cursor_del.png" );
				m_Destroy = true;
			}
			else
			{
				m_Image = Art.GetStatic( m_BaseIndex );
			}

			m_Tiles = new int[m_Count];

			for ( int i = 0; i < m_Count; ++i )
				m_Tiles[i] = m_BaseIndex + i;
		}

		public TileSetEntry( int index ) : this( index, 1 )
		{
		}

		public int GetRandomIndex() 
		{
			if ( m_Tiles.Length == 0 )
				return -1;

			return m_Tiles[m_Random.Next( m_Tiles.Length )];
		}

		public TileSetEntry( int index, int count )
		{
			m_BaseIndex = index;
			m_Count = count;

			m_Tiles = new int[count];

			for ( int i = 0; i < count; ++i )
				m_Tiles[i] = index + i;

			m_Image = Art.GetStatic( m_Tiles[0] );
		}

		public TileSetEntry( int[] tiles )
		{
			m_Tiles = tiles;

			if ( tiles.Length == 0 )
				m_Image = new Bitmap( "Internal/Graphics/cursor_del.png" );
			else
				m_Image = Art.GetStatic( m_Tiles[0] );
		}
	}
}