using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for DesignsPanel.
	/// </summary>
	public class DesignsPanel : System.Windows.Forms.UserControl
	{
		#region Auto Code

		private System.Windows.Forms.Label lblDesignDesc;
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.Button btnDesigner;
		private System.Windows.Forms.Button btnProperties;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnBuild;
		private System.Windows.Forms.GroupBox groupBox1;
		private UOArchitect.DesignTreeView tvwDesigns;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.Button btnPatch;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DesignsPanel()
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
			this.lblDesignDesc = new System.Windows.Forms.Label();
			this.btnPreview = new System.Windows.Forms.Button();
			this.btnDesigner = new System.Windows.Forms.Button();
			this.btnProperties = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnBuild = new System.Windows.Forms.Button();
			this.btnPatch = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tvwDesigns = new UOArchitect.DesignTreeView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblDesignDesc
			// 
			this.lblDesignDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDesignDesc.ForeColor = System.Drawing.Color.Navy;
			this.lblDesignDesc.Location = new System.Drawing.Point(8, 1);
			this.lblDesignDesc.Name = "lblDesignDesc";
			this.lblDesignDesc.Size = new System.Drawing.Size(176, 16);
			this.lblDesignDesc.TabIndex = 1;
			// 
			// btnPreview
			// 
			this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPreview.Location = new System.Drawing.Point(96, 80);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(72, 23);
			this.btnPreview.TabIndex = 1;
			this.btnPreview.Text = "Preview";
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// btnDesigner
			// 
			this.btnDesigner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDesigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDesigner.Location = new System.Drawing.Point(96, 48);
			this.btnDesigner.Name = "btnDesigner";
			this.btnDesigner.Size = new System.Drawing.Size(72, 23);
			this.btnDesigner.TabIndex = 2;
			this.btnDesigner.Text = "Editor";
			this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
			// 
			// btnProperties
			// 
			this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnProperties.Location = new System.Drawing.Point(8, 16);
			this.btnProperties.Name = "btnProperties";
			this.btnProperties.Size = new System.Drawing.Size(72, 23);
			this.btnProperties.TabIndex = 3;
			this.btnProperties.Text = "Properties";
			this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(8, 80);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(72, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnBuild
			// 
			this.btnBuild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBuild.Location = new System.Drawing.Point(96, 16);
			this.btnBuild.Name = "btnBuild";
			this.btnBuild.Size = new System.Drawing.Size(72, 23);
			this.btnBuild.TabIndex = 4;
			this.btnBuild.Text = "Build";
			this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
			// 
			// btnPatch
			// 
			this.btnPatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPatch.Location = new System.Drawing.Point(8, 48);
			this.btnPatch.Name = "btnPatch";
			this.btnPatch.Size = new System.Drawing.Size(72, 23);
			this.btnPatch.TabIndex = 6;
			this.btnPatch.Text = "Patch Muls";
			this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnDesigner);
			this.groupBox1.Controls.Add(this.btnProperties);
			this.groupBox1.Controls.Add(this.btnDelete);
			this.groupBox1.Controls.Add(this.btnPatch);
			this.groupBox1.Controls.Add(this.btnPreview);
			this.groupBox1.Controls.Add(this.btnBuild);
			this.groupBox1.Location = new System.Drawing.Point(8, 248);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 112);
			this.groupBox1.TabIndex = 50;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Actions";
			// 
			// tvwDesigns
			// 
			this.tvwDesigns.Location = new System.Drawing.Point(8, 20);
			this.tvwDesigns.Name = "tvwDesigns";
			this.tvwDesigns.Size = new System.Drawing.Size(176, 220);
			this.tvwDesigns.TabIndex = 0;
			// 
			// DesignsPanel
			// 
			this.Controls.Add(this.tvwDesigns);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblDesignDesc);
			this.Name = "DesignsPanel";
			this.Size = new System.Drawing.Size(192, 360);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Members

		private enum MenuActions
		{
			None = 0,
			Extract = 1
		}

		// Events
		public delegate void DesignSelected();
		public delegate void DesignUnselected();
		public DesignSelected OnDesignSelected;
		public DesignUnselected OnDesignUnselected;

		private MenuActions _currentAction;
		private MenuItem _mnuExportDesigns;
		private MenuItem _mnuDeleteDesigns;
		private MenuItem _mnuBuildDesign;
		private MenuItem _mnuEditDesign;
		private MenuItem _mnuPreviewDesign;
		#endregion

		#region Properties

		private bool IsSelected
		{
			get{ return (tvwDesigns.SelectedNode != null); }
		}

		private DesignNode SelectedNode
		{
			get{ return tvwDesigns.SelectedNode; }
		}

		public DesignData SelectedDesign
		{
			get
			{
				DesignData design = null;

				if(IsSelected)
					design = SelectedNode.Design;

				return design;
			}
		}

		#endregion

		protected override void OnLoad(System.EventArgs e)
		{
			tvwDesigns.OnSelected += new DesignTreeView.DesignNodeSelected(OnSelection);
			tvwDesigns.OnDoubleClickDesign += new DesignTreeView.DoubleClickDesign(OnDoubleClickDesign);
			tvwDesigns.OnRightClickNode += new DesignTreeView.RightClickNode(OnRightClickNode);

			_mnuExportDesigns = new MenuItem("Export");
			_mnuDeleteDesigns = new MenuItem("Delete");
			_mnuBuildDesign = new MenuItem("Build");
			_mnuEditDesign = new MenuItem("Edit");
			_mnuPreviewDesign = new MenuItem("Preview");
			_mnuExportDesigns.Click += new EventHandler(_mnuExportDesigns_Click);
			_mnuDeleteDesigns.Click += new EventHandler(_mnuDeleteDesigns_Click);
			_mnuBuildDesign.Click += new EventHandler(_mnuBuildDesign_Click);
			_mnuEditDesign.Click += new EventHandler(_mnuEditDesign_Click);
			_mnuPreviewDesign.Click += new EventHandler(_mnuPreviewDesign_Click);

			tvwDesigns.Populate(HouseDesignData.DesignHeaders);

			Connection.OnBusy += new Connection.ClientBusyEvent(OnClientBusy);
			Connection.OnConnect += new Connection.ConnectEvent(OnConnection);
			Connection.OnDisconnect += new Connection.DisconnectEvent(OnDisconnection);
			Connection.OnReady += new Connection.ClientReadyEvent(OnClientReady);

			HouseDesignData.OnRefreshDesignsList += new HouseDesignData.RefreshDesignsList(OnRefreshDesignList);
			
			UpdateControlStates();
		}

		private void OnRefreshDesignList()
		{
			tvwDesigns.Populate(HouseDesignData.DesignHeaders);
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

		private void OnDoubleClickDesign(DesignNode node)
		{
			OpenDesignPreview(node.Design);
		}

		private void OnSelection(DesignNode node)
		{
			if(node != null)
			{
				lblDesignDesc.Text = string.Format("{0}: {1} items", node.Design.Name, node.Design.RecordCount);
				
				if(OnDesignSelected != null)
					OnDesignSelected();
			}
			else
			{
				lblDesignDesc.Text = "";

				if(OnDesignUnselected != null)
					OnDesignUnselected();
			}

			UpdateControlStates();
		}

		private void btnPreview_Click(object sender, System.EventArgs e)
		{
			if(IsSelected)
			{
				OpenDesignPreview(SelectedNode.Design);
			}
		}

		private void OpenDesignPreview(DesignData design)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(!design.IsLoaded)
				design.Load();

			Cursor.Current = Cursors.Default;

			new DesignPreview().LoadForm(new HouseDesign(design));
		}

		private void btnProperties_Click(object sender, System.EventArgs e)
		{
			if(SelectedNode != null)
			{	
				if(!SelectedNode.Design.IsLoaded)
					SelectedNode.Design.Load();

				DesignPropertyEditor dlg = new DesignPropertyEditor();
				DesignData design = SelectedNode.Design;

				dlg.LoadForm(ref design);

				if(dlg.DialogResult == DialogResult.OK)
				{
					Cursor.Current = Cursors.WaitCursor;
					design.Save();
					Cursor.Current = Cursors.Default;
				}

				design.Unload();
				dlg.Dispose();
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(SelectedNode != null)
			{
				SelectedNode.Delete();
			}

			Cursor.Current = Cursors.Default;
		}

		private void btnBuild_Click(object sender, System.EventArgs e)
		{
			if(SelectedNode != null)
				OpenBuildDialog(SelectedNode.Design);
		}

		private void OpenBuildDialog(DesignData design)
		{
			new BuildDialog(this.ParentForm).LoadForm(design);
		}

		private void OpenSelectedDesignInEditor()
		{
			Cursor.Current = Cursors.WaitCursor;

			if(SelectedNode != null)
			{
				if(!SelectedNode.Design.IsLoaded)
					SelectedNode.Design.Load();

				HouseDesign design = new HouseDesign(SelectedNode.Design);

				HouseDesigner dlg = new HouseDesigner(design);
				dlg.Show();
				dlg.WindowState = FormWindowState.Maximized;
			}

			Cursor.Current = Cursors.Default;
		}

		private void btnDesigner_Click(object sender, System.EventArgs e)
		{
			OpenSelectedDesignInEditor();
		}

		public void UpdateControlStates()
		{
			if(Connection.IsConnected && !Connection.IsBusy && SelectedNode != null)
			{
				btnBuild.Enabled = true;
			}
			else
			{
				btnBuild.Enabled = false;
			}

			btnPreview.Enabled = IsSelected;
			btnDelete.Enabled = IsSelected;
			btnDesigner.Enabled = IsSelected;
			btnProperties.Enabled = IsSelected;
			btnPatch.Enabled = IsSelected;
		}

		private void OnRightClickNode(TreeNode node)
		{	
			if(node is CategoryNode || node is SubsectionNode)
			{
				_mnuExportDesigns.Text = "Export Designs";
				_mnuDeleteDesigns.Text = "Delete Designs";
			}
			else
			{
				_mnuExportDesigns.Text = "Export";
				_mnuDeleteDesigns.Text = "Delete";
			}

			contextMenu1.MenuItems.Clear();

			if(node is DesignNode)
			{
				contextMenu1.MenuItems.Add(_mnuBuildDesign);
				contextMenu1.MenuItems.Add(_mnuPreviewDesign);
				contextMenu1.MenuItems.Add(new MenuItem("-"));
				contextMenu1.MenuItems.Add(_mnuEditDesign);
			}

			contextMenu1.MenuItems.Add(_mnuDeleteDesigns);

			if(node is DesignNode)
			{
				contextMenu1.MenuItems.Add(new MenuItem("-"));
			}

			contextMenu1.MenuItems.Add(_mnuExportDesigns);
			contextMenu1.Show(tvwDesigns, tvwDesigns.MouseCoords);
		}

		private void _mnuExportDesigns_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			TreeNode node = tvwDesigns.GetNodeAt(tvwDesigns.MouseCoords);

			if(node != null)
			{
				ExtractDesignsFromNode(node);
			}

			Cursor.Current = Cursors.Default;
		}

		private void ExtractDesignsFromNode(TreeNode node)
		{
			try
			{
				ArrayList designs = new ArrayList();

				if(node is CategoryNode)
				{
					GetDesignsFromCategoryNode((CategoryNode)node, ref designs);
				}
				else if(node is SubsectionNode)
				{
					GetDesignsFromSubsectionNode((SubsectionNode)node, ref designs);
				}
				else if(node is DesignNode)
				{
					designs.Add(((DesignNode)node).Design);
				}

				if(designs.Count > 0)
				{
					UOARBatchDataAdapter adapter = new UOARBatchDataAdapter();
					adapter.ExportDesigns(designs, node.Text);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Export failed: \n" + ex.Message);
			}
		}

		private void GetDesignsFromCategoryNode(CategoryNode node, ref ArrayList designs)
		{
			foreach(SubsectionNode subNode in node.Nodes)
			{
				GetDesignsFromSubsectionNode(subNode, ref designs);
			}
		}

		private void GetDesignsFromSubsectionNode(SubsectionNode node, ref ArrayList designs)
		{
			foreach(DesignNode subNode in node.Nodes)
			{
				designs.Add(subNode.Design);
			}
		}

		private void btnPatch_Click(object sender, System.EventArgs e)
		{
			if(Config.DoTargetMultiMulsExist)
			{

				DialogResult response = MessageBox.Show("Are you sure you want to patch this multi to the multi muls?", "Multi Patcher",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
			
				if(response == DialogResult.Yes)
				{
					int index = this.SelectedDesign.PatchToMultiMuls(Config.CreateMultiPatchInfo());

					string result = "";

					if(index != 1)
					{
						result = string.Format("This design was succesfully patched to multi index {0}.", index);
					}
					else
					{
						result = "The multi patch failed. The target multi muls may be in use by another program.";
					}

					MessageBox.Show(result, "Patch Results");
				}
			}
			else
			{
				MessageBox.Show("The target multi muls specified on the Options tab do not exist", "Invalid Multi Mul Settings");
			}
		}

		private void _mnuDeleteDesigns_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			TreeNode node = tvwDesigns.GetNodeAt(tvwDesigns.MouseCoords);

			if(node != null)
			{
				DeleteDesignsFromNode(node);
			}

			Cursor.Current = Cursors.Default;
		}

		private void DeleteDesignsFromNode(TreeNode node)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "UO Architect", MessageBoxButtons.YesNo);

			if(result == DialogResult.No)
			{
				return;
			}

			try
			{
				ArrayList designs = new ArrayList();

				if(node is CategoryNode)
				{
					GetDesignsFromCategoryNode((CategoryNode)node, ref designs);
				}
				else if(node is SubsectionNode)
				{
					GetDesignsFromSubsectionNode((SubsectionNode)node, ref designs);
				}
				else if(node is DesignNode)
				{
					((DesignNode)node).Delete();
				}

				if(designs.Count > 0)
				{
					foreach(DesignData design in designs)
					{
						HouseDesignData.DeleteDesign(design);
					}

					tvwDesigns.Populate(HouseDesignData.DesignHeaders);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Export failed: \n" + ex.Message);
			}
		}

		private void _mnuBuildDesign_Click(object sender, EventArgs e)
		{
			TreeNode node = tvwDesigns.GetNodeAt(tvwDesigns.MouseCoords);

			if(node != null && node is DesignNode)
			{
				OpenBuildDialog(((DesignNode)node).Design);
			}
		}

		private void _mnuEditDesign_Click(object sender, EventArgs e)
		{
			OpenSelectedDesignInEditor();
		}

		private void _mnuPreviewDesign_Click(object sender, EventArgs e)
		{
			if(IsSelected)
			{
				OpenDesignPreview(SelectedNode.Design);
			}
		}
	}
}
