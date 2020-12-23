using System;
using System.Windows.Forms;
using UOArchitectInterface;
using Ultima;
using System.Threading;

namespace UOArchitect
{
	public class ItemSelector
	{
		public delegate void ItemsSelectedtEvent(SelectItemsResponse response);
		public ItemsSelectedtEvent OnSelection;

		public SelectItemsResponse SelectItems(SelectItemsRequestArgs args, bool asyncronous)
		{
			if(asyncronous)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(StartSelection), args);
				return null;
			}
			else
			{
				return (SelectItemsResponse)Connection.SendSelectItemsRequest(args);
			}
		}

		private void StartSelection(object state)
		{
			SelectItemsRequestArgs args = (SelectItemsRequestArgs)state;

			SelectItemsResponse resp = (SelectItemsResponse)Connection.SendSelectItemsRequest(args);
			RaiseSelectionEvent(resp);
		}

		private void RaiseSelectionEvent(SelectItemsResponse response)
		{
			if(OnSelection != null)
				OnSelection(response);
		}
	}
}
