using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for DesignTreeViewcs.
	/// </summary>
	public class DesignTreeView : System.Windows.Forms.UserControl
	{
		public delegate void DesignNodeSelected(DesignNode node);
		public delegate void DoubleClickDesign(DesignNode node);
		public delegate void RightClickNode(TreeNode node);

		private int _mouseX;
		private int _mouseY;
		public DoubleClickDesign OnDoubleClickDesign;
		public DesignNodeSelected OnSelected;
		public RightClickNode OnRightClickNode;

		private DesignNode _selectedNode = null;

		private System.Windows.Forms.TreeView treeView1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Point MouseCoords
		{
			get
			{
				Point point = treeView1.PointToScreen(new Point(_mouseX, _mouseY));

				return PointToClient(point);
			}
		}

		public DesignNode SelectedNode
		{
			get{ return _selectedNode; }
		}

		public DesignTreeView()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			HouseDesignData.OnNewDesignSaved += new HouseDesignData.SaveNewDesignEvent(OnNewDesign);
		}

		public TreeNode GetNodeAt(Point point)
		{
			return treeView1.GetNodeAt(point.X, point.Y);
		}

		public TreeNode GetNodeAt(int x, int y)
		{
			return treeView1.GetNodeAt(x, y);
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageIndex = -1;
			this.treeView1.LabelEdit = true;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(160, 160);
			this.treeView1.TabIndex = 0;
			this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
			this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
			this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
			this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
			// 
			// DesignTreeView
			// 
			this.Controls.Add(this.treeView1);
			this.Name = "DesignTreeView";
			this.Size = new System.Drawing.Size(160, 160);
			this.ResumeLayout(false);

		}
		#endregion

		public void Populate(ArrayList designs)
		{
			Hashtable categories = new Hashtable(0, new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
			treeView1.BeginUpdate();
			
			// clear nodes
			treeView1.Nodes.Clear();

			for(int i=0; i < designs.Count; ++i)
			{
				DesignData design = (DesignData)designs[i];
				CategoryNode category = null;

				if(categories.ContainsKey(design.Category))
				{
					category = (CategoryNode)categories[design.Category];
				}
				else
				{
					category = new CategoryNode(design.Category);
					categories.Add(category.Text, category);
					treeView1.Nodes.Add(category);
				}

				category.AddDesign(design);
			}

			treeView1.EndUpdate();
			categories.Clear();
		}

		private void OnNewDesign(DesignData design)
		{
			bool match = false;
			treeView1.BeginUpdate();

			foreach(CategoryNode node in treeView1.Nodes)
			{
				if(node.Text.ToLower() == design.Category.ToLower())
				{
					node.AddDesign(design);
					match = true;
					break;
				}
			}

			if(!match)
			{
				CategoryNode node = new CategoryNode(design.Category);
				node.AddDesign(design);
				treeView1.Nodes.Add(node);
			}

			treeView1.EndUpdate();
		}

		private void treeView1_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node is DesignNode)
			{
				if(_selectedNode != null)
					_selectedNode.ForeColor = Color.Black;

				_selectedNode = (DesignNode)e.Node;
				e.Node.ForeColor = Color.Blue;
			}
			else
			{
				_selectedNode = null;
			}

			if(OnSelected != null)
				OnSelected(_selectedNode);
		}

		private void treeView1_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			if(e.Label != null)
			{
				e.Node.Text = e.Label;
			
				if(e.Node is CategoryNode)
					(e.Node as CategoryNode).Update();
				else if(e.Node is SubsectionNode)
					(e.Node as SubsectionNode).Update();
				else if(e.Node is DesignNode)
					(e.Node as DesignNode).Update();
			}
		}

		private void treeView1_DoubleClick(object sender, System.EventArgs e)
		{
			TreeNode node = treeView1.GetNodeAt(_mouseX, _mouseY);

			if(node != null)
			{
				if(node is DesignNode && OnDoubleClickDesign != null)
				{
					OnDoubleClickDesign((DesignNode)node);
				}
			}
		}

		private void treeView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			_mouseX = e.X;
			_mouseY = e.Y;
		}

		private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				TreeNode node = treeView1.GetNodeAt(_mouseX, _mouseY);

				if(node != null && OnRightClickNode != null)
					OnRightClickNode(node);
			}
		}

	}

	#region Node class definitions

	public class CategoryNode : TreeNode 
	{
		public CategoryNode(string name) : base(name) { }

		public void RemoveNode(int index)
		{
			this.Nodes.RemoveAt(index);

			if(this.Nodes.Count == 0)
				Delete();
		}

		public void AddDesign(DesignData design)
		{
			int index = FindSubsection(design.Subsection.ToLower());

			SubsectionNode subsection = null;

			if(index != -1)
			{
				subsection = (SubsectionNode)this.Nodes[index];
			}
			else
			{
				subsection = new SubsectionNode(design.Subsection);
				this.Nodes.Add(subsection);
			}

			subsection.Nodes.Add(new DesignNode(design));
		}

		public void Delete()
		{
			this.Remove();
		}

		private int FindSubsection(string subsection)
		{
			for(int i=0; i < this.Nodes.Count; ++i)
			{
				SubsectionNode node = (SubsectionNode)this.Nodes[i];

				if(node.Text.ToLower() == subsection)
					return i;
			}

			return -1;
		}

		public void Update()
		{
			foreach(SubsectionNode node in this.Nodes)
				node.Update();
		}
	}

	public class SubsectionNode : TreeNode
	{
		public SubsectionNode(string name) : base(name) { }

		public void Delete()
		{
			(this.Parent as CategoryNode).RemoveNode(this.Index);
		}

		public void RemoveNode(int index)
		{
			this.Nodes.RemoveAt(index);

			if(this.Nodes.Count == 0)
			{
				Delete();
			}
			else
			{
				this.TreeView.SelectedNode = this.Nodes[0];
			}
		}

		public void Update()
		{
			foreach(DesignNode node in this.Nodes)
				node.Update();
		}
	}

	public class DesignNode : TreeNode
	{
		private DesignData _design;

		public DesignNode(DesignData design)
		{
			this.Text = design.Name;
			_design = design;

			_design.OnSaved += new DesignData.SavedEvent(OnSaved);
		}

		public DesignData Design
		{
			get{ return _design; }
		}

		public void Delete()
		{
			HouseDesignData.DeleteDesign(_design);
			(this.Parent as SubsectionNode).RemoveNode(this.Index);
		}

		private void OnSaved()
		{
			string oldCategory = this.Parent.Parent.Text.ToLower();
			string oldSubsection = this.Parent.Text.ToLower();

			string newCategory = _design.Category.ToLower();
			string newSubsection = _design.Subsection.ToLower();

			if(oldCategory == newCategory)
			{
				if(oldSubsection == newSubsection)
				{
					this.Text = _design.Name;
				}
				else
				{
					CategoryNode category = (CategoryNode)this.Parent.Parent;
					(this.Parent as SubsectionNode).RemoveNode(this.Index);
					category.AddDesign(_design);
				}
			}
			else
			{
				int index = FindCategoryNode(_design.Category.ToLower());

				CategoryNode category = null;

				if(index != -1)
				{
					category = (CategoryNode)this.TreeView.Nodes[index];
				}
				else
				{
					category = new CategoryNode(_design.Category);
					this.TreeView.Nodes.Add(category);
				}

				category.AddDesign(_design);
				(this.Parent as SubsectionNode).RemoveNode(this.Index);
			}
		}	

		private int FindCategoryNode(string category)
		{
			for(int i=0; i < this.TreeView.Nodes.Count; ++i)
			{
				if(this.TreeView.Nodes[i].Text.ToLower() == category)
					return i;
			}

			return -1;
		}

		public void Update()
		{
			_design.Category = this.Parent.Parent.Text;
			_design.Subsection = this.Parent.Text;
			_design.Name = this.Text;
			_design.Save();
		}

	}

	#endregion
}
