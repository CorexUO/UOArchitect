using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace UOArchitect.Toolbox.TabPanels
{
	/// <summary>
	/// Summary description for OptionsTab.
	/// </summary>
	public class OptionsTab : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPrefix;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkAutoDetect;
		private System.Windows.Forms.TextBox txtClientDirectory;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtMultiIdx;
		private System.Windows.Forms.TextBox txtMultiMul;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OptionsTab()
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtClientDirectory = new System.Windows.Forms.TextBox();
			this.chkAutoDetect = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtMultiIdx = new System.Windows.Forms.TextBox();
			this.txtMultiMul = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "RunUO Command Prefix:";
			// 
			// txtPrefix
			// 
			this.txtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPrefix.Location = new System.Drawing.Point(136, 8);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(32, 20);
			this.txtPrefix.TabIndex = 1;
			this.txtPrefix.Text = "";
			this.txtPrefix.Leave += new System.EventHandler(this.txtPrefix_Leave);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtClientDirectory);
			this.groupBox1.Controls.Add(this.chkAutoDetect);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(8, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "UO Client Directory";
			// 
			// txtClientDirectory
			// 
			this.txtClientDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtClientDirectory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtClientDirectory.Enabled = false;
			this.txtClientDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtClientDirectory.Location = new System.Drawing.Point(8, 48);
			this.txtClientDirectory.Name = "txtClientDirectory";
			this.txtClientDirectory.Size = new System.Drawing.Size(160, 20);
			this.txtClientDirectory.TabIndex = 4;
			this.txtClientDirectory.Text = "";
			this.txtClientDirectory.Leave += new System.EventHandler(this.txtClientDirectory_Leave);
			// 
			// chkAutoDetect
			// 
			this.chkAutoDetect.Checked = true;
			this.chkAutoDetect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAutoDetect.Location = new System.Drawing.Point(8, 24);
			this.chkAutoDetect.Name = "chkAutoDetect";
			this.chkAutoDetect.Size = new System.Drawing.Size(160, 16);
			this.chkAutoDetect.TabIndex = 3;
			this.chkAutoDetect.Text = "Auto-detect (Use Registry)";
			this.chkAutoDetect.CheckedChanged += new System.EventHandler(this.chkAutoDetect_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtMultiMul);
			this.groupBox2.Controls.Add(this.txtMultiIdx);
			this.groupBox2.Location = new System.Drawing.Point(8, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(176, 80);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Multi Patch Target";
			// 
			// txtMultiIdx
			// 
			this.txtMultiIdx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMultiIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMultiIdx.Location = new System.Drawing.Point(56, 24);
			this.txtMultiIdx.Name = "txtMultiIdx";
			this.txtMultiIdx.Size = new System.Drawing.Size(112, 20);
			this.txtMultiIdx.TabIndex = 5;
			this.txtMultiIdx.Text = "";
			this.txtMultiIdx.TextChanged += new System.EventHandler(this.txtMultiIdx_TextChanged);
			// 
			// txtMultiMul
			// 
			this.txtMultiMul.BackColor = System.Drawing.SystemColors.Window;
			this.txtMultiMul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMultiMul.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMultiMul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMultiMul.Location = new System.Drawing.Point(56, 48);
			this.txtMultiMul.Name = "txtMultiMul";
			this.txtMultiMul.Size = new System.Drawing.Size(112, 20);
			this.txtMultiMul.TabIndex = 6;
			this.txtMultiMul.Text = "";
			this.txtMultiMul.TextChanged += new System.EventHandler(this.txtMultiMul_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Multi.idx";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Multi.mul";
			// 
			// OptionsTab
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtPrefix);
			this.Controls.Add(this.label1);
			this.Name = "OptionsTab";
			this.Size = new System.Drawing.Size(192, 360);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			if(Config.AutoDetectClientDirectory || Config.ClientDirectory == String.Empty || !Directory.Exists(Config.ClientDirectory))
			{
				chkAutoDetect.Checked = true;
			}
			else
			{
				txtClientDirectory.Enabled = true;
				txtClientDirectory.Text = Config.ClientDirectory;
				chkAutoDetect.Checked = false;
				txtClientDirectory.Focus();
			}

			txtPrefix.Text = Config.CommandPrefix;
			txtMultiIdx.Text = Config.MultiIdxTarget;
			txtMultiMul.Text = Config.MultiMulTarget;
		}

		private void chkAutoDetect_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAutoDetect.Checked)
			{
				txtClientDirectory.Enabled = false;
				txtClientDirectory.Text = "";
				Config.AutoDetectClientDirectory = true;
			}
			else
			{
				Config.AutoDetectClientDirectory = false;
				txtClientDirectory.Enabled = true;
			}
		}

		private void txtClientDirectory_Leave(object sender, System.EventArgs e)
		{
			string directory = txtClientDirectory.Text.Trim();

			if(directory == String.Empty)
			{
				chkAutoDetect.Checked = true;
			}
			else if(!Directory.Exists(directory))
			{
				MessageBox.Show(string.Format("The directory {0} does not exist.", directory));
				txtClientDirectory.Focus();
			}
			else
			{
				chkAutoDetect.Checked = false;
				Config.ClientDirectory = directory;
			}
		}

		private void txtPrefix_Leave(object sender, System.EventArgs e)
		{
			string prefix = txtPrefix.Text.Trim();

			if(prefix == string.Empty)
			{
				Config.CommandPrefix = "[";
				txtPrefix.Text = Config.CommandPrefix;
			}
			else
			{
				Config.CommandPrefix = txtPrefix.Text.Trim();
			}
		}

		private void txtMultiIdx_TextChanged(object sender, System.EventArgs e)
		{
			Config.MultiIdxTarget = txtMultiIdx.Text.Trim();

			if(File.Exists(Config.MultiIdxTarget))
				txtMultiIdx.BackColor = Color.Green;
			else
				txtMultiIdx.BackColor = Color.Red;
		}

		private void txtMultiMul_TextChanged(object sender, System.EventArgs e)
		{
			Config.MultiMulTarget = txtMultiMul.Text.Trim();

			if(File.Exists(Config.MultiMulTarget))
				txtMultiMul.BackColor = Color.Green;
			else
				txtMultiMul.BackColor = Color.Red;
		}
	}
}
