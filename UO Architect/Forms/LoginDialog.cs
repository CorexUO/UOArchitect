using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for LoginDialog.
	/// </summary>
	public class LoginDialog : System.Windows.Forms.Form
	{
		#region Auto Code

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView lstServers;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAccount;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.CheckBox chkSavePassword;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LoginDialog()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.lstServers = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAccount = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.chkSavePassword = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnAdd);
			this.groupBox1.Controls.Add(this.btnEdit);
			this.groupBox1.Controls.Add(this.btnDelete);
			this.groupBox1.Controls.Add(this.lstServers);
			this.groupBox1.Location = new System.Drawing.Point(9, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server Listing";
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAdd.Location = new System.Drawing.Point(10, 144);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(62, 23);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Enabled = false;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnEdit.Location = new System.Drawing.Point(71, 144);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(56, 23);
			this.btnEdit.TabIndex = 6;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDelete.Location = new System.Drawing.Point(126, 144);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(56, 23);
			this.btnDelete.TabIndex = 7;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// lstServers
			// 
			this.lstServers.FullRowSelect = true;
			this.lstServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstServers.Location = new System.Drawing.Point(8, 16);
			this.lstServers.Name = "lstServers";
			this.lstServers.Size = new System.Drawing.Size(176, 120);
			this.lstServers.TabIndex = 0;
			this.lstServers.View = System.Windows.Forms.View.List;
			this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 195);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Account:";
			// 
			// txtAccount
			// 
			this.txtAccount.BackColor = System.Drawing.SystemColors.Control;
			this.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAccount.Enabled = false;
			this.txtAccount.Location = new System.Drawing.Point(66, 193);
			this.txtAccount.Name = "txtAccount";
			this.txtAccount.Size = new System.Drawing.Size(128, 20);
			this.txtAccount.TabIndex = 1;
			this.txtAccount.Text = "";
			this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Enabled = false;
			this.txtPassword.Location = new System.Drawing.Point(66, 217);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(128, 20);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "";
			this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 217);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(144, 246);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			// 
			// btnConnect
			// 
			this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnConnect.Enabled = false;
			this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnConnect.Location = new System.Drawing.Point(80, 246);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(56, 23);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// chkSavePassword
			// 
			this.chkSavePassword.Location = new System.Drawing.Point(16, 240);
			this.chkSavePassword.Name = "chkSavePassword";
			this.chkSavePassword.Size = new System.Drawing.Size(56, 32);
			this.chkSavePassword.TabIndex = 5;
			this.chkSavePassword.Text = "Save Pwd";
			// 
			// LoginDialog
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(210, 280);
			this.Controls.Add(this.chkSavePassword);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtAccount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LoginDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login Manager";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Members

		private ServerListing m_selectedListing;
		private string m_UserName = "";
		private string m_Password = "";
		private string m_ServerIP = "";
		private int m_Port = 0;

		#endregion

		#region Properties

		public string UserName
		{
			get{ return m_UserName; }
		}

		public string Password
		{
			get{ return m_Password; }
		}

		public string ServerIP
		{
			get{ return m_ServerIP; }
		}

		public int Port
		{
			get{ return m_Port; }
		}

		#endregion

		#region Methods

		protected override void OnLoad(EventArgs e)
		{
			PopulateServerList();	
			UpdateButtonState();
			UpdateDisplay();
		}

		private void PopulateServerList()
		{
			lstServers.Items.Clear();

			m_selectedListing = null;
			m_ServerIP = "";
			m_Port = 0;
			m_UserName = "";
			m_Password = "";

			foreach(ServerListing server in Config.ServerListings)
			{	
				ListViewItem item = new ListViewItem(server.ServerName);
				item.Tag = server;
				lstServers.Items.Add(item);
			}
		}

		#endregion

		private void lstServers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lstServers.SelectedItems.Count > 0)
			{
				m_selectedListing = (ServerListing)lstServers.SelectedItems[0].Tag;

				m_ServerIP = m_selectedListing.ServerIP;
				m_Port = m_selectedListing.Port;
				m_UserName = m_selectedListing.UserName != null ? m_selectedListing.UserName : "";
				m_Password = m_selectedListing.Password != null ? m_selectedListing.Password : "";

				chkSavePassword.Checked = (m_Password.Length > 0);
			}
			else
			{
				m_selectedListing = null;
				m_ServerIP = "";
				m_Port = 0;
				m_UserName = "";
				m_Password = "";
			}

			UpdateButtonState();
			UpdateDisplay();
		}

		private void UpdateButtonState()
		{
			bool serverSelected = (m_selectedListing != null);

			btnDelete.Enabled = serverSelected;
			btnEdit.Enabled = serverSelected;
			txtPassword.Enabled = serverSelected;

			if(m_UserName.Length > 0 && m_Password.Length > 0)
				btnConnect.Enabled = true;
			else
				btnConnect.Enabled = false;
		}

		private void UpdateDisplay()
		{
			txtAccount.Text = m_UserName;
			txtPassword.Text = m_Password;
		}

		private void txtAccount_TextChanged(object sender, System.EventArgs e)
		{
			m_UserName = txtAccount.Text.Trim();

			UpdateButtonState();
		}

		private void txtPassword_TextChanged(object sender, System.EventArgs e)
		{
			m_Password = txtPassword.Text.Trim();

			UpdateButtonState();
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			if(chkSavePassword.Checked)
			{
				m_selectedListing.Password = m_Password;
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			EditServerListing dlg = new EditServerListing();
			dlg.ShowDialog(this);

			dlg.Dispose();
			PopulateServerList();
			UpdateButtonState();
			UpdateDisplay();
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			EditServerListing dlg = new EditServerListing();
			dlg.EditListing(m_selectedListing, this);

			dlg.Dispose();
			PopulateServerList();
			UpdateButtonState();
			UpdateDisplay();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			Config.ServerListings.Remove(m_selectedListing);

			PopulateServerList();
			UpdateButtonState();
			UpdateDisplay();
		}

	}
}
