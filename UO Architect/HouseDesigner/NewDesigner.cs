using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UOArchitect
{
	public class NewDesigner : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnCreate;
		private System.ComponentModel.Container components = null;

		public NewDesigner()
		{
			InitializeComponent();
		}

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
			this.btnCreate = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCreate);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numHeight);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.numWidth);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(64, 88);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(96, 24);
			this.btnCreate.TabIndex = 6;
			this.btnCreate.Text = "&Create";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(64, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(96, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "New Design";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Height:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(64, 64);
			this.numHeight.Maximum = new System.Decimal(new int[] {
																	  256,
																	  0,
																	  0,
																	  0});
			this.numHeight.Minimum = new System.Decimal(new int[] {
																	  4,
																	  0,
																	  0,
																	  0});
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(96, 20);
			this.numHeight.TabIndex = 5;
			this.numHeight.Value = new System.Decimal(new int[] {
																	12,
																	0,
																	0,
																	0});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Width:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(64, 40);
			this.numWidth.Maximum = new System.Decimal(new int[] {
																	 256,
																	 0,
																	 0,
																	 0});
			this.numWidth.Minimum = new System.Decimal(new int[] {
																	 4,
																	 0,
																	 0,
																	 0});
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(96, 20);
			this.numWidth.TabIndex = 3;
			this.numWidth.Value = new System.Decimal(new int[] {
																   12,
																   0,
																   0,
																   0});
			// 
			// NewDesigner
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(186, 135);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "NewDesigner";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Design";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			string name = txtName.Text;
			int width = (int)numWidth.Value;
			int height = (int)numHeight.Value;
			Close();
			new HouseDesigner( new HouseDesign( name, width, height )).Show();
		}
	}
}
