using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using UOArchitectInterface;

namespace UOArchitect.Toolbox.Controls
{
	/// <summary>
	/// Summary description for FilterByZControl.
	/// </summary>
	public class FilterByZControl : System.Windows.Forms.UserControl
	{
		private bool _useMaxZ = false;
		private bool _useMinZ = false;
		private int _maxZ = 0;
		private int _minZ = 0;

		private System.Windows.Forms.Button btnGetMaxZ;
		private System.Windows.Forms.Button btnGetMinZ;
		private System.Windows.Forms.CheckBox chkMinZ;
		private System.Windows.Forms.NumericUpDown numMinZ;
		private System.Windows.Forms.CheckBox chkMaxZ;
		private System.Windows.Forms.NumericUpDown numMaxZ;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FilterByZControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FilterByZControl));
			this.btnGetMaxZ = new System.Windows.Forms.Button();
			this.btnGetMinZ = new System.Windows.Forms.Button();
			this.chkMinZ = new System.Windows.Forms.CheckBox();
			this.numMinZ = new System.Windows.Forms.NumericUpDown();
			this.chkMaxZ = new System.Windows.Forms.CheckBox();
			this.numMaxZ = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numMinZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGetMaxZ
			// 
			this.btnGetMaxZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnGetMaxZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGetMaxZ.Image = ((System.Drawing.Image)(resources.GetObject("btnGetMaxZ.Image")));
			this.btnGetMaxZ.Location = new System.Drawing.Point(112, 24);
			this.btnGetMaxZ.Name = "btnGetMaxZ";
			this.btnGetMaxZ.Size = new System.Drawing.Size(37, 20);
			this.btnGetMaxZ.TabIndex = 5;
			this.btnGetMaxZ.Click += new System.EventHandler(this.btnGetMaxZ_Click);
			// 
			// btnGetMinZ
			// 
			this.btnGetMinZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnGetMinZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGetMinZ.Image = ((System.Drawing.Image)(resources.GetObject("btnGetMinZ.Image")));
			this.btnGetMinZ.Location = new System.Drawing.Point(112, 0);
			this.btnGetMinZ.Name = "btnGetMinZ";
			this.btnGetMinZ.Size = new System.Drawing.Size(37, 20);
			this.btnGetMinZ.TabIndex = 2;
			this.btnGetMinZ.Click += new System.EventHandler(this.btnGetMinZ_Click);
			// 
			// chkMinZ
			// 
			this.chkMinZ.Location = new System.Drawing.Point(0, 0);
			this.chkMinZ.Name = "chkMinZ";
			this.chkMinZ.Size = new System.Drawing.Size(51, 16);
			this.chkMinZ.TabIndex = 0;
			this.chkMinZ.Text = "Min Z";
			this.chkMinZ.CheckedChanged += new System.EventHandler(this.chkMinZ_CheckedChanged);
			// 
			// numMinZ
			// 
			this.numMinZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numMinZ.Location = new System.Drawing.Point(56, 0);
			this.numMinZ.Maximum = new System.Decimal(new int[] {
																	126,
																	0,
																	0,
																	0});
			this.numMinZ.Minimum = new System.Decimal(new int[] {
																	126,
																	0,
																	0,
																	-2147483648});
			this.numMinZ.Name = "numMinZ";
			this.numMinZ.Size = new System.Drawing.Size(48, 20);
			this.numMinZ.TabIndex = 1;
			this.numMinZ.ValueChanged += new System.EventHandler(this.numMinZ_ValueChanged);
			this.numMinZ.Leave += new System.EventHandler(this.numMinZ_Leave);
			// 
			// chkMaxZ
			// 
			this.chkMaxZ.Location = new System.Drawing.Point(0, 24);
			this.chkMaxZ.Name = "chkMaxZ";
			this.chkMaxZ.Size = new System.Drawing.Size(56, 16);
			this.chkMaxZ.TabIndex = 3;
			this.chkMaxZ.Text = "Max Z";
			this.chkMaxZ.CheckedChanged += new System.EventHandler(this.chkMaxZ_CheckedChanged);
			// 
			// numMaxZ
			// 
			this.numMaxZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numMaxZ.Location = new System.Drawing.Point(56, 24);
			this.numMaxZ.Maximum = new System.Decimal(new int[] {
																	126,
																	0,
																	0,
																	0});
			this.numMaxZ.Minimum = new System.Decimal(new int[] {
																	126,
																	0,
																	0,
																	-2147483648});
			this.numMaxZ.Name = "numMaxZ";
			this.numMaxZ.Size = new System.Drawing.Size(48, 20);
			this.numMaxZ.TabIndex = 4;
			this.numMaxZ.ValueChanged += new System.EventHandler(this.numMaxZ_ValueChanged);
			this.numMaxZ.Leave += new System.EventHandler(this.numMaxZ_Leave);
			// 
			// FilterByZControl
			// 
			this.Controls.Add(this.btnGetMaxZ);
			this.Controls.Add(this.btnGetMinZ);
			this.Controls.Add(this.chkMinZ);
			this.Controls.Add(this.numMinZ);
			this.Controls.Add(this.chkMaxZ);
			this.Controls.Add(this.numMaxZ);
			this.Name = "FilterByZControl";
			this.Size = new System.Drawing.Size(152, 45);
			((System.ComponentModel.ISupportInitialize)(this.numMinZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).EndInit();
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

			UpdateControlStates();
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

		public bool UseMaxZ
		{
			get{ return _useMaxZ; }
		}

		public bool UseMinZ
		{
			get{ return _useMinZ; }
		}

		public int MaxZ
		{
			get
			{
				int maxZ = _maxZ;

				if(_useMinZ && _maxZ < _minZ)
					maxZ = _minZ;

				return maxZ;
			}
		}

		public int MinZ
		{
			get
			{
				int minZ = _minZ;

				if(_useMaxZ && _minZ > _maxZ)
					minZ = _maxZ;

				return minZ;
			}
		}

		private void numMinZ_Leave(object sender, System.EventArgs e)
		{
			int minZ = Utility.ToInt(numMinZ.Text);

			if(minZ != (int)numMinZ.Value)
				numMinZ.Value = (decimal)minZ;
		}

		private void numMinZ_ValueChanged(object sender, System.EventArgs e)
		{
			_minZ = (int)numMinZ.Value;
		}

		private void numMaxZ_Leave(object sender, System.EventArgs e)
		{
			int maxZ = Utility.ToInt(numMaxZ.Text);

			if(maxZ != (int)numMaxZ.Value)
				numMaxZ.Value = (decimal)maxZ;
		}

		private void numMaxZ_ValueChanged(object sender, System.EventArgs e)
		{
			_maxZ = (int)numMaxZ.Value;
		}

		private void btnGetMinZ_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			GetLocationResp resp = Connection.SendGetLocationRequest(null);

			if(resp != null)
			{
				_minZ = resp.Z;
				numMinZ.Value = (decimal)_minZ;
			}

			Cursor.Current = Cursors.Default;
		}

		private void btnGetMaxZ_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			GetLocationResp resp = Connection.SendGetLocationRequest(null);

			if(resp != null)
			{
				_maxZ = resp.Z;
				numMaxZ.Value = (decimal)_maxZ;
			}

			Cursor.Current = Cursors.Default;
		}

		private void chkMinZ_CheckedChanged(object sender, System.EventArgs e)
		{
			_useMinZ = chkMinZ.Checked;
			numMinZ.Enabled = chkMinZ.Checked;	
	
			UpdateControlStates();
		}

		private void chkMaxZ_CheckedChanged(object sender, System.EventArgs e)
		{
			_useMaxZ = chkMaxZ.Checked;
			numMaxZ.Enabled = chkMaxZ.Checked;		

			UpdateControlStates();
		}

		public void UpdateControlStates()
		{
			if(_useMinZ)
			{
				numMinZ.Enabled = true;
				btnGetMinZ.Enabled = (Connection.IsConnected && !Connection.IsBusy) ? true : false;
			}
			else
			{
				numMinZ.Enabled = false;
				btnGetMinZ.Enabled = false;
			}

			if(_useMaxZ)
			{
				numMaxZ.Enabled = true;
				btnGetMaxZ.Enabled = (Connection.IsConnected && !Connection.IsBusy) ? true : false;
			}
			else
			{
				numMaxZ.Enabled = false;
				btnGetMaxZ.Enabled = false;
			}

		}
	}
}
