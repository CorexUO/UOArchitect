using System;
using System.Collections;
using OrbServerSDK;
using System.Windows.Forms;
using UOArchitectInterface;
using System.Threading;

namespace UOArchitect
{
	public class Connection
	{
		public delegate void ConnectEvent();
		public delegate void DisconnectEvent();
		public delegate void ClientBusyEvent();
		public delegate void ClientReadyEvent();

		public static ConnectEvent OnConnect;
		public static DisconnectEvent OnDisconnect;
		public static ClientBusyEvent OnBusy;
		public static ClientReadyEvent OnReady;

		private static bool _busy = false;

		public static bool IsBusy
		{
			get{ return _busy; }
		}

		public static bool IsConnected
		{
			get{ return OrbClient.IsConnected; }
		}
		
		private static void ExecuteCommand(string alias, OrbCommandArgs args)
		{ 
			RaiseBusyEvent();
			OrbClient.SendCommand(alias, args);
			RaiseReadyEvent();
		}

		private static OrbResponse ExecuteRequest(string alias, OrbRequestArgs args)
		{ 
			RaiseBusyEvent();
			OrbResponse resp = OrbClient.SendRequest(alias, args);
			RaiseReadyEvent();

			return resp;
		}

		public static bool ConnectToServer()
		{
			bool success = false;
			LoginResult result = OrbClient.LoginToServer(Config.UserName, Config.Password, Config.ServerIP, Config.Port);

			if(result.Code == LoginCodes.Success)
			{
				success = true;
			}
			else
			{
				MessageBox.Show(result.ErrorMessage);
				success = false;
			}

			if(success && OnConnect != null)
				// raise OnConnect event
				OnConnect();

			return success;
		}

		private static void RaiseBusyEvent()
		{
			if(OnBusy != null)
				OnBusy();
		}

		private static void RaiseReadyEvent()
		{
			if(OnReady != null)
				OnReady();
		}

		public static void Disconnect()
		{
			OrbClient.Disconnect();

			if(OnDisconnect != null)
				// raise disconnect event
				OnDisconnect();
		}

		public static BuildResponse BuildDesign(DesignItemCol items)
		{
			if(items.Count == 0)
				return null;

			Ultima.Client.BringToTop();
			BuildRequestArgs args = new BuildRequestArgs(items);
			
			return (BuildResponse)ExecuteRequest("UOAR_BuildDesign", new BuildRequestArgs(items));
		}

		public static ExtractResponse ExtractDesign(ExtractRequestArgs args)
		{	
			Ultima.Client.BringToTop();
			
			return (ExtractResponse)ExecuteRequest("UOAR_ExtractDesign", args);
		}

		public static void SendMoveItemsCommand(MoveItemsArgs args)
		{
			if(args == null || args.ItemSerials == null || args.ItemSerials.Length == 0)
				return;

			Ultima.Client.BringToTop();
			ExecuteCommand("UOAR_MoveItems", args);
		}

		public static void SendDeleteItemsCommand(DeleteCommandArgs args)
		{
			if(args == null || args.ItemSerials == null || args.ItemSerials.Length == 0)
				return;

			Ultima.Client.BringToTop();
			ExecuteCommand("UOAR_DeleteItems", args);
		}

		public static SelectItemsResponse SendSelectItemsRequest(SelectItemsRequestArgs args)
		{
			Ultima.Client.BringToTop();

			return (SelectItemsResponse)OrbClient.SendRequest("UOAR_SelectItems", args);
		}

		public static GetLocationResp SendGetLocationRequest(OrbRequestArgs args)
		{
			Ultima.Client.BringToTop();

			return (GetLocationResp)OrbClient.SendRequest("UOAR_GetLocation", args);
		}
	
	}
}
