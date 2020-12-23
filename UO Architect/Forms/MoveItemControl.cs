using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for MoveItemDialog.
	/// </summary>
	public class MoveItemControl : System.Windows.Forms.UserControl
	{
		public delegate void MoveItemsEvent(short xoffset, short yoffset);
		public delegate void NudgeItemsEvent(short zoffset);
		public delegate void WipeItemsEvent();

		public MoveItemsEvent OnMoveItems;
		public NudgeItemsEvent OnNudgeItems;
		public WipeItemsEvent OnWipeItems;

		public enum MoveDirections
		{
			N,
			NE,
			E,
			SE,
			S,
			SW,
			W,
			NW
		}

		private System.Windows.Forms.Button btnN;
		private System.Windows.Forms.Button btnNE;
		private System.Windows.Forms.Button btnE;
		private System.Windows.Forms.Button btnSE;
		private System.Windows.Forms.Button btnS;
		private System.Windows.Forms.Button btnSW;
		private System.Windows.Forms.Button btnW;
		private System.Windows.Forms.Button btnNW;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLower;
		private System.Windows.Forms.NumericUpDown numMoveSteps;
		private System.Windows.Forms.NumericUpDown numZAmount;
		private System.Windows.Forms.Button btnRaise;
		private System.Windows.Forms.Button btnWipe;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MoveItemControl()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MoveItemControl));
			this.btnN = new System.Windows.Forms.Button();
			this.btnNE = new System.Windows.Forms.Button();
			this.btnE = new System.Windows.Forms.Button();
			this.btnSE = new System.Windows.Forms.Button();
			this.btnS = new System.Windows.Forms.Button();
			this.btnSW = new System.Windows.Forms.Button();
			this.btnW = new System.Windows.Forms.Button();
			this.btnNW = new System.Windows.Forms.Button();
			this.btnWipe = new System.Windows.Forms.Button();
			this.numMoveSteps = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRaise = new System.Windows.Forms.Button();
			this.btnLower = new System.Windows.Forms.Button();
			this.numZAmount = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numMoveSteps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// btnN
			// 
			this.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnN.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnN.Image = ((System.Drawing.Image)(resources.GetObject("btnN.Image")));
			this.btnN.Location = new System.Drawing.Point(32, 0);
			this.btnN.Name = "btnN";
			this.btnN.Size = new System.Drawing.Size(32, 24);
			this.btnN.TabIndex = 0;
			this.btnN.Click += new System.EventHandler(this.btnN_Click);
			// 
			// btnNE
			// 
			this.btnNE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNE.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNE.Image = ((System.Drawing.Image)(resources.GetObject("btnNE.Image")));
			this.btnNE.Location = new System.Drawing.Point(64, 0);
			this.btnNE.Name = "btnNE";
			this.btnNE.Size = new System.Drawing.Size(32, 24);
			this.btnNE.TabIndex = 1;
			this.btnNE.Click += new System.EventHandler(this.btnNE_Click);
			// 
			// btnE
			// 
			this.btnE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnE.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnE.Image = ((System.Drawing.Image)(resources.GetObject("btnE.Image")));
			this.btnE.Location = new System.Drawing.Point(64, 24);
			this.btnE.Name = "btnE";
			this.btnE.Size = new System.Drawing.Size(32, 24);
			this.btnE.TabIndex = 2;
			this.btnE.Click += new System.EventHandler(this.btnE_Click);
			// 
			// btnSE
			// 
			this.btnSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSE.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSE.Image = ((System.Drawing.Image)(resources.GetObject("btnSE.Image")));
			this.btnSE.Location = new System.Drawing.Point(64, 48);
			this.btnSE.Name = "btnSE";
			this.btnSE.Size = new System.Drawing.Size(32, 24);
			this.btnSE.TabIndex = 3;
			this.btnSE.Click += new System.EventHandler(this.btnSE_Click);
			// 
			// btnS
			// 
			this.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnS.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnS.Image = ((System.Drawing.Image)(resources.GetObject("btnS.Image")));
			this.btnS.Location = new System.Drawing.Point(32, 48);
			this.btnS.Name = "btnS";
			this.btnS.Size = new System.Drawing.Size(32, 24);
			this.btnS.TabIndex = 4;
			this.btnS.Click += new System.EventHandler(this.btnS_Click);
			// 
			// btnSW
			// 
			this.btnSW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSW.Image = ((System.Drawing.Image)(resources.GetObject("btnSW.Image")));
			this.btnSW.Location = new System.Drawing.Point(0, 48);
			this.btnSW.Name = "btnSW";
			this.btnSW.Size = new System.Drawing.Size(32, 24);
			this.btnSW.TabIndex = 5;
			this.btnSW.Click += new System.EventHandler(this.btnSW_Click);
			// 
			// btnW
			// 
			this.btnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnW.Image = ((System.Drawing.Image)(resources.GetObject("btnW.Image")));
			this.btnW.Location = new System.Drawing.Point(0, 24);
			this.btnW.Name = "btnW";
			this.btnW.Size = new System.Drawing.Size(32, 24);
			this.btnW.TabIndex = 6;
			this.btnW.Click += new System.EventHandler(this.btnW_Click);
			// 
			// btnNW
			// 
			this.btnNW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNW.Image = ((System.Drawing.Image)(resources.GetObject("btnNW.Image")));
			this.btnNW.Location = new System.Drawing.Point(0, 0);
			this.btnNW.Name = "btnNW";
			this.btnNW.Size = new System.Drawing.Size(32, 24);
			this.btnNW.TabIndex = 7;
			this.btnNW.Click += new System.EventHandler(this.btnNW_Click);
			// 
			// btnWipe
			// 
			this.btnWipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnWipe.Image = ((System.Drawing.Image)(resources.GetObject("btnWipe.Image")));
			this.btnWipe.Location = new System.Drawing.Point(32, 24);
			this.btnWipe.Name = "btnWipe";
			this.btnWipe.Size = new System.Drawing.Size(32, 24);
			this.btnWipe.TabIndex = 8;
			this.btnWipe.Click += new System.EventHandler(this.btnWipe_Click);
			// 
			// numMoveSteps
			// 
			this.numMoveSteps.Location = new System.Drawing.Point(0, 80);
			this.numMoveSteps.Name = "numMoveSteps";
			this.numMoveSteps.Size = new System.Drawing.Size(40, 20);
			this.numMoveSteps.TabIndex = 9;
			this.numMoveSteps.Value = new System.Decimal(new int[] {
																	   1,
																	   0,
																	   0,
																	   0});
			this.numMoveSteps.ValueChanged += new System.EventHandler(this.numMoveSteps_ValueChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(46, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Move";
			// 
			// btnRaise
			// 
			this.btnRaise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRaise.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRaise.Image = ((System.Drawing.Image)(resources.GetObject("btnRaise.Image")));
			this.btnRaise.Location = new System.Drawing.Point(104, 0);
			this.btnRaise.Name = "btnRaise";
			this.btnRaise.Size = new System.Drawing.Size(40, 28);
			this.btnRaise.TabIndex = 11;
			this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
			// 
			// btnLower
			// 
			this.btnLower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLower.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLower.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnLower.Image = ((System.Drawing.Image)(resources.GetObject("btnLower.Image")));
			this.btnLower.Location = new System.Drawing.Point(104, 29);
			this.btnLower.Name = "btnLower";
			this.btnLower.Size = new System.Drawing.Size(40, 28);
			this.btnLower.TabIndex = 12;
			this.btnLower.Click += new System.EventHandler(this.btnLower_Click);
			// 
			// numZAmount
			// 
			this.numZAmount.Location = new System.Drawing.Point(104, 65);
			this.numZAmount.Name = "numZAmount";
			this.numZAmount.Size = new System.Drawing.Size(40, 20);
			this.numZAmount.TabIndex = 15;
			this.numZAmount.Value = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			this.numZAmount.ValueChanged += new System.EventHandler(this.numZAmount_ValueChanged);
			// 
			// MoveItemControl
			// 
			this.Controls.Add(this.numZAmount);
			this.Controls.Add(this.btnLower);
			this.Controls.Add(this.btnRaise);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numMoveSteps);
			this.Controls.Add(this.btnWipe);
			this.Controls.Add(this.btnNW);
			this.Controls.Add(this.btnW);
			this.Controls.Add(this.btnSW);
			this.Controls.Add(this.btnS);
			this.Controls.Add(this.btnSE);
			this.Controls.Add(this.btnE);
			this.Controls.Add(this.btnNE);
			this.Controls.Add(this.btnN);
			this.Name = "MoveItemControl";
			this.Size = new System.Drawing.Size(152, 104);
			((System.ComponentModel.ISupportInitialize)(this.numMoveSteps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZAmount)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		private void MoveItems(MoveDirections direction, int amount)
		{
			int x = 0;
			int y = 0;

			switch(direction)
			{
				case MoveDirections.N:
					x = -1 * amount;
					y = -1 * amount;
					break;

				case MoveDirections.NE:
					x = 0;
					y = -1 * amount;
					break;

				case MoveDirections.E:
					x = 1 * amount;
					y = -1 * amount;
					break;

				case MoveDirections.SE:
					x = 1 * amount;
					y = 0;
					break;

				case MoveDirections.S:
					x = 1 * amount;
					y = 1 * amount;
					break;

				case MoveDirections.SW:
					x = 0;
					y = 1 * amount;
					break;
				
				case MoveDirections.W:
					x = -1 * amount;
					y = 1 * amount;
					break;

				case MoveDirections.NW:
					x = -1 * amount;
					y = 0;
					break;
			}

			if(OnMoveItems != null)
				OnMoveItems((short)x, (short)y);

		}

		private void btnNW_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.NW, (int)numMoveSteps.Value);
		}

		private void btnN_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.N, (int)numMoveSteps.Value);
		}

		private void btnNE_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.NE, (int)numMoveSteps.Value);
		}

		private void btnE_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.E, (int)numMoveSteps.Value);
		}

		private void btnSE_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.SE, (int)numMoveSteps.Value);
		}

		private void btnS_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.S, (int)numMoveSteps.Value);
		}

		private void btnSW_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.SW, (int)numMoveSteps.Value);
		}

		private void btnW_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.W, (int)numMoveSteps.Value);
		}

		private void btnRaise_Click(object sender, System.EventArgs e)
		{
			if(OnNudgeItems != null)
				OnNudgeItems((short)numZAmount.Value);
		}

		private void btnLower_Click(object sender, System.EventArgs e)
		{
			if(OnNudgeItems != null)
				OnNudgeItems((short)(numZAmount.Value * -1));
		}

		private void numMoveSteps_ValueChanged(object sender, System.EventArgs e)
		{
			int num = (int)numMoveSteps.Value;

			if(num <= 0)
				numMoveSteps.Value = (decimal)1.0;
		}

		private void numZAmount_ValueChanged(object sender, System.EventArgs e)
		{
			int num = (int)numZAmount.Value;

			if(num <= 0)
				numZAmount.Value = (decimal)1.0;
		}

		private void btnWipe_Click(object sender, System.EventArgs e)
		{
			if(OnWipeItems != null)
				OnWipeItems();
		}

	}
}
