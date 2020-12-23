using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using OrbServerSDK;
using TestUtilityIntefaces;

namespace Test_Utility
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnGetLoc;
		private System.Windows.Forms.TextBox txtPort;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.btnConnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnGetLoc = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(112, 112);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(64, 24);
			this.btnConnect.TabIndex = 4;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server IP";
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(72, 8);
			this.txtIP.Name = "txtIP";
			this.txtIP.TabIndex = 0;
			this.txtIP.Text = "127.0.0.1";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(72, 32);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(56, 20);
			this.txtPort.TabIndex = 1;
			this.txtPort.Text = "2594";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(72, 56);
			this.txtUser.Name = "txtUser";
			this.txtUser.TabIndex = 2;
			this.txtUser.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "User";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(72, 80);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.TabIndex = 3;
			this.txtPassword.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Password";
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(8, 176);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(64, 23);
			this.btnSend.TabIndex = 6;
			this.btnSend.Text = "Send Msg";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(8, 152);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(192, 20);
			this.txtMessage.TabIndex = 5;
			this.txtMessage.Text = "";
			// 
			// btnGetLoc
			// 
			this.btnGetLoc.Location = new System.Drawing.Point(88, 176);
			this.btnGetLoc.Name = "btnGetLoc";
			this.btnGetLoc.Size = new System.Drawing.Size(112, 23);
			this.btnGetLoc.TabIndex = 7;
			this.btnGetLoc.Text = "Get My Location";
			this.btnGetLoc.Click += new System.EventHandler(this.btnGetLoc_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 214);
			this.Controls.Add(this.btnGetLoc);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			string username = txtUser.Text.Trim();
			string password = txtPassword.Text.Trim();
			string ip = txtIP.Text.Trim();
			int port = int.Parse(txtPort.Text.Trim());

			// Attempt to login with the static OrbClient class. If successful, the OrbClient will maintain
			// a connection with the server until the app is shutdown.
			LoginResult result = OrbClient.LoginToServer(username, password, ip, port);

			if(result.Code == LoginCodes.Success)
			{
				MessageBox.Show("Connection Successful");
			}
			else
			{
				MessageBox.Show(result.ErrorMessage);
			}
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			string msg = txtMessage.Text.Trim();

			if(OrbClient.IsConnected)
			{
				Ultima.Client.BringToTop();

				// send the command to the scripted OrbServer using the registered alias
				OrbClient.SendCommand("SendMessage", new SendMessageArgs(msg));
			}
			else
			{
				MessageBox.Show("Not Connected to the Server");
			}
		}

		private void btnGetLoc_Click(object sender, System.EventArgs e)
		{
			if(OrbClient.IsConnected)
			{
				// execute the request and cast the response to the GetLocationResponse type
				GetLocationResponse resp = (GetLocationResponse)OrbClient.SendRequest("GetMyLocation", null);

				if(resp != null)
				{
					// diplay the character's location
					MessageBox.Show(resp.ToString());
				}
				else
					// request failed to return data
					MessageBox.Show("GetMyLocation request failed");
			}
			else
			{
				MessageBox.Show("Not Connected to the Server");
			}
		}

	}
}
