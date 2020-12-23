using System;
using System.IO;
using UOArchitectInterface;

namespace UOArchitect
{
	public class MultiTextDataAdapter : BaseDesignAdapter
	{
		public MultiTextDataAdapter() : base("(*.txt)|*.txt", "Multi Text")
		{
		}

		public override DesignData ImportDesign()
		{
			string filename = GetImportFileName();

			if(!File.Exists(filename))
				return null;

			DesignData design = new DesignData();
			DesignItemCol designItems = new DesignItemCol();

			StreamReader reader = new StreamReader(File.OpenRead(filename));
			string[] TextArr;
			string Text;

			char[] Separator = { ' ' };

			try
			{
				while(reader.Peek() > -1)
				{
					Text = reader.ReadLine();

					if(IsMultiBlock(Text))
					{
						TextArr = Text.Split(Separator);
						
						DesignItem designItem = new DesignItem();
						designItem.ItemID = short.Parse(TextArr[0]);
						designItem.X = int.Parse(TextArr[1]);
						designItem.Y = int.Parse(TextArr[2]);
						designItem.Z = int.Parse(TextArr[3]);

						designItems.Add(designItem);
					}
				}

				design.ImportItems(designItems,true, false);
			}
			catch
			{
			}
			finally
			{
				reader.Close();
			}

			return design;
		}

		private bool IsMultiBlock(string Text)
		{
			bool Result = true;

			if(Text.IndexOf("version") > 0)
				Result = false;
			else if(Text.IndexOf("template") > 0)
				Result = false;
			else if(Text.IndexOf("components") > 0)
				Result = false;

			return Result;
		}

		public override void Export(DesignData design)
		{
			string filename = GetExportFileName(design.Name);

			if(filename.Length > 0)
			{
				if(!design.IsLoaded)
					design.Load();

				using ( StreamWriter sw = new StreamWriter( filename, false ) )
				{
					sw.WriteLine( "6 version" );
					sw.WriteLine( "1 template id" );
					sw.WriteLine( "-1 item version" );

					sw.WriteLine( "{0} num components", design.Items.Count );

					for(int i = 0; i < design.Items.Count; ++i )
					{
						DesignItem item = design.Items[i];
						sw.WriteLine( "{0} {1} {2} {3} 1", item.ItemID, item.X, item.Y, item.Z );
					}
				}
			}
		}
	}
}
