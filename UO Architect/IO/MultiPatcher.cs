using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UOArchitectInterface;

namespace UOArchitect
{
	public class MultiPatcher
	{
		private DesignData mDesign;
		private PatchInfo mPatchInfo;
		private ArrayList mIndexes;
		private ArrayList mItemBlocks;
		private int mFreeSlot = -1;
		private ArrayList mComponents;

		public MultiPatcher(PatchInfo patchInfo)
		{
			mPatchInfo = patchInfo;
			mIndexes = new ArrayList(10000);
			mItemBlocks = new ArrayList(20000);
		}

		public int PatchMulti(DesignData design, ArrayList Components)
		{
			bool Success;
			
			mDesign = design;
			mComponents = Components;

			Success = LoadSourceMultiIndex();
			Success = LoadSourceMultiMul();

			if(Success)
			{
				UpdateIndex();
				AddBlocksToMultiMul();
				GenerateNewMultiIdxFile();
				GenerateNewMultiMulFile();
			}
			
			if(Success)
				return mFreeSlot;
			else
				return -1;
		}

		private void GenerateNewMultiIdxFile()
		{
			FileStream file = new FileStream(mPatchInfo.MultiIdx, FileMode.Create, FileAccess.Write, FileShare.None);
			BinaryWriter writer = new BinaryWriter(file);

			foreach(FileIndex index in mIndexes)
			{
				writer.Write(index.Lookup);
				writer.Write(index.Length);
				writer.Write(index.Extra);
			}

			writer.Close();
			file.Close();
		}

		private void GenerateNewMultiMulFile()
		{
			FileStream file = new FileStream(mPatchInfo.MultiMul, FileMode.Create, FileAccess.Write, FileShare.None);
			BinaryWriter writer = new BinaryWriter(file);

			foreach(MultiDataFile data in mItemBlocks)
			{
				writer.Write(data.ItemID);
				writer.Write(data.X);
				writer.Write(data.Y);
				writer.Write(data.Z);
				writer.Write(data.IsVisible);
			}

			writer.Close();
			file.Close();
		}

		private void UpdateIndex()
		{
			FileIndex index = (FileIndex)mIndexes[mFreeSlot];
			int position = mItemBlocks.Count * 12;

			index.Lookup = position;
			index.Length = (mDesign.Items.Count + 1) * 12;

			mIndexes[mFreeSlot] = index;
		}

		private void AddBlocksToMultiMul()
		{
			MultiDataFile data;

			if(mDesign.Items.Count > 0)
			{
				data = new MultiDataFile();

				data.ItemID = 1;
				data.X = 0;
				data.Y = 0;
				data.Z = 0;
				data.IsVisible = 0;

				mItemBlocks.Add(data);
			}

			foreach(DesignItem block in mDesign.Items)
			{
				data = new MultiDataFile();
			
				data.ItemID = (short)block.ItemID;
				data.X = (short)block.X;
				data.Y = (short)block.Y;
				data.Z = (short)block.Z;

				if(mComponents != null && mComponents.Contains((int)data.ItemID))
				{
					data.IsVisible = 0;
				}
				else
					data.IsVisible = 1;
	
				mItemBlocks.Add(data);
			}

		}

		private bool LoadSourceMultiIndex()
		{
			FileStream file = new FileStream(mPatchInfo.MultiIdx, FileMode.Open, FileAccess.Read, FileShare.Read);
			BinaryReader reader = new BinaryReader(file);
			FileIndex index;
			int IndexNumber = 0;
			bool Success = false;

			try
			{
				while(reader.BaseStream.Position < reader.BaseStream.Length)
				{
					// calculate the current index number for the current position
					IndexNumber = (int)reader.BaseStream.Position / 12;
					index = new FileIndex();
				
					index.Lookup = (int)reader.ReadInt32();
					index.Length = (int)reader.ReadInt32();
					index.Extra = (int)reader.ReadInt32();

					mIndexes.Add(index);

					if( (mFreeSlot == -1) && (index.Lookup == -1) )
						// This is the slot the new multi will be patched to
						mFreeSlot = IndexNumber;
					
				}

				Success = true;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				reader.Close();
				file.Close();
				Success = false;
			}

			if(mIndexes.Count > 0)
				Success = true;
			else
				Success = false;

			return Success;
		}

		private bool LoadSourceMultiMul()
		{
			FileStream file = new FileStream(mPatchInfo.MultiMul, FileMode.Open, FileAccess.Read, FileShare.Read);
			BinaryReader reader = new BinaryReader(file);
			MultiDataFile data;
			bool Success = false;

			try
			{
				while(reader.BaseStream.Position < reader.BaseStream.Length)
				{
					data = new MultiDataFile();

					data.ItemID = reader.ReadInt16();

					data.X = reader.ReadInt16();
					data.Y = reader.ReadInt16();
					data.Z = reader.ReadInt16();
					data.IsVisible = reader.ReadInt32();

					mItemBlocks.Add(data);
				}

				Success = true;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				reader.Close();
				file.Close();
				Success = false;
			}

			if(mIndexes.Count > 0)
				Success = true;
			else
				Success = false;

			return Success;
		}

		public PatchInfo Patch
		{
			get{ return mPatchInfo; }
		}
	}

	public struct PatchInfo
	{
		private string mMultiMul;
		private string mMultiIdx;

		public string MultiMul
		{
			get{ return mMultiMul; }
			set{ mMultiMul = value; }
		}

		public string MultiIdx
		{
			get{ return mMultiIdx; }
			set{ mMultiIdx = value; }
		}

	}

	public struct FileIndex
	{
		private int mLookup;
		private int mLength;
		private int mExtra;

		public int Lookup
		{
			get{ return mLookup; }
			set{ mLookup = value; }
		}

		public int Length
		{
			get{ return mLength; }
			set{ mLength = value; }
		}

		public int Extra
		{
			get{ return mExtra; }
			set{ mExtra = value; }
		}
	}

	public struct MultiDataFile
	{
		//List Items[length / 12]: 
		public short ItemID;
		public short X;
		public short Y;
		public short Z;
		public int IsVisible; // 0=no, 1=yes

		//The center is at XYZ (0,0,0). The list needs to be sorted
	}
}
