using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for EditServerListing.
	/// </summary>
	public class EditServerListing : System.Windows.Forms.Form
	{
		#region Auto Code

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditServerListing()
		{
			//
			// Required for Windows Form Designer support
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "IP Address";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Port";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "User Name";
			// 
			// txtServerName
			// 
			this.txtServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtServerName.Location = new System.Drawing.Point(72, 16);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.Size = new System.Drawing.Size(128, 20);
			this.txtServerName.TabIndex = 4;
			this.txtServerName.Text = "";
			this.txtServerName.TextChanged += new System.EventHandler(this.txtServerName_TextChanged);
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtIPAddress.Location = new System.Drawing.Point(72, 40);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(128, 20);
			this.txtIPAddress.TabIndex = 5;
			this.txtIPAddress.Text = "";
			this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_TextChanged);
			// 
			// txtPort
			// 
			this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPort.Location = new System.Drawing.Point(72, 64);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(72, 20);
			this.txtPort.TabIndex = 6;
			this.txtPort.Text = "";
			this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
			// 
			// txtUserName
			// 
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUserName.Location = new System.Drawing.Point(72, 88);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(128, 20);
			this.txtUserName.TabIndex = 7;
			this.txtUserName.Text = "";
			this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(136, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 24);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(64, 120);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(64, 24);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// EditServerListing
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(208, 152);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtIPAddress);
			this.Controls.Add(this.txtServerName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "EditServerListing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Listing";
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		private ServerListing m_listing = new ServerListing("", "", Config.Port, "");
		private ServerListing m_oldListingData;
		private bool m_newRecord = true;

		protected override void OnLoad(EventArgs e)
		{
			if(m_newRecord)
				m_listing.GUID = Guid.NewGuid().ToString();
		}


		public void EditListing(ServerListing listing, Form owner)
		{
			this.Owner = owner;
			this.Text = "Edit Listing";
			m_newRecord = false;
			m_listing = listing;

			m_oldListingData = new ServerListing(listing.ServerName, listing.ServerIP, listing.Port, listing.UserName);
			m_oldListingData.Password = listing.Password;

			UpdateControlStates();
			UpdateDisplay();

			ShowDialog(owner);

			if(this.DialogResult == DialogResult.Cancel)
			{
				m_listing.ServerName = m_oldListingData.ServerName;
				m_listing.ServerIP = m_oldListingData.ServerIP;
				m_listing.Port = m_oldListingData.Port;
				m_listing.UserName = m_oldListingData.UserName;
				m_listing.Password = m_oldListingData.Password;
			}
		}

		private void UpdateControlStates()
		{
			bool valid = true;

			if(m_listing.ServerName == null || m_listing.ServerName.Length == 0)
				valid = false;
			else if(m_listing.ServerIP == null || m_listing.ServerIP.Length == 0)
				valid = false;
			else if(m_listing.UserName == null || m_listing.UserName.Length == 0)
				valid = false;
			
			btnSave.Enabled = valid;
		}

		private void UpdateDisplay()
		{
			txtServerName.Text = m_listing.ServerName != null ? m_listing.ServerName : "";
			txtIPAddress.Text = m_listing.ServerIP != null ? m_listing.ServerIP : "";
			txtUserName.Text = m_listing.UserName != null ? m_listing.UserName : "";
			txtPort.Text = m_listing.Port.ToString();
		}

		private void txtServerName_TextChanged(object sender, System.EventArgs e)
		{
			m_listing.ServerName = txtServerName.Text.Trim();
			UpdateControlStates();
		}

		private void txtIPAddress_TextChanged(object sender, System.EventArgs e)
		{
			m_listing.ServerIP = txtIPAddress.Text.Trim();
			UpdateControlStates();
		}

		private void txtPort_TextChanged(object sender, System.EventArgs e)
		{
			m_listing.Port = Utility.ToInt(txtPort.Text.Trim());
			UpdateControlStates();
		}

		private void txtUserName_TextChanged(object sender, System.EventArgs e)
		{
			m_listing.UserName = txtUserName.Text.Trim();
			UpdateControlStates();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(m_newRecord)
			{
				Config.ServerListings.Add(m_listing);
			}
	
			this.DialogResult = DialogResult.OK;
			Close();
		}


	}
}
