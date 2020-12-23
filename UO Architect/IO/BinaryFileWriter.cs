using System;
using System.IO;

namespace UOArchitect
{
	public class BinaryFileWriter
	{
		private BinaryWriter m_Writer;
		private FileStream m_File;

		public BinaryFileWriter(FileStream stream)
		{
			m_File = stream;
			m_Writer = new BinaryWriter(stream);
		}

		public void WriteString(string value)
		{
			byte flag = (byte)(value != null ? 1 : 0);

			m_Writer.Write(flag);

			if(flag == 1)
				m_Writer.Write(value);
		}

		public void WriteInt(int value)
		{
			m_Writer.Write(value);
		}

		public void WriteShort(short value)
		{
			m_Writer.Write(value);
		}

		public void WriteBool(bool value)
		{
			m_Writer.Write(value);
		}

		public void WriteByte(byte value)
		{
			m_Writer.Write(value);
		}

		public void WriteSByte(SByte value)
		{
			m_Writer.Write(value);
		}

		public void WriteChar(char value)
		{
			m_Writer.Write(value);
		}

		public void WriteDecimal(decimal value)
		{
			m_Writer.Write(value);
		}

		public void WriteFloat(float value)
		{
			m_Writer.Write(value);
		}

		public void WriteLong(long value)
		{
			m_Writer.Write(value);
		}

		public long Position
		{
			get{ return m_File.Position; }
		}

		public Stream BaseStream
		{
			get{ return m_File; }
		}

		public void Close()
		{
			m_File.Close();
		}
		
	}
}
