using System;
using UOArchitectInterface;

namespace UOArchitect
{
	public abstract class BaseDesignAdapter
	{
		private string _filter;
		private string _title;

		public abstract DesignData ImportDesign();
		public abstract void Export(DesignData design);

		protected virtual string GetImportFileName()
		{
			return Utility.BrowseForFile(_filter, _title);
		}

		protected virtual string GetExportFileName()
		{
			return GetExportFileName("");
		}

		protected virtual string GetExportFileName(string defaultName)
		{
			return Utility.GetSaveFileName(_filter, _title, defaultName);
		}

		private BaseDesignAdapter()
		{
		}

		public BaseDesignAdapter(string filter, string title)
		{
			_filter = filter;
			_title = title;
		}

		public string filter
		{
			get{ return _filter; }
		}

		public string Title
		{
			get{ return _title; }
		}
	}
}
