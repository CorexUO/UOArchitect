using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using UOArchitectInterface;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for BuildDialog.
	/// </summary>
	public class BuildDialog : System.Windows.Forms.Form
	{
		private Form _toolbox;
		private static int _LastTop = -1;
		private static int _LastLeft = -1;
		private bool _foundation = false;
		private bool _defaultHues = false;
		private int[] _serials = null;
		private DesignData _design = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private UOArchitect.MoveItemControl moveItemControl1;
		private System.Windows.Forms.CheckBox chkFoundation;
		private System.Windows.Forms.Button btnBuild;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnToolbox;
		private System.Windows.Forms.Button btnGetZ;
		private System.Windows.Forms.CheckBox chkHued;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BuildDialog(Form toolbox)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_toolbox = toolbox;
			moveItemControl1.OnWipeItems += new MoveItemControl.WipeItemsEvent(OnWipeItems);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BuildDialog));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.moveItemControl1 = new UOArchitect.MoveItemControl();
			this.btnGetZ = new System.Windows.Forms.Button();
			this.btnBuild = new System.Windows.Forms.Button();
			this.chkFoundation = new System.Windows.Forms.CheckBox();
			this.chkHued = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.btnToolbox = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.moveItemControl1);
			this.groupBox1.Controls.Add(this.btnGetZ);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(4, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 128);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Move Design";
			// 
			// moveItemControl1
			// 
			this.moveItemControl1.Enabled = false;
			this.moveItemControl1.Location = new System.Drawing.Point(8, 16);
			this.moveItemControl1.Name = "moveItemControl1";
			this.moveItemControl1.Size = new System.Drawing.Size(144, 104);
			this.moveItemControl1.TabIndex = 1;
			// 
			// btnGetZ
			// 
			this.btnGetZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGetZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGetZ.Location = new System.Drawing.Point(112, 104);
			this.btnGetZ.Name = "btnGetZ";
			this.btnGetZ.Size = new System.Drawing.Size(40, 21);
			this.btnGetZ.TabIndex = 3;
			this.btnGetZ.Text = "Get Z";
			this.btnGetZ.Click += new System.EventHandler(this.btnGetZ_Click);
			// 
			// btnBuild
			// 
			this.btnBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBuild.Location = new System.Drawing.Point(88, 176);
			this.btnBuild.Name = "btnBuild";
			this.btnBuild.Size = new System.Drawing.Size(72, 24);
			this.btnBuild.TabIndex = 2;
			this.btnBuild.Text = "Build";
			this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
			// 
			// chkFoundation
			// 
			this.chkFoundation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkFoundation.Location = new System.Drawing.Point(80, 157);
			this.chkFoundation.Name = "chkFoundation";
			this.chkFoundation.Size = new System.Drawing.Size(88, 16);
			this.chkFoundation.TabIndex = 1;
			this.chkFoundation.Text = "Foundation";
			this.chkFoundation.CheckedChanged += new System.EventHandler(this.chkFoundation_CheckedChanged);
			// 
			// chkHued
			// 
			this.chkHued.Checked = true;
			this.chkHued.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkHued.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkHued.Location = new System.Drawing.Point(16, 157);
			this.chkHued.Name = "chkHued";
			this.chkHued.Size = new System.Drawing.Size(56, 16);
			this.chkHued.TabIndex = 0;
			this.chkHued.Text = "Hued";
			this.chkHued.CheckedChanged += new System.EventHandler(this.chkHued_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Name:";
			// 
			// lblName
			// 
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblName.Location = new System.Drawing.Point(56, 6);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(112, 16);
			this.lblName.TabIndex = 5;
			// 
			// btnToolbox
			// 
			this.btnToolbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnToolbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnToolbox.Location = new System.Drawing.Point(8, 176);
			this.btnToolbox.Name = "btnToolbox";
			this.btnToolbox.Size = new System.Drawing.Size(72, 24);
			this.btnToolbox.TabIndex = 7;
			this.btnToolbox.Text = "Toolbox";
			this.btnToolbox.Click += new System.EventHandler(this.btnToolbox_Click);
			// 
			// BuildDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(170, 208);
			this.Controls.Add(this.btnToolbox);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.chkHued);
			this.Controls.Add(this.chkFoundation);
			this.Controls.Add(this.btnBuild);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "BuildDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Build";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.BuildDialog_Closing);
			this.Load += new System.EventHandler(this.BuildDialog_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void LoadForm(DesignData design)
		{
			if(design != null)
			{
				_design = design;
				lblName.Text = _design.Name;

				moveItemControl1.Enabled = false;

				Show();
			}
			else
			{
				Close();
			}
		}

		private void SetPosition()
		{
			if(_LastLeft != -1 && _LastTop != -1)
			{
				this.Left = _LastLeft;
				this.Top = _LastTop;
			}
			else
			{
				this.Top = ClientSize.Height / 2;
				this.Left = ClientSize.Width / 2;
			}
		}

		private void chkFoundation_CheckedChanged(object sender, System.EventArgs e)
		{
			_foundation = chkFoundation.Checked ? true : false;
		}

		private DesignItemCol GetFilteredItems(DesignItemCol items, bool foundation, bool hues)
		{
			DesignItemCol buildItems = new DesignItemCol();

			for(int i=0; i < items.Count; ++i)
			{
				if(!foundation && items[i].Level == 0)
					continue;

				int z = foundation ? items[i].Z : (items[i].Z - 7);
				int index = items[i].ItemID;
				int x = items[i].X;
				int y = items[i].Y;
				int hue = 0;

				if(hues)
					hue = items[i].Hue;

				buildItems.Add(new DesignItem(index, x, y, z, 0, hue));
			}

			return buildItems;
		}

		private void btnBuild_Click(object sender, System.EventArgs e)
		{
			if(!_design.IsLoaded)
				_design.Load();

			DesignItemCol items = GetFilteredItems(_design.Items, _foundation, !_defaultHues);
			BuildResponse response = Connection.BuildDesign(items);

			_design.Unload();

			if(response == null || response.Count == 0)
			{
				moveItemControl1.Enabled = false;
			}
			else
			{
				_serials = response.ItemSerials;
				moveItemControl1.Enabled = true;
			}
		}

		private void BuildDialog_Load(object sender, System.EventArgs e)
		{
			moveItemControl1.OnMoveItems += new MoveItemControl.MoveItemsEvent(OnMoveItems);
			moveItemControl1.OnNudgeItems += new MoveItemControl.NudgeItemsEvent(OnNudgeItems);
			Connection.OnBusy += new Connection.ClientBusyEvent(OnClientBusy);
			Connection.OnConnect += new Connection.ConnectEvent(OnConnection);
			Connection.OnDisconnect += new Connection.DisconnectEvent(OnDisconnection);
			Connection.OnReady += new Connection.ClientReadyEvent(OnClientReady);

			SetPosition();
			UpdateControlStates();

			btnGetZ.BringToFront();
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

		private void BuildDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_LastLeft = this.Left;
			_LastTop = this.Top;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnToolbox_Click(object sender, System.EventArgs e)
		{
			if(_toolbox.WindowState != FormWindowState.Normal)
				_toolbox.WindowState = FormWindowState.Normal;

			_toolbox.Activate();
			_toolbox.BringToFront();
		}

		private void OnWipeItems()
		{
			DeleteCommandArgs args = new DeleteCommandArgs(_serials);
			Connection.SendDeleteItemsCommand(args);
		}

		private void btnGetZ_Click(object sender, System.EventArgs e)
		{
			Utility.SendClientCommand("get z");
		}

		private void chkHued_CheckedChanged(object sender, System.EventArgs e)
		{
			_defaultHues = chkHued.Checked ? false : true;
		}

		public void UpdateControlStates()
		{
			if(Connection.IsConnected && !Connection.IsBusy)
			{
				btnBuild.Enabled = true;

				if(_serials != null)
					moveItemControl1.Enabled = true;
				else
					moveItemControl1.Enabled = false;
			}
			else
			{
				moveItemControl1.Enabled = false;
				btnBuild.Enabled = false;
			}
		}

	}
}
