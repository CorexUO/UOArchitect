using System;

namespace UOArchitect
{
	public class ComponentRecord
	{
		public int Version;
		public int Index;
		public int X;
		public int Y;
		public int Z;
		public int Level;
		public int Hue;

		public ComponentRecord(int version, int index, int x, int y, int z, int hue, int level)
		{
			Version = version;
			Index = index;
			X = x;
			Y = y;
			Z = z;
			Level = level;
			Hue = hue;
		}

		public void Deserialize(BinaryFileReader reader)
		{
			Version = reader.ReadInt();

			switch(Version)
			{
				case 0:
					Index = reader.ReadInt();
					X = reader.ReadInt();
					Y = reader.ReadInt();
					Z = reader.ReadInt();
					Level = reader.ReadInt();
					break;
			}
		}

		public void Serialize(BinaryFileWriter writer)
		{
			writer.WriteInt(Version);

			switch(Version)
			{
				case 0:
					writer.WriteInt(Index);
					writer.WriteInt(X);
					writer.WriteInt(Y);
					writer.WriteInt(Z);
					writer.WriteInt(Level);
					break;
			}
		}


	}
}
