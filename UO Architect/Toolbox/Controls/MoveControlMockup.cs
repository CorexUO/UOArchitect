using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for MoveControlMockup.
	/// </summary>
	public class MoveControlMockup : System.Windows.Forms.UserControl
	{
		public delegate void MoveItemsEvent(short xoffset, short yoffset);
		public delegate void NudgeItemsEvent(short zoffset);

		public MoveItemsEvent OnMoveItems;
		public NudgeItemsEvent OnNudgeItems;

		private int _moveAmount = 1;
		private short _nudgeAmount = 1;

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

		private System.Windows.Forms.Button btnLower;
		private System.Windows.Forms.Button btnRaise;
		private System.Windows.Forms.Button btnNW;
		private System.Windows.Forms.Button btnW;
		private System.Windows.Forms.Button btnSW;
		private System.Windows.Forms.Button btnS;
		private System.Windows.Forms.Button btnSE;
		private System.Windows.Forms.Button btnE;
		private System.Windows.Forms.Button btnNE;
		private System.Windows.Forms.Button btnN;
		private System.Windows.Forms.TextBox txtNudgeAmount;
		private System.Windows.Forms.TextBox txtMoveAmount;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MoveControlMockup()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MoveControlMockup));
			this.txtNudgeAmount = new System.Windows.Forms.TextBox();
			this.txtMoveAmount = new System.Windows.Forms.TextBox();
			this.btnLower = new System.Windows.Forms.Button();
			this.btnRaise = new System.Windows.Forms.Button();
			this.btnNW = new System.Windows.Forms.Button();
			this.btnW = new System.Windows.Forms.Button();
			this.btnSW = new System.Windows.Forms.Button();
			this.btnS = new System.Windows.Forms.Button();
			this.btnSE = new System.Windows.Forms.Button();
			this.btnE = new System.Windows.Forms.Button();
			this.btnNE = new System.Windows.Forms.Button();
			this.btnN = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtNudgeAmount
			// 
			this.txtNudgeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNudgeAmount.Location = new System.Drawing.Point(104, 26);
			this.txtNudgeAmount.Name = "txtNudgeAmount";
			this.txtNudgeAmount.Size = new System.Drawing.Size(32, 20);
			this.txtNudgeAmount.TabIndex = 29;
			this.txtNudgeAmount.Text = "1";
			this.txtNudgeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtNudgeAmount.Leave += new System.EventHandler(this.txtNudgeAmount_Leave);
			// 
			// txtMoveAmount
			// 
			this.txtMoveAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMoveAmount.Location = new System.Drawing.Point(32, 26);
			this.txtMoveAmount.Name = "txtMoveAmount";
			this.txtMoveAmount.Size = new System.Drawing.Size(32, 20);
			this.txtMoveAmount.TabIndex = 28;
			this.txtMoveAmount.Text = "1";
			this.txtMoveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtMoveAmount.Leave += new System.EventHandler(this.txtMoveAmount_Leave);
			// 
			// btnLower
			// 
			this.btnLower.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnLower.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLower.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnLower.Image = ((System.Drawing.Image)(resources.GetObject("btnLower.Image")));
			this.btnLower.Location = new System.Drawing.Point(104, 48);
			this.btnLower.Name = "btnLower";
			this.btnLower.Size = new System.Drawing.Size(32, 24);
			this.btnLower.TabIndex = 27;
			this.btnLower.Click += new System.EventHandler(this.btnLower_Click_1);
			// 
			// btnRaise
			// 
			this.btnRaise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRaise.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRaise.Image = ((System.Drawing.Image)(resources.GetObject("btnRaise.Image")));
			this.btnRaise.Location = new System.Drawing.Point(104, 0);
			this.btnRaise.Name = "btnRaise";
			this.btnRaise.Size = new System.Drawing.Size(32, 24);
			this.btnRaise.TabIndex = 26;
			this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
			// 
			// btnNW
			// 
			this.btnNW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNW.Image = ((System.Drawing.Image)(resources.GetObject("btnNW.Image")));
			this.btnNW.Location = new System.Drawing.Point(0, 0);
			this.btnNW.Name = "btnNW";
			this.btnNW.Size = new System.Drawing.Size(32, 24);
			this.btnNW.TabIndex = 25;
			this.btnNW.Click += new System.EventHandler(this.btnNW_Click);
			// 
			// btnW
			// 
			this.btnW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnW.Image = ((System.Drawing.Image)(resources.GetObject("btnW.Image")));
			this.btnW.Location = new System.Drawing.Point(0, 24);
			this.btnW.Name = "btnW";
			this.btnW.Size = new System.Drawing.Size(32, 24);
			this.btnW.TabIndex = 24;
			this.btnW.Click += new System.EventHandler(this.btnW_Click);
			// 
			// btnSW
			// 
			this.btnSW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSW.Image = ((System.Drawing.Image)(resources.GetObject("btnSW.Image")));
			this.btnSW.Location = new System.Drawing.Point(0, 48);
			this.btnSW.Name = "btnSW";
			this.btnSW.Size = new System.Drawing.Size(32, 24);
			this.btnSW.TabIndex = 23;
			this.btnSW.Click += new System.EventHandler(this.btnSW_Click);
			// 
			// btnS
			// 
			this.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnS.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnS.Image = ((System.Drawing.Image)(resources.GetObject("btnS.Image")));
			this.btnS.Location = new System.Drawing.Point(32, 48);
			this.btnS.Name = "btnS";
			this.btnS.Size = new System.Drawing.Size(32, 24);
			this.btnS.TabIndex = 22;
			this.btnS.Click += new System.EventHandler(this.btnS_Click);
			// 
			// btnSE
			// 
			this.btnSE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSE.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSE.Image = ((System.Drawing.Image)(resources.GetObject("btnSE.Image")));
			this.btnSE.Location = new System.Drawing.Point(64, 48);
			this.btnSE.Name = "btnSE";
			this.btnSE.Size = new System.Drawing.Size(32, 24);
			this.btnSE.TabIndex = 21;
			this.btnSE.Click += new System.EventHandler(this.btnSE_Click);
			// 
			// btnE
			// 
			this.btnE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnE.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnE.Image = ((System.Drawing.Image)(resources.GetObject("btnE.Image")));
			this.btnE.Location = new System.Drawing.Point(64, 24);
			this.btnE.Name = "btnE";
			this.btnE.Size = new System.Drawing.Size(32, 24);
			this.btnE.TabIndex = 20;
			this.btnE.Click += new System.EventHandler(this.btnE_Click);
			// 
			// btnNE
			// 
			this.btnNE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNE.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnNE.Image = ((System.Drawing.Image)(resources.GetObject("btnNE.Image")));
			this.btnNE.Location = new System.Drawing.Point(64, 0);
			this.btnNE.Name = "btnNE";
			this.btnNE.Size = new System.Drawing.Size(32, 24);
			this.btnNE.TabIndex = 19;
			this.btnNE.Click += new System.EventHandler(this.btnNE_Click);
			// 
			// btnN
			// 
			this.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnN.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnN.Image = ((System.Drawing.Image)(resources.GetObject("btnN.Image")));
			this.btnN.Location = new System.Drawing.Point(32, 0);
			this.btnN.Name = "btnN";
			this.btnN.Size = new System.Drawing.Size(32, 24);
			this.btnN.TabIndex = 18;
			this.btnN.Click += new System.EventHandler(this.btnN_Click);
			// 
			// MoveControlMockup
			// 
			this.Controls.Add(this.txtNudgeAmount);
			this.Controls.Add(this.txtMoveAmount);
			this.Controls.Add(this.btnLower);
			this.Controls.Add(this.btnRaise);
			this.Controls.Add(this.btnNW);
			this.Controls.Add(this.btnW);
			this.Controls.Add(this.btnSW);
			this.Controls.Add(this.btnS);
			this.Controls.Add(this.btnSE);
			this.Controls.Add(this.btnE);
			this.Controls.Add(this.btnNE);
			this.Controls.Add(this.btnN);
			this.Name = "MoveControlMockup";
			this.Size = new System.Drawing.Size(136, 72);
			this.ResumeLayout(false);

		}
		#endregion

		private void txtMoveAmount_Leave(object sender, System.EventArgs e)
		{
			int amount = 1;

			try
			{
				amount = int.Parse(txtMoveAmount.Text.Trim());

				if(amount < 1)
					amount = 1;
			}
			catch
			{
				amount = 1;
			}

			_moveAmount = amount;
			txtMoveAmount.Text = _moveAmount.ToString();
		}

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
			MoveItems(MoveDirections.NW, _moveAmount);
		}

		private void btnN_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.N, _moveAmount);
		}

		private void btnNE_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.NE, _moveAmount);
		}

		private void btnE_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.E, _moveAmount);
		}

		private void btnSE_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.SE, _moveAmount);
		}

		private void btnS_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.S, _moveAmount);
		}

		private void btnSW_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.SW, _moveAmount);
		}

		private void btnW_Click(object sender, System.EventArgs e)
		{
			MoveItems(MoveDirections.W, _moveAmount);
		}

		private void btnRaise_Click(object sender, System.EventArgs e)
		{
			if(OnNudgeItems != null)
				OnNudgeItems(_nudgeAmount);
		}

		private void btnLower_Click_1(object sender, System.EventArgs e)
		{
			if(OnNudgeItems != null)
				OnNudgeItems((short)(_nudgeAmount * -1));
		}

		private void txtNudgeAmount_Leave(object sender, System.EventArgs e)
		{
			int amount = 1;

			try
			{
				amount = int.Parse(txtNudgeAmount.Text.Trim());

				if(amount < 1)
					amount = 1;
			}
			catch
			{
				amount = 1;
			}

			_nudgeAmount = (short)amount;
			txtNudgeAmount.Text = _nudgeAmount.ToString();
		}
	}
}
