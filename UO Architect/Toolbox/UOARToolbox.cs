using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using UOArchitectInterface;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for ToolBoxMockup.
	/// </summary>
	public class UOARToolBox : System.Windows.Forms.Form
	{
		#region Auto Code

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabMove;
		private System.Windows.Forms.TabPage tabExtract;
		private System.Windows.Forms.TabPage tabDesigns;
		private UOArchitect.DesignsPanel designsPanel1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuConnect;
		private System.Windows.Forms.MenuItem mnuNewDesign;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem mnuExport;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem ImportUOARDesign;
		private System.Windows.Forms.MenuItem mnuImportMultiText;
		private System.Windows.Forms.MenuItem mnuExportUOARDesign;
		private System.Windows.Forms.MenuItem mnuExportMultiText;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem10;
		private UOArchitect.ExtractPanel extractPanel1;
		private UOArchitect.Toolbox.TabPanels.MovePanel movePanel1;
		private System.Windows.Forms.TabPage tabOptions;
		private UOArchitect.Toolbox.TabPanels.OptionsTab optionsTab1;
		private System.Windows.Forms.TabPage tabAbout;
		private UOArchitect.Toolbox.AboutTab aboutTab1;
		private System.Windows.Forms.MenuItem mnuImportWFItems;
		private System.Windows.Forms.MenuItem mnuExportMultiMul;
		private System.Windows.Forms.MenuItem mnuImportMultiCache;
		private System.Windows.Forms.MenuItem mnuOrbsydia;
		private System.Windows.Forms.MenuItem mnuUOARHome;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuUOARForum;
		private System.Windows.Forms.MenuItem mnuUOARBuildings;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UOARToolBox()
		{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UOARToolBox));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabDesigns = new System.Windows.Forms.TabPage();
			this.designsPanel1 = new UOArchitect.DesignsPanel();
			this.tabMove = new System.Windows.Forms.TabPage();
			this.movePanel1 = new UOArchitect.Toolbox.TabPanels.MovePanel();
			this.tabExtract = new System.Windows.Forms.TabPage();
			this.extractPanel1 = new UOArchitect.ExtractPanel();
			this.tabOptions = new System.Windows.Forms.TabPage();
			this.optionsTab1 = new UOArchitect.Toolbox.TabPanels.OptionsTab();
			this.tabAbout = new System.Windows.Forms.TabPage();
			this.aboutTab1 = new UOArchitect.Toolbox.AboutTab();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuNewDesign = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.ImportUOARDesign = new System.Windows.Forms.MenuItem();
			this.mnuImportMultiText = new System.Windows.Forms.MenuItem();
			this.mnuImportWFItems = new System.Windows.Forms.MenuItem();
			this.mnuImportMultiCache = new System.Windows.Forms.MenuItem();
			this.mnuExport = new System.Windows.Forms.MenuItem();
			this.mnuExportUOARDesign = new System.Windows.Forms.MenuItem();
			this.mnuExportMultiText = new System.Windows.Forms.MenuItem();
			this.mnuExportMultiMul = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuConnect = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.mnuOrbsydia = new System.Windows.Forms.MenuItem();
			this.mnuUOARHome = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuUOARForum = new System.Windows.Forms.MenuItem();
			this.mnuUOARBuildings = new System.Windows.Forms.MenuItem();
			this.tabControl1.SuspendLayout();
			this.tabDesigns.SuspendLayout();
			this.tabMove.SuspendLayout();
			this.tabExtract.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.tabAbout.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabControl1.Controls.Add(this.tabDesigns);
			this.tabControl1.Controls.Add(this.tabMove);
			this.tabControl1.Controls.Add(this.tabExtract);
			this.tabControl1.Controls.Add(this.tabOptions);
			this.tabControl1.Controls.Add(this.tabAbout);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(218, 363);
			this.tabControl1.TabIndex = 0;
			// 
			// tabDesigns
			// 
			this.tabDesigns.Controls.Add(this.designsPanel1);
			this.tabDesigns.Location = new System.Drawing.Point(23, 4);
			this.tabDesigns.Name = "tabDesigns";
			this.tabDesigns.Size = new System.Drawing.Size(191, 355);
			this.tabDesigns.TabIndex = 3;
			this.tabDesigns.Text = "Database";
			// 
			// designsPanel1
			// 
			this.designsPanel1.Location = new System.Drawing.Point(0, 0);
			this.designsPanel1.Name = "designsPanel1";
			this.designsPanel1.Size = new System.Drawing.Size(192, 360);
			this.designsPanel1.TabIndex = 0;
			// 
			// tabMove
			// 
			this.tabMove.Controls.Add(this.movePanel1);
			this.tabMove.Location = new System.Drawing.Point(23, 4);
			this.tabMove.Name = "tabMove";
			this.tabMove.Size = new System.Drawing.Size(191, 335);
			this.tabMove.TabIndex = 0;
			this.tabMove.Text = "Move";
			// 
			// movePanel1
			// 
			this.movePanel1.Location = new System.Drawing.Point(0, 0);
			this.movePanel1.Name = "movePanel1";
			this.movePanel1.Size = new System.Drawing.Size(192, 360);
			this.movePanel1.TabIndex = 0;
			// 
			// tabExtract
			// 
			this.tabExtract.Controls.Add(this.extractPanel1);
			this.tabExtract.Location = new System.Drawing.Point(23, 4);
			this.tabExtract.Name = "tabExtract";
			this.tabExtract.Size = new System.Drawing.Size(191, 335);
			this.tabExtract.TabIndex = 1;
			this.tabExtract.Text = "Extract";
			// 
			// extractPanel1
			// 
			this.extractPanel1.Location = new System.Drawing.Point(0, 0);
			this.extractPanel1.Name = "extractPanel1";
			this.extractPanel1.Size = new System.Drawing.Size(192, 360);
			this.extractPanel1.TabIndex = 0;
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.optionsTab1);
			this.tabOptions.Location = new System.Drawing.Point(23, 4);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.Size = new System.Drawing.Size(191, 335);
			this.tabOptions.TabIndex = 4;
			this.tabOptions.Text = "Options";
			// 
			// optionsTab1
			// 
			this.optionsTab1.Location = new System.Drawing.Point(0, 0);
			this.optionsTab1.Name = "optionsTab1";
			this.optionsTab1.Size = new System.Drawing.Size(192, 360);
			this.optionsTab1.TabIndex = 0;
			// 
			// tabAbout
			// 
			this.tabAbout.Controls.Add(this.aboutTab1);
			this.tabAbout.Location = new System.Drawing.Point(23, 4);
			this.tabAbout.Name = "tabAbout";
			this.tabAbout.Size = new System.Drawing.Size(191, 335);
			this.tabAbout.TabIndex = 5;
			this.tabAbout.Text = "About";
			// 
			// aboutTab1
			// 
			this.aboutTab1.Location = new System.Drawing.Point(0, 0);
			this.aboutTab1.Name = "aboutTab1";
			this.aboutTab1.Size = new System.Drawing.Size(192, 360);
			this.aboutTab1.TabIndex = 0;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.mnuConnect,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuNewDesign,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.mnuExport,
																					  this.menuItem9,
																					  this.mnuExit});
			this.menuItem1.Text = "&File";
			// 
			// mnuNewDesign
			// 
			this.mnuNewDesign.Index = 0;
			this.mnuNewDesign.Text = "&New Design";
			this.mnuNewDesign.Click += new System.EventHandler(this.mnuNewDesign_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ImportUOARDesign,
																					  this.mnuImportMultiText,
																					  this.mnuImportWFItems,
																					  this.mnuImportMultiCache});
			this.menuItem7.Text = "&Import";
			// 
			// ImportUOARDesign
			// 
			this.ImportUOARDesign.Index = 0;
			this.ImportUOARDesign.Text = "UO Architect Design (.uoa)";
			this.ImportUOARDesign.Click += new System.EventHandler(this.ImportUOARDesign_Click);
			// 
			// mnuImportMultiText
			// 
			this.mnuImportMultiText.Index = 1;
			this.mnuImportMultiText.Text = "Multi Text (.txt)";
			this.mnuImportMultiText.Click += new System.EventHandler(this.mnuImportMultiText_Click);
			// 
			// mnuImportWFItems
			// 
			this.mnuImportWFItems.Index = 2;
			this.mnuImportWFItems.Text = "World Forge Items (.xml)";
			this.mnuImportWFItems.Click += new System.EventHandler(this.mnuImportWFItems_Click);
			// 
			// mnuImportMultiCache
			// 
			this.mnuImportMultiCache.Index = 3;
			this.mnuImportMultiCache.Text = "UO Client MultiCache (.dat)";
			this.mnuImportMultiCache.Click += new System.EventHandler(this.mnuImportMultiCache_Click);
			// 
			// mnuExport
			// 
			this.mnuExport.Index = 3;
			this.mnuExport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuExportUOARDesign,
																					  this.mnuExportMultiText,
																					  this.mnuExportMultiMul});
			this.mnuExport.Text = "&Export";
			// 
			// mnuExportUOARDesign
			// 
			this.mnuExportUOARDesign.Index = 0;
			this.mnuExportUOARDesign.Text = "UO Architect Design (.uoa)";
			this.mnuExportUOARDesign.Click += new System.EventHandler(this.mnuExportUOARDesign_Click);
			// 
			// mnuExportMultiText
			// 
			this.mnuExportMultiText.Index = 1;
			this.mnuExportMultiText.Text = "Multi Text (.txt)";
			this.mnuExportMultiText.Click += new System.EventHandler(this.mnuExportMultiText_Click);
			// 
			// mnuExportMultiMul
			// 
			this.mnuExportMultiMul.Index = 2;
			this.mnuExportMultiMul.Text = "Multi Data (.mul)";
			this.mnuExportMultiMul.Click += new System.EventHandler(this.mnuExportMultiMul_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 4;
			this.menuItem9.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 5;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuConnect
			// 
			this.mnuConnect.Index = 1;
			this.mnuConnect.Text = "&Connect";
			this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.mnuOrbsydia,
																					  this.mnuUOARHome,
																					  this.menuItem3,
																					  this.mnuUOARForum,
																					  this.mnuUOARBuildings});
			this.menuItem2.Text = "&Community";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "-";
			// 
			// mnuOrbsydia
			// 
			this.mnuOrbsydia.Index = 1;
			this.mnuOrbsydia.Text = "&Orbsydia.com";
			this.mnuOrbsydia.Click += new System.EventHandler(this.mnuOrbsydia_Click);
			// 
			// mnuUOARHome
			// 
			this.mnuUOARHome.Index = 2;
			this.mnuUOARHome.Text = "UOAR Home";
			this.mnuUOARHome.Click += new System.EventHandler(this.mnuUOARHome_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// mnuUOARForum
			// 
			this.mnuUOARForum.Index = 4;
			this.mnuUOARForum.Text = "UOAR Forum";
			this.mnuUOARForum.Click += new System.EventHandler(this.mnuUOARForum_Click);
			// 
			// mnuUOARBuildings
			// 
			this.mnuUOARBuildings.Index = 5;
			this.mnuUOARBuildings.Text = "UOAR Buildings";
			this.mnuUOARBuildings.Click += new System.EventHandler(this.mnuUOARBuildings_Click);
			// 
			// UOARToolBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 363);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "UOARToolBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UO Architect 2.6";
			this.TopMost = true;
			this.tabControl1.ResumeLayout(false);
			this.tabDesigns.ResumeLayout(false);
			this.tabMove.ResumeLayout(false);
			this.tabExtract.ResumeLayout(false);
			this.tabOptions.ResumeLayout(false);
			this.tabAbout.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			designsPanel1.OnDesignSelected += new DesignsPanel.DesignSelected(OnDesignSelected);
			designsPanel1.OnDesignUnselected += new DesignsPanel.DesignUnselected(OnDesignUnselected);
			
			Config.IntializeSettings();
			OnDesignUnselected();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing (e);

			Config.SaveSettings();
		}

		[STAThread]
		public static void Main( string[] args )
		{
			Application.Run( new UOARToolBox() );
		}

		private void OnDesignSelected()
		{
			mnuExportUOARDesign.Enabled = true;
			mnuExportMultiText.Enabled = true;
			mnuImportWFItems.Enabled = true;
		}

		private void OnDesignUnselected()
		{
			mnuExportUOARDesign.Enabled = false;
			mnuExportMultiText.Enabled = false;
			mnuImportWFItems.Enabled = false;
		}

		private void mnuConnect_Click(object sender, System.EventArgs e)
		{
			if(!Connection.IsConnected)
			{
				LoginDialog dlg = new LoginDialog();
				dlg.ShowDialog(this);

				if(dlg.DialogResult == DialogResult.OK)
				{
					Config.ServerIP = dlg.ServerIP;
					Config.Port = dlg.Port;
					Config.UserName = dlg.UserName;
					Config.Password = dlg.Password;
					Config.SaveSettings();

					dlg.Dispose();

					if(Connection.ConnectToServer())
						mnuConnect.Text = "&Disconnect";
				}
			}
			else
			{
				Connection.Disconnect();
				mnuConnect.Text = "&Connect";
			}
		}

		private void ImportUOARDesign_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			UOARBatchDataAdapter adapter = new UOARBatchDataAdapter();

			DateTime start = DateTime.Now;

			ArrayList designs = adapter.ImportDesigns();
			HouseDesignData.BatchSaveNewDesigns(designs);

			Cursor.Current = Cursors.Default;

			if(designs.Count > 0)
			{
				DateTime end = DateTime.Now;
				
				string msg = string.Format("Successfully imported {0} designs for a total of {1:#,##0} items.", designs.Count, adapter.Count);

				MessageBox.Show(msg);
			}
		}

		private void mnuImportMultiText_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			MultiTextDataAdapter adapter = new MultiTextDataAdapter();
			DesignData design = adapter.ImportDesign();
			
			if(design != null)
			{
				design.Save();
			}

			Cursor.Current = Cursors.Default;
		}

		private void mnuExportUOARDesign_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(designsPanel1.SelectedDesign != null)
			{
				UOARDataAdapter adapter = new UOARDataAdapter();
				adapter.Export(designsPanel1.SelectedDesign);
				designsPanel1.SelectedDesign.Unload();
			}
			else
			{
				MessageBox.Show("Export failed, no design selected");
			}

			Cursor.Current = Cursors.Default;
		}

		private void mnuExportMultiText_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(designsPanel1.SelectedDesign != null)
			{
				MultiTextDataAdapter adapter = new MultiTextDataAdapter();
				adapter.Export(designsPanel1.SelectedDesign);
				designsPanel1.SelectedDesign.Unload();
			}
			else
			{
				MessageBox.Show("Export failed, no design selected");
			}

			Cursor.Current = Cursors.Default;
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void mnuNewDesign_Click(object sender, System.EventArgs e)
		{
			new NewDesigner().ShowDialog(this);
		}

		private void mnuImportWFItems_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			WFItemsAdapter adapter = new WFItemsAdapter();
			DesignData design = adapter.ImportDesign();
			
			if(design != null)
			{
				design.Save();
			}

			Cursor.Current = Cursors.Default;
		}

		private void mnuExportMultiMul_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if(designsPanel1.SelectedDesign != null)
			{
				WFItemsAdapter adapter = new WFItemsAdapter();
				adapter.Export(designsPanel1.SelectedDesign);
				designsPanel1.SelectedDesign.Unload();
			}
			else
			{
				MessageBox.Show("Export failed, no design selected");
			}

			Cursor.Current = Cursors.Default;
		}

		private void mnuImportMultiCache_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			MultiCacheDataImporter adapter = new MultiCacheDataImporter();

			ArrayList designs = adapter.ImportDesigns();
			HouseDesignData.BatchSaveNewDesigns(designs);

			Cursor.Current = Cursors.Default;

			if(designs.Count > 0)
			{	
				string msg = string.Format("Successfully imported {0} designs.", designs.Count);

				MessageBox.Show(msg);
			}
		}

		private void mnuOrbsydia_Click(object sender, System.EventArgs e)
		{
			Utility.OpenWebLink(@"http://www.orbsydia.com/index.php");
		}

		private void mnuUOARHome_Click(object sender, System.EventArgs e)
		{
			Utility.OpenWebLink(@"http://www.orbsydia.com/tools/uoar/index.php");
		}

		private void mnuUOARForum_Click(object sender, System.EventArgs e)
		{
			Utility.OpenWebLink(@"http://www.orbsydia.com/forum/forumdisplay.php?f=24");
		}

		private void mnuUOARBuildings_Click(object sender, System.EventArgs e)
		{
			Utility.OpenWebLink(@"http://www.orbsydia.com/forum/forumdisplay.php?f=85");
		}
	}
}
