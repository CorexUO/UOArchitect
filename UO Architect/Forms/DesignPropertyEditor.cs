using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for DesignPropertyEditor.
	/// </summary>
	public class DesignPropertyEditor : System.Windows.Forms.Form
	{
		private bool m_Cancelled = true;
		private string m_Name;
		private string m_Category;
		private string m_Subsection;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboSubSection;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DesignPropertyEditor()
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboSubSection = new System.Windows.Forms.ComboBox();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(88, 9);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(184, 20);
			this.txtName.TabIndex = 23;
			this.txtName.Text = "";
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 16);
			this.label3.TabIndex = 22;
			this.label3.Text = "Name:";
			// 
			// cboSubSection
			// 
			this.cboSubSection.Location = new System.Drawing.Point(88, 67);
			this.cboSubSection.Name = "cboSubSection";
			this.cboSubSection.Size = new System.Drawing.Size(184, 21);
			this.cboSubSection.Sorted = true;
			this.cboSubSection.TabIndex = 21;
			this.cboSubSection.TextChanged += new System.EventHandler(this.cboSubSection_TextChanged);
			this.cboSubSection.SelectedIndexChanged += new System.EventHandler(this.cboSubSection_SelectedIndexChanged);
			// 
			// cboCategory
			// 
			this.cboCategory.Location = new System.Drawing.Point(88, 37);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(184, 21);
			this.cboCategory.Sorted = true;
			this.cboCategory.TabIndex = 20;
			this.cboCategory.TextChanged += new System.EventHandler(this.cboCategory_TextChanged);
			this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 16);
			this.label2.TabIndex = 19;
			this.label2.Text = "SubSection:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "Category:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(200, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 24;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(120, 96);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 25;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// DesignPropertyEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 128);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboSubSection);
			this.Controls.Add(this.cboCategory);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DesignPropertyEditor";
			this.ShowInTaskbar = false;
			this.Text = "Design Properties";
			this.ResumeLayout(false);

		}
		#endregion

		public bool Cancelled
		{
			get{ return m_Cancelled; }
		}

		public void LoadForm(ref DesignData design)
		{
			PopulateCategories();
			SelectCategory(design.Category);

			m_Name = design.Name;
			m_Category = design.Category;
			m_Subsection = design.Subsection;
			txtName.Text = design.Name;
			cboCategory.Text = design.Category;
			cboSubSection.Text = design.Subsection;

			this.ShowDialog();

			if(!m_Cancelled)
			{
				design.Name = m_Name;
				design.Category = m_Category;
				design.Subsection = m_Subsection;
			}
		}

		public void LoadForm(ref HouseDesign design, Form parent)
		{
			PopulateCategories();
			SelectCategory(design.Category);

			m_Name = design.Name;
			m_Category = design.Category;
			m_Subsection = design.SubSection;
			txtName.Text = design.Name;
			cboCategory.Text = design.Category;
			cboSubSection.Text = design.SubSection;

			this.ShowDialog(parent);

			if(!m_Cancelled)
			{
				design.Name = m_Name;
				design.Category = m_Category;
				design.SubSection = m_Subsection;
			}
		}

		private void SelectCategory(string category)
		{
			cboSubSection.Items.Clear();
			int index = FindCategoryIndex(category);

			if(index != -1)
			{
				PopulateSubCategoryList(category);
			}
		}

		private void PopulateSubCategoryList(string category)
		{
			string[] subSections = CategoryList.GetSubSectionNames(category);

			cboSubSection.Items.Clear();

			if(subSections == null)
				return;

			foreach(string subCategory in subSections)
			{
				cboSubSection.Items.Add(subCategory);
				cboSubSection.SelectedIndex = 0;
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

		private void PopulateCategories()
		{
			string[] categories = CategoryList.GetCategoryNames();

			if(categories == null)
				return;

			foreach(string category in categories)
				cboCategory.Items.Add(category);
		}

		private void cboCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateSubCategoryList(cboCategory.Text);
		}

		private void cboCategory_TextChanged(object sender, System.EventArgs e)
		{
			SelectCategory(cboCategory.Text);
			m_Category = cboCategory.Text.Trim();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			m_Cancelled = false;
			Close();
		}

		private void txtName_TextChanged(object sender, System.EventArgs e)
		{
			m_Name = txtName.Text.Trim();
		}

		private void cboSubSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Subsection = cboSubSection.Text.Trim();
		}

		private void cboSubSection_TextChanged(object sender, System.EventArgs e)
		{
			m_Subsection = cboSubSection.Text.Trim();
		}
	}
}
