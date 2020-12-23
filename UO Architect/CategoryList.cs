using System;
using System.Collections;

namespace UOArchitect
{
	public class CategoryList
	{
		public delegate void CategoryRefresh();
		public static CategoryRefresh OnRefresh;
		
		private static Hashtable m_Categories = new Hashtable(0, new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
		
		static CategoryList()
		{
			LoadCategories(HouseDesignData.DesignHeaders);
		}

		public static void Refresh()
		{
			m_Categories.Clear();
			LoadCategories(HouseDesignData.DesignHeaders);

			if(OnRefresh != null)
				OnRefresh();
		}

		public static string[] GetSubSectionNames(string category)
		{
			string[] subSectionList = null;
			Hashtable subSections = (Hashtable)m_Categories[category];
			
			if(subSections != null)
			{
				subSectionList = new string[subSections.Count];
				subSections.Keys.CopyTo(subSectionList, 0);
			}

			return subSectionList;
		}

		public static string[] GetCategoryNames()
		{
			string[] names = null;

			if(m_Categories.Count > 0)
			{
				names = new string[m_Categories.Count];
				m_Categories.Keys.CopyTo(names, 0);
			}

			return names;
		}

		public static ArrayList GetHeaderList(string category, string subSection)
		{
			ArrayList headers = new ArrayList();
			ArrayList list = HouseDesignData.DesignHeaders;

			for(int i=0; i < list.Count; ++i)
			{
				DesignData header = (DesignData)list[i];

				if(String.Compare(header.Category, category, true) != 0)
					continue;

				if(String.Compare(header.Subsection, subSection, true) != 0)
					continue;

				headers.Add(header);
			}
			
			return headers;
		}

		private static void LoadCategories(ArrayList headers)
		{
			for(int i=0; i < headers.Count; ++i)
			{
				DesignData header = (DesignData)headers[i];

				string category = (header.Category == null || header.Category.Length == 0) ? "Misc" : header.Category;
				string subSection = (header.Subsection == null || header.Subsection.Length == 0) ? "Misc" : header.Subsection;
				
				Hashtable subSections = GetSubSections(category);
				
				if(!subSections.ContainsKey(subSection))
					subSections.Add(subSection, null);
				
			}
		}

		private static Hashtable GetSubSections(string category)
		{
			Hashtable subSections = null;

			if(!m_Categories.ContainsKey(category))
			{
				subSections = new Hashtable(0, new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
				m_Categories.Add(category, subSections);
			}
			else
			{
				subSections = (Hashtable)m_Categories[category];
			}

			return subSections;
		}

	}
}
