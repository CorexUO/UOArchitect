using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using UOArchitectInterface;

namespace UOArchitect.Toolbox.TabPanels
{
	/// <summary>
	/// Summary description for MovePanel.
	/// </summary>
	public class MovePanel : System.Windows.Forms.UserControl
	{
		private bool _busy = false;
		private int[] _serials = null;
		private SelectItemsResponse _lastResponse = null;
		private DesignData _extractedDesign = null;

		private int ItemCount
		{
			get{ return _serials != null ? _serials.Length : 0; }
		}

		private System.Windows.Forms.Button btnExtract;
		private System.Windows.Forms.Button btnTeleport;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnWipeArea;
		private System.Windows.Forms.GroupBox fraSelection;
		private System.Windows.Forms.Button btnWipeSel;
		private System.Windows.Forms.Button btnClearSel;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button btnRemoveItemFromSel;
		private System.Windows.Forms.Button btnAddItemToSel;
		private System.Windows.Forms.Button btnSelectItem;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnRemoveAreaFromSel;
		private System.Windows.Forms.Button btnSelectArea;
		private System.Windows.Forms.Button btnAddArea;
		private UOArchitect.Toolbox.Controls.FilterByZControl ctlItemZFilter;
		private UOArchitect.MoveControlMockup ctlMoveItems;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MovePanel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnExtract = new System.Windows.Forms.Button();
			this.btnTeleport = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnWipeArea = new System.Windows.Forms.Button();
			this.fraSelection = new System.Windows.Forms.GroupBox();
			this.ctlMoveItems = new UOArchitect.MoveControlMockup();
			this.btnWipeSel = new System.Windows.Forms.Button();
			this.btnClearSel = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnRemoveItemFromSel = new System.Windows.Forms.Button();
			this.btnAddItemToSel = new System.Windows.Forms.Button();
			this.btnSelectItem = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ctlItemZFilter = new UOArchitect.Toolbox.Controls.FilterByZControl();
			this.btnRemoveAreaFromSel = new System.Windows.Forms.Button();
			this.btnSelectArea = new System.Windows.Forms.Button();
			this.btnAddArea = new System.Windows.Forms.Button();
			this.fraSelection.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnExtract
			// 
			this.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExtract.Location = new System.Drawing.Point(104, 328);
			this.btnExtract.Name = "btnExtract";
			this.btnExtract.Size = new System.Drawing.Size(72, 23);
			this.btnExtract.TabIndex = 16;
			this.btnExtract.Text = "Extract";
			this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
			// 
			// btnTeleport
			// 
			this.btnTeleport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnTeleport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTeleport.Location = new System.Drawing.Point(104, 299);
			this.btnTeleport.Name = "btnTeleport";
			this.btnTeleport.Size = new System.Drawing.Size(72, 23);
			this.btnTeleport.TabIndex = 14;
			this.btnTeleport.Text = "Teleport";
			this.btnTeleport.Click += new System.EventHandler(this.btnTeleport_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRemove.Location = new System.Drawing.Point(16, 328);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 23);
			this.btnRemove.TabIndex = 15;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnWipeArea
			// 
			this.btnWipeArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnWipeArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnWipeArea.Location = new System.Drawing.Point(16, 299);
			this.btnWipeArea.Name = "btnWipeArea";
			this.btnWipeArea.Size = new System.Drawing.Size(72, 23);
			this.btnWipeArea.TabIndex = 13;
			this.btnWipeArea.Text = "Wipe Area";
			this.btnWipeArea.Click += new System.EventHandler(this.btnWipeArea_Click);
			// 
			// fraSelection
			// 
			this.fraSelection.Controls.Add(this.ctlMoveItems);
			this.fraSelection.Controls.Add(this.btnWipeSel);
			this.fraSelection.Controls.Add(this.btnClearSel);
			this.fraSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fraSelection.Location = new System.Drawing.Point(11, 5);
			this.fraSelection.Name = "fraSelection";
			this.fraSelection.Size = new System.Drawing.Size(168, 128);
			this.fraSelection.TabIndex = 0;
			this.fraSelection.TabStop = false;
			this.fraSelection.Text = "Selected: 0 items";
			// 
			// ctlMoveItems
			// 
			this.ctlMoveItems.Location = new System.Drawing.Point(16, 16);
			this.ctlMoveItems.Name = "ctlMoveItems";
			this.ctlMoveItems.Size = new System.Drawing.Size(136, 72);
			this.ctlMoveItems.TabIndex = 1;
			// 
			// btnWipeSel
			// 
			this.btnWipeSel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnWipeSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnWipeSel.Location = new System.Drawing.Point(88, 96);
			this.btnWipeSel.Name = "btnWipeSel";
			this.btnWipeSel.Size = new System.Drawing.Size(64, 23);
			this.btnWipeSel.TabIndex = 3;
			this.btnWipeSel.Text = "Wipe";
			this.btnWipeSel.Click += new System.EventHandler(this.btnWipeSel_Click);
			// 
			// btnClearSel
			// 
			this.btnClearSel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnClearSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClearSel.Location = new System.Drawing.Point(16, 96);
			this.btnClearSel.Name = "btnClearSel";
			this.btnClearSel.Size = new System.Drawing.Size(64, 23);
			this.btnClearSel.TabIndex = 2;
			this.btnClearSel.Text = "Unselect";
			this.btnClearSel.Click += new System.EventHandler(this.btnClearSel_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.btnRemoveItemFromSel);
			this.groupBox5.Controls.Add(this.btnAddItemToSel);
			this.groupBox5.Controls.Add(this.btnSelectItem);
			this.groupBox5.Location = new System.Drawing.Point(8, 141);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(176, 48);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Select Item";
			// 
			// btnRemoveItemFromSel
			// 
			this.btnRemoveItemFromSel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemoveItemFromSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRemoveItemFromSel.Location = new System.Drawing.Point(113, 16);
			this.btnRemoveItemFromSel.Name = "btnRemoveItemFromSel";
			this.btnRemoveItemFromSel.Size = new System.Drawing.Size(56, 23);
			this.btnRemoveItemFromSel.TabIndex = 7;
			this.btnRemoveItemFromSel.Text = "Exclude";
			this.btnRemoveItemFromSel.Click += new System.EventHandler(this.btnRemoveItemFromSel_Click);
			this.btnRemoveItemFromSel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRemoveItemFromSel_MouseUp);
			// 
			// btnAddItemToSel
			// 
			this.btnAddItemToSel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddItemToSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAddItemToSel.Location = new System.Drawing.Point(60, 16);
			this.btnAddItemToSel.Name = "btnAddItemToSel";
			this.btnAddItemToSel.Size = new System.Drawing.Size(56, 23);
			this.btnAddItemToSel.TabIndex = 6;
			this.btnAddItemToSel.Text = "Include";
			this.btnAddItemToSel.Click += new System.EventHandler(this.btnAddItemToSel_Click);
			this.btnAddItemToSel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAddItemToSel_MouseUp);
			// 
			// btnSelectItem
			// 
			this.btnSelectItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSelectItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectItem.Location = new System.Drawing.Point(8, 16);
			this.btnSelectItem.Name = "btnSelectItem";
			this.btnSelectItem.Size = new System.Drawing.Size(53, 23);
			this.btnSelectItem.TabIndex = 5;
			this.btnSelectItem.Text = "Select";
			this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
			this.btnSelectItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSelectItem_MouseUp);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.ctlItemZFilter);
			this.groupBox4.Controls.Add(this.btnRemoveAreaFromSel);
			this.groupBox4.Controls.Add(this.btnSelectArea);
			this.groupBox4.Controls.Add(this.btnAddArea);
			this.groupBox4.Location = new System.Drawing.Point(8, 197);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(176, 96);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Select Area";
			// 
			// ctlItemZFilter
			// 
			this.ctlItemZFilter.Location = new System.Drawing.Point(12, 46);
			this.ctlItemZFilter.Name = "ctlItemZFilter";
			this.ctlItemZFilter.Size = new System.Drawing.Size(152, 45);
			this.ctlItemZFilter.TabIndex = 12;
			// 
			// btnRemoveAreaFromSel
			// 
			this.btnRemoveAreaFromSel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemoveAreaFromSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRemoveAreaFromSel.Location = new System.Drawing.Point(112, 16);
			this.btnRemoveAreaFromSel.Name = "btnRemoveAreaFromSel";
			this.btnRemoveAreaFromSel.Size = new System.Drawing.Size(56, 23);
			this.btnRemoveAreaFromSel.TabIndex = 11;
			this.btnRemoveAreaFromSel.Text = "Exclude";
			this.btnRemoveAreaFromSel.Click += new System.EventHandler(this.btnRemoveAreaFromSel_Click);
			// 
			// btnSelectArea
			// 
			this.btnSelectArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSelectArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectArea.Location = new System.Drawing.Point(9, 16);
			this.btnSelectArea.Name = "btnSelectArea";
			this.btnSelectArea.Size = new System.Drawing.Size(48, 23);
			this.btnSelectArea.TabIndex = 9;
			this.btnSelectArea.Text = "Select";
			this.btnSelectArea.Click += new System.EventHandler(this.btnSelectArea_Click);
			// 
			// btnAddArea
			// 
			this.btnAddArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAddArea.Location = new System.Drawing.Point(56, 16);
			this.btnAddArea.Name = "btnAddArea";
			this.btnAddArea.Size = new System.Drawing.Size(57, 23);
			this.btnAddArea.TabIndex = 10;
			this.btnAddArea.Text = "Include";
			this.btnAddArea.Click += new System.EventHandler(this.AddArea_Click);
			// 
			// MovePanel
			// 
			this.Controls.Add(this.btnExtract);
			this.Controls.Add(this.btnTeleport);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnWipeArea);
			this.Controls.Add(this.fraSelection);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Name = "MovePanel";
			this.Size = new System.Drawing.Size(192, 360);
			this.fraSelection.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			Connection.OnBusy += new Connection.ClientBusyEvent(OnClientBusy);
			Connection.OnConnect += new Connection.ConnectEvent(OnConnection);
			Connection.OnDisconnect += new Connection.DisconnectEvent(OnDisconnection);
			Connection.OnReady += new Connection.ClientReadyEvent(OnClientReady);
			ctlMoveItems.OnMoveItems += new MoveControlMockup.MoveItemsEvent(OnMoveItems);
			ctlMoveItems.OnNudgeItems += new MoveControlMockup.NudgeItemsEvent(OnNudgeItems);
		
			UpdateControlStates();
		}

		#region Event Handlers

		private void OnMoveItems(short xoffset, short yoffset)
		{
			MoveItemsArgs args = new MoveItemsArgs(_serials);
			args.Xoffset = xoffset;
			args.Yoffset = yoffset;

			Connection.SendMoveItemsCommand(args);
		}

		private void OnNudgeItems(short zoffset)
		{
			MoveItemsArgs args = new MoveItemsArgs(_serials);
			args.Zoffset = zoffset;

			Connection.SendMoveItemsCommand(args);
		}

		private void OnDisconnection()
		{
			UpdateControlStates();
		}

		private void OnConnection()
		{
			UpdateControlStates();
		}	

		private void OnClientBusy()
		{
			UpdateControlStates();
		}

		private void OnClientReady()
		{
			UpdateControlStates();
		}

		#endregion

		#region Button Event Handlers

		private void btnAddItemToSel_Click(object sender, System.EventArgs e)
		{
			AddItemToSelection(false);
		}

		private void btnSelectItem_Click(object sender, System.EventArgs e)
		{
			SelectSingleItem(false);
		}

		private void btnSelectArea_Click(object sender, System.EventArgs e)
		{
			SelectArea(false);
		}

		private void AddAreaToSelection(bool multiple)
		{
			Cursor.Current = Cursors.WaitCursor;

			SelectItemsResponse resp = SelectItems(SelectTypes.Area, multiple);

			if(resp != null)
			{
				AddItemsToSel(resp.ItemSerials);
			}
			
			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		private void SelectArea(bool multiple)
		{
			Cursor.Current = Cursors.WaitCursor;

			_serials = null;

			SelectItemsResponse resp = SelectItems(SelectTypes.Area, multiple);

			if(resp != null)
			{
				_serials = resp.ItemSerials;
			}
			
			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		private void RemoveAreaFromSelection(bool multiple)
		{
			Cursor.Current = Cursors.WaitCursor;

			SelectItemsResponse resp = SelectItems(SelectTypes.Area, multiple);

			if(resp != null)
			{
				RemoveItemsFromSel(resp.ItemSerials);
			}
			
			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		private void SelectSingleItem(bool multiple)
		{
			Cursor.Current = Cursors.WaitCursor;

			_serials = null;

			SelectItemsResponse resp = SelectItems(SelectTypes.Item, multiple);

			if(resp != null)
			{
				_serials = resp.ItemSerials;
			}
			
			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		private void RemoveItemFromSelection(bool multiple)
		{
			Cursor.Current = Cursors.WaitCursor;

			SelectItemsResponse resp = SelectItems(SelectTypes.Item, multiple);

			if(resp != null)
			{
				RemoveItemsFromSel(resp.ItemSerials);
			}
			
			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		private void AddItemToSelection(bool multiple)
		{
			Cursor.Current = Cursors.WaitCursor;

			SelectItemsResponse resp = SelectItems(SelectTypes.Item, multiple);

			if(resp != null)
			{
				AddItemsToSel(resp.ItemSerials);
			}
			
			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		private void AddArea_Click(object sender, System.EventArgs e)
		{
			AddAreaToSelection(false);
		}

		private void btnClearSel_Click(object sender, System.EventArgs e)
		{
			_serials = null;
			UpdateControlStates();
			UpdateSelectionCount();
		}

		private void btnWipeArea_Click(object sender, System.EventArgs e)
		{
			Utility.SendClientCommand("wipeitems");
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			Utility.SendClientCommand("MRemove");
		}

		private void btnTeleport_Click(object sender, System.EventArgs e)
		{
			Utility.SendClientCommand("tele");
		}

		private void btnRemoveAreaFromSel_Click(object sender, System.EventArgs e)
		{
			RemoveAreaFromSelection(false);
		}

		private void btnRemoveItemFromSel_Click(object sender, System.EventArgs e)
		{
			RemoveItemFromSelection(false);
		}

		private void btnWipeSel_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			Connection.SendDeleteItemsCommand(new DeleteCommandArgs(_serials));
			_serials = null;

			UpdateSelectionCount();
			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Methods

		private void AddItemsToSel(int[] serials)
		{
			ArrayList items = new ArrayList(_serials);

			for(int i=0; i < serials.Length; ++i)
			{
				if(items.IndexOf(serials[i]) == -1)
					items.Add(serials[i]);
			}

			_serials = (int[])items.ToArray(typeof(int));			
		}

		private void RemoveItemsFromSel(int[] serials)
		{
			ArrayList items = new ArrayList(_serials);

			for(int i=0; i < serials.Length; ++i)
			{
				if(items.IndexOf(serials[i]) != -1)
					items.Remove(serials[i]);
			}

			if(items.Count > 0)
				_serials = (int[])items.ToArray(typeof(int));
			else
				_serials = null;
		}

		private SelectItemsResponse SelectItems(SelectTypes type, bool multiple)
		{
			SelectItemsRequestArgs args = new SelectItemsRequestArgs(type);
			args.Multiple = multiple;

			if(type == SelectTypes.Area)
			{
				if(ctlItemZFilter.UseMaxZ)
				{
					args.UseMaxZ = true;
					args.MaxZ = ctlItemZFilter.MaxZ;
				}

				if(ctlItemZFilter.UseMinZ)
				{
					args.UseMinZ = true;
					args.MinZ = ctlItemZFilter.MinZ;
				}

			}

			_lastResponse = null;

			ItemSelector selector = new ItemSelector();
			selector.OnSelection += new ItemSelector.ItemsSelectedtEvent(OnSelection);
			
			// wait for the extract to complete
			selector.SelectItems(args, true);
			WaitForSelection();

			selector.OnSelection -= new ItemSelector.ItemsSelectedtEvent(OnSelection);

			return _lastResponse;
		}

		private void UpdateSelectionCount()
		{
			fraSelection.Text = string.Format("Selected: {0} items", ItemCount);
		}

		private void UpdateControlStates()
		{
			if(!_busy)
			{
				btnWipeArea.Enabled = true;
				btnTeleport.Enabled = true;
				btnRemove.Enabled = true;
			}
			else
			{
				btnWipeArea.Enabled = false;
				btnTeleport.Enabled = false;
				btnRemove.Enabled = false;
			}

			if(!_busy && ItemCount > 0 && Connection.IsConnected && !Connection.IsBusy)
			{
				ctlMoveItems.Enabled = true;
				btnClearSel.Enabled = true;
				btnWipeSel.Enabled = true;
				btnAddItemToSel.Enabled = (ItemCount > 0);
				btnAddArea.Enabled = (ItemCount > 0);
				btnRemoveAreaFromSel.Enabled = (ItemCount > 0);
				btnRemoveItemFromSel.Enabled = (ItemCount > 0);
				btnExtract.Enabled = (ItemCount > 0);
			}
			else
			{
				ctlMoveItems.Enabled = false;
				btnClearSel.Enabled = false;
				btnWipeSel.Enabled = false;
				btnAddItemToSel.Enabled = false;
				btnAddArea.Enabled = false;
				btnRemoveAreaFromSel.Enabled = false;
				btnRemoveItemFromSel.Enabled = false;
				btnExtract.Enabled = false;
				btnSelectArea.Enabled = false;
				btnSelectItem.Enabled = false;
			}

			if(!_busy && !Connection.IsBusy && Connection.IsConnected)
			{
				btnSelectArea.Enabled = true;
				btnSelectItem.Enabled = true;
			}
			else
			{	
				btnAddArea.Enabled = false;
				btnAddItemToSel.Enabled = false;
			}	
		}

		private void WaitForSelection()
		{
			_busy = true;

			while(_busy)
			{
				Application.DoEvents();
				System.Threading.Thread.Sleep(50);
			}
		}

		private void OnSelection(SelectItemsResponse response)
		{
			_lastResponse = response;
			_busy = false;
		}

		#endregion

		private void btnSelectItem_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{	
				SelectSingleItem(true);
			}
		}

		private void btnAddItemToSel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{	
				AddItemToSelection(true);
			}
		}

		private void btnRemoveItemFromSel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{	
				RemoveItemFromSelection(true);
			}
		}

		private void btnExtract_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			_busy = true;
			ExtractItems();
		}

		private void OnExtracted(DesignData design)
		{
			_extractedDesign = design;
			_busy = false;
		}

		private void ExtractItems()
		{
			ItemExtracter extract = new ItemExtracter();

			extract.OnExtracted += new ItemExtracter.DesignExtractEvent(OnExtracted);
			
			// wait for the extract to complete
			extract.ExtractDesign(_serials);
			WaitForSelection();

			extract.OnExtracted -= new ItemExtracter.DesignExtractEvent(OnExtracted);

			if(_extractedDesign != null)
			{
				_extractedDesign.Save();
			}	

			_extractedDesign = null;

			UpdateControlStates();

			Cursor.Current = Cursors.Default;
		}

	}
}
