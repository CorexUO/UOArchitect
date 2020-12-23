using System;
using System.IO;

namespace UOArchitect
{
	public class BinaryFileReader
	{
		private FileStream m_File;
		private BinaryReader m_Reader;

		public BinaryFileReader(FileStream stream)
		{
			m_File = stream;
			m_Reader = new BinaryReader(m_File);
		}

		public bool EOF
		{
			get{ return (this.m_Reader.PeekChar() == -1); }
		}

		public void Seek(long offset, SeekOrigin origin)
		{
			m_File.Seek(offset, origin);
		}

		public long Position
		{
			get{ return m_File.Position; }
		}

		public void Close()
		{
			m_File.Close();
		}

		public string ReadString()
		{
			byte flag = m_Reader.ReadByte();

			if(flag == 0)
				return null;
			else
				return m_Reader.ReadString();
		}

		public int ReadInt()
		{
			return m_Reader.ReadInt32();
		}

		public long ReadLong()
		{
			return m_Reader.ReadInt64();
		}

		public bool ReadBool()
		{
			return m_Reader.ReadBoolean();
		}

		public short ReadShort()
		{
			return m_Reader.ReadInt16();
		}

		public byte ReadByte()
		{
			return m_Reader.ReadByte();
		}

		public SByte ReadSByte()
		{
			return m_Reader.ReadSByte();
		}

		public decimal ReadDecimal()
		{
			return m_Reader.ReadDecimal();
		}

		public float ReadFloat()
		{
			return m_Reader.ReadSingle();
		}

		public char ReadChar()
		{
			return m_Reader.ReadChar();
		}
	}
}
