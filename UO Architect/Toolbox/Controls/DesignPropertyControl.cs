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
	/// Summary description for DesignPropertyControl.
	/// </summary>
	public class DesignPropertyControl : System.Windows.Forms.UserControl
	{
		private const int FLOOR_HEIGHT = 20;
		private const int FOUNDATION_HEIGHT = 6;
		private string _category = "Unassigned";
		private string _subsection = "Unassigned";
		private string _designName = "New Design";
		private bool _custom = false;
		private int[] _defaultLevelZ = { 0, 7, 27, 47, 67, 87, 107 };
		private ArrayList _levelZ = new ArrayList();

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnGetLevelZ;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numLevelZ;
		private System.Windows.Forms.ComboBox cboLevel;
		private System.Windows.Forms.CheckBox chkCustomLevels;
		private System.Windows.Forms.ComboBox cboSubsection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DesignPropertyControl()
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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			Connection.OnBusy += new Connection.ClientBusyEvent(OnClientBusy);
			Connection.OnConnect += new Connection.ConnectEvent(OnConnection);
			Connection.OnDisconnect += new Connection.DisconnectEvent(OnDisconnection);
			Connection.OnReady += new Connection.ClientReadyEvent(OnClientReady);
			CategoryList.OnRefresh += new CategoryList.CategoryRefresh(RefreshCategories);

			PopulateCategories();
			SetDefaultValues();
			UpdateControlStates();
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DesignPropertyControl));
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnGetLevelZ = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.numLevelZ = new System.Windows.Forms.NumericUpDown();
			this.cboLevel = new System.Windows.Forms.ComboBox();
			this.chkCustomLevels = new System.Windows.Forms.CheckBox();
			this.cboSubsection = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLevelZ)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnGetLevelZ);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.numLevelZ);
			this.groupBox3.Controls.Add(this.cboLevel);
			this.groupBox3.Controls.Add(this.chkCustomLevels);
			this.groupBox3.Controls.Add(this.cboSubsection);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.txtName);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.cboCategory);
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(176, 144);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Properties";
			// 
			// btnGetLevelZ
			// 
			this.btnGetLevelZ.Enabled = false;
			this.btnGetLevelZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnGetLevelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGetLevelZ.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLevelZ.Image")));
			this.btnGetLevelZ.Location = new System.Drawing.Point(135, 117);
			this.btnGetLevelZ.Name = "btnGetLevelZ";
			this.btnGetLevelZ.Size = new System.Drawing.Size(32, 20);
			this.btnGetLevelZ.TabIndex = 6;
			this.btnGetLevelZ.Click += new System.EventHandler(this.btnGetLevelZ_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(74, 119);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 16);
			this.label5.TabIndex = 22;
			this.label5.Text = "Z";
			// 
			// numLevelZ
			// 
			this.numLevelZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numLevelZ.Enabled = false;
			this.numLevelZ.Location = new System.Drawing.Point(90, 117);
			this.numLevelZ.Maximum = new System.Decimal(new int[] {
																	  128,
																	  0,
																	  0,
																	  0});
			this.numLevelZ.Minimum = new System.Decimal(new int[] {
																	  127,
																	  0,
																	  0,
																	  -2147483648});
			this.numLevelZ.Name = "numLevelZ";
			this.numLevelZ.Size = new System.Drawing.Size(40, 20);
			this.numLevelZ.TabIndex = 5;
			// 
			// cboLevel
			// 
			this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLevel.Location = new System.Drawing.Point(8, 115);
			this.cboLevel.Name = "cboLevel";
			this.cboLevel.Size = new System.Drawing.Size(64, 21);
			this.cboLevel.TabIndex = 4;
			this.cboLevel.SelectedIndexChanged += new System.EventHandler(this.cboLevel_SelectedIndexChanged);
			// 
			// chkCustomLevels
			// 
			this.chkCustomLevels.Location = new System.Drawing.Point(9, 94);
			this.chkCustomLevels.Name = "chkCustomLevels";
			this.chkCustomLevels.Size = new System.Drawing.Size(160, 16);
			this.chkCustomLevels.TabIndex = 3;
			this.chkCustomLevels.Text = "Set starting z for each level";
			this.chkCustomLevels.CheckedChanged += new System.EventHandler(this.chkCustomLevels_CheckedChanged);
			// 
			// cboSubsection
			// 
			this.cboSubsection.Location = new System.Drawing.Point(64, 64);
			this.cboSubsection.Name = "cboSubsection";
			this.cboSubsection.Size = new System.Drawing.Size(104, 21);
			this.cboSubsection.TabIndex = 2;
			this.cboSubsection.Text = "Unassigned";
			this.cboSubsection.Leave += new System.EventHandler(this.cboSubsection_Leave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "Subsect:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(64, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(104, 20);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "New Design";
			this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Category:";
			// 
			// cboCategory
			// 
			this.cboCategory.Location = new System.Drawing.Point(64, 40);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(104, 21);
			this.cboCategory.TabIndex = 1;
			this.cboCategory.Text = "Unassigned";
			this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
			this.cboCategory.Leave += new System.EventHandler(this.cboCategory_Leave);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(8, 96);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(160, 16);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Set starting z for each level";
			this.checkBox1.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(72, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(11, 16);
			this.label2.TabIndex = 22;
			this.label2.Text = "Z";
			this.label2.Visible = false;
			// 
			// DesignPropertyControl
			// 
			this.Controls.Add(this.groupBox3);
			this.Name = "DesignPropertyControl";
			this.Size = new System.Drawing.Size(176, 144);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numLevelZ)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties

		public string DesignName
		{
			get{ return _designName; }
		}

		public string Category
		{
			get{ return _category; }
		}

		public string Subsection
		{
			get{ return _subsection; }
		}

		public bool CustomLevels
		{
			get{ return _custom; }
		}

		public ArrayList LevelZ
		{
			get{ return _levelZ; }
		}

		public int Levels
		{
			get{ return _levelZ.Count; }
		}

		#endregion

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

		private void SetDefaultValues()
		{
			_levelZ.Clear();
			_levelZ.AddRange(_defaultLevelZ);

			PopulateLevelList();
			UpdateControlStates();
		}

		private void PopulateLevelList()
		{
			cboLevel.BeginUpdate();
			cboLevel.Items.Clear();

			for(int i=0; i < _levelZ.Count; ++i)
				cboLevel.Items.Add(string.Format("Level {0}", i + 1));

			cboLevel.SelectedIndex = 0;
			cboLevel.EndUpdate();
		}

		private void cboLevel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int z = (int)_levelZ[cboLevel.SelectedIndex];
			numLevelZ.Value = (decimal)z;
		}

		private void txtName_Leave(object sender, System.EventArgs e)
		{
			_designName = txtName.Text.Trim();

			if(_designName.Length == 0)
				_designName = "New Design";
		}

		private void cboCategory_Leave(object sender, System.EventArgs e)
		{
			_category = cboCategory.Text.Trim();

			if(_category.Length == 0)
				_category = "Unassigned";
		}

		private void cboSubsection_Leave(object sender, System.EventArgs e)
		{
			_subsection = cboSubsection.Text.Trim();

			if(_subsection.Length == 0)
				_subsection = "Unassigned";
		}

		private void btnGetLevelZ_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			GetLocationResp resp = Connection.SendGetLocationRequest(null);

			if(resp != null)
			{
				numLevelZ.Value = (decimal)resp.Z;
				_levelZ[cboLevel.SelectedIndex] = resp.Z;
			}

			Cursor.Current = Cursors.Default;
		}

		public void UpdateControlStates()
		{
			chkCustomLevels.Enabled = false;
			if(_custom)
			{
//				PopulateLevelList();
//				numLevelZ.Enabled = true;
//				cboLevel.Enabled = true;
//
//				if(Connection.IsConnected && !Connection.IsBusy)
//					btnGetLevelZ.Enabled = true;
//				else
//					btnGetLevelZ.Enabled = false;
			}
			else
			{
				cboLevel.Items.Clear();
				numLevelZ.Enabled = false;
				btnGetLevelZ.Enabled = false;
				cboLevel.Enabled = false;
			}
		}

		private void chkCustomLevels_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkCustomLevels.Checked)
			{
				_custom = true;
				PopulateLevelList();
				UpdateControlStates();
			}
			else
			{
				_custom = false;
				SetDefaultValues();
			}
		}

		private void PopulateCategories()
		{
			cboCategory.Items.Clear();

			string[] categories = CategoryList.GetCategoryNames();

			if(categories == null)
				return;

			foreach(string category in categories)
				cboCategory.Items.Add(category);
		}

		private void PopulateSubCategoryList(string category)
		{
			string[] subSections = CategoryList.GetSubSectionNames(category);

			cboSubsection.Items.Clear();

			if(subSections == null)
			{
				cboSubsection.Text = "Unassigned";
				return;
			}

			foreach(string subCategory in subSections)
			{
				cboSubsection.Items.Add(subCategory);
				cboSubsection.SelectedIndex = 0;
			}
		}

		private int FindCategoryIndex(string category)
		{
			int index = -1;

			string searchStr = category.ToLower();

			for(int i=0; i < cboCategory.Items.Count; ++i)
			{
				if(cboCategory.Items[i].ToString().ToLower() == searchStr)
				{
					index = i;
					break;
				}
			}

			return index;
		}

		private void cboCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateSubCategoryList(cboCategory.Text);
		}

		public void RefreshCategories()
		{
			PopulateCategories();
		}

	}
}
