using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace UOArchitect
{
	public class Utility
	{
		public static string BrowseForFile(string filter, string title)
		{
			OpenFileDialog dlgOpenFile = new OpenFileDialog();

			dlgOpenFile.CheckFileExists = true;
			dlgOpenFile.CheckPathExists = true;
			dlgOpenFile.Title = title;
			dlgOpenFile.Filter = filter;
			dlgOpenFile.RestoreDirectory = true;
			dlgOpenFile.ShowDialog();

			return dlgOpenFile.FileName;
		}

		public static string[] BrowseForFiles(string filter, string title)
		{
			OpenFileDialog dlgOpenFile = new OpenFileDialog();

			dlgOpenFile.CheckFileExists = true;
			dlgOpenFile.CheckPathExists = true;
			dlgOpenFile.Title = title;
			dlgOpenFile.Filter = filter;
			dlgOpenFile.RestoreDirectory = true;
			dlgOpenFile.Multiselect = true;
			dlgOpenFile.ShowDialog();

			return dlgOpenFile.FileNames;
		}

		public static string GetSaveFileName(string filter, string title)
		{
			return  GetSaveFileName(filter, title, "");
		}

		public static string GetSaveFileName(string filter, string title, string fileName)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = title;
			dlg.Filter = filter;
			dlg.FileName = StripInvalidFilenameChars(fileName);
			dlg.CheckPathExists = true;
			dlg.AddExtension = true;
			dlg.OverwritePrompt = true;
			dlg.ValidateNames = true;
			dlg.RestoreDirectory = true;

			string FileName = "";

			if(dlg.ShowDialog() == DialogResult.OK)
			{
				FileName = dlg.FileName;
				dlg.Dispose();
			}

			return FileName;
		}

		private static string StripInvalidFilenameChars(string fileName)
		{
			StringBuilder text = new StringBuilder(fileName);

			text.Replace(@"\", "");
			text.Replace(@"/", "");
			text.Replace(@"*", "");
			text.Replace("?", "");
			text.Replace("<", "");
			text.Replace(">", "");
			text.Replace("|", "");
			text.Replace(":", "");

			return text.ToString();
		}

		public static string ToHex(int Value)
		{
			return String.Format("0x{0:X}", Value);
		}

		public static int ToInt(string Value)
		{
			int i;

			try
			{
				if (Value.StartsWith("0x"))
				{
					i = Convert.ToInt32(Value.Substring(2), 16);
				}
				else
				{
					i = Convert.ToInt32(Value);
				}
			}
			catch
			{
				i = 0;
			}
			return i;
		}

		public static void SaveImageToDisk(Image image, ImageFormat format, Form owner)
		{
			string filter = null;
			string ext = null;

			switch(format.ToString())
			{
				case "Bmp":
					filter = "(Bitmap *.bmp)|*.bmp";
					ext = "bmp";
					break;

				case "Jpeg":
					filter = "(Jpg *.jpg)|*.jpg";
					ext = "jpg";
					break;

				case "Png":
					filter = "(Png *.png)|*.png";
					ext = "png";
					break;

				case "Gif":
					filter = "(Gif *.gif)|*.gif";
					ext = "gif";
					break;
			}

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Save Picture";
			dlg.DefaultExt = ext;
			dlg.Filter = filter;
			dlg.CheckPathExists = true;
			dlg.AddExtension = true;
			dlg.OverwritePrompt = true;
			dlg.ValidateNames = true;
			dlg.RestoreDirectory = true;
			dlg.ShowDialog(owner);

			string file = dlg.FileName;
			dlg.Dispose();

			if(file != "")
				image.Save(file, format);
		}

		public static void OpenWebLink(string url)
		{
			System.Diagnostics.Process.Start(url);
		}

		public static void SendClientCommand(string command)
		{
			try
			{
				Ultima.Client.BringToTop();
				Ultima.Client.SendText(Config.CommandPrefix + command);
			}
			catch
			{
			}
		}
	}
}
