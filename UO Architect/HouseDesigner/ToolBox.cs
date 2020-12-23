using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace UOArchitect
{
	public class ToolBox : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox picRoot;
		private System.ComponentModel.IContainer components;

		private TileSet m_Root = TileSet.Toolbox;//new RootSet();
		private System.Windows.Forms.ToolTip toolTip;
		private PictureViewer.Viewer picTileSet;

		private HouseDesigner m_Designer;

		public HouseDesigner Designer{ get{ return m_Designer; } set{ m_Designer = value; } }

		public ToolBox()
		{
			InitializeComponent();

			SetStyle( ControlStyles.FixedHeight | ControlStyles.FixedWidth, true );

			picRoot.Image = new Bitmap( "Internal/Graphics/tb_back.png" );
			picTileSet.Image = new Bitmap( "Internal/Graphics/tb_back_tileset.png" );

			for ( int i = 0; i < m_Root.Entries.Count; ++i )
			{
				PictureBox box = new PictureBox();

				box.BackColor = Color.Transparent;
				box.Tag = m_Root.Entries[i];
				box.Image = ((TileSet)m_Root.Entries[i]).Image;
				box.SetBounds( 2 + (i % 3) * 31, 2 + (i / 3) * 31, 30, 30 );
				box.MouseEnter += new EventHandler(box_MouseEnter);
				box.MouseLeave += new EventHandler(box_MouseLeave);
				box.Click += new EventHandler(box_Click);

				toolTip.SetToolTip( box,((TileSet)m_Root.Entries[i]).Name );

				picRoot.Controls.Add( box );
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.picRoot = new System.Windows.Forms.PictureBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.picTileSet = new PictureViewer.Viewer();
			this.SuspendLayout();
			// 
			// picRoot
			// 
			this.picRoot.Location = new System.Drawing.Point(8, 8);
			this.picRoot.Name = "picRoot";
			this.picRoot.Size = new System.Drawing.Size(96, 96);
			this.picRoot.TabIndex = 0;
			this.picRoot.TabStop = false;
			// 
			// picTileSet
			// 
			this.picTileSet.AutoScroll = true;
			this.picTileSet.BackColor = System.Drawing.Color.Black;
			this.picTileSet.Image = null;
			this.picTileSet.ImageSizeMode = PictureViewer.SizeMode.Scrollable;
			this.picTileSet.Location = new System.Drawing.Point(112, 8);
			this.picTileSet.Name = "picTileSet";
			this.picTileSet.Size = new System.Drawing.Size(480, 144);
			this.picTileSet.TabIndex = 1;
			// 
			// ToolBox
			// 
			this.Controls.Add(this.picTileSet);
			this.Controls.Add(this.picRoot);
			this.Name = "ToolBox";
			this.Size = new System.Drawing.Size(600, 160);
			this.ResumeLayout(false);

		}
		#endregion

		private void box_MouseEnter(object sender, EventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			TileSet tileSet = (TileSet)box.Tag;

			box.Image = tileSet.SelectedImage;
		}

		private void box_MouseLeave(object sender, EventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			TileSet tileSet = (TileSet)box.Tag;

			box.Image = tileSet.Image;
		}

		private void box_Click(object sender, EventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			TileSet tileSet = (TileSet)box.Tag;

			if ( tileSet.Entries.Count > 0 && tileSet.Entries[0] is TileSetEntry && ((TileSetEntry)tileSet.Entries[0]).Destroy )
				m_Designer.TileCursor = (TileSetEntry)tileSet.Entries[0];
			else
				SetTileSet( tileSet, true );
		}

		public void SetTileSet( TileSet tileSet, bool palette )
		{
			picTileSet.Controls.Clear();

			if ( tileSet != null )
			{
				int x = 10;

				for ( int i = 0; i < tileSet.Entries.Count; ++i )
				{
					PictureBox tileEntry = new PictureBox();

					Bitmap img = tileSet.Entries[i] is TileSet ?
						((TileSet)tileSet.Entries[i]).Image :
						((TileSetEntry)tileSet.Entries[i]).Image;

					tileEntry.BackColor = Color.Transparent;
					tileEntry.Image = img;

					if ( palette )
						tileEntry.SetBounds( 10+(i%8)*54, 10+(i/8)*74, 44, tileSet.Entries.Count > 8 ? 64 : img.Height );//img.Width, img.Height );
					else
						tileEntry.SetBounds( x, 10, img.Width, img.Height );

					tileEntry.Tag = tileSet.Entries[i];

					if ( tileSet.Entries[i] is TileSet )
						tileEntry.Click += new EventHandler(tileSet_Click);
					else
						tileEntry.Click += new EventHandler(tileEntry_Click);

					if ( tileSet.Entries[i] is TileSet )
						toolTip.SetToolTip( tileEntry, ((TileSet)tileSet.Entries[i]).Name );

					picTileSet.Controls.Add( tileEntry );

					x += img.Width;
					x += 10;
				}
			}
		}

		private void tileSet_Click(object sender, EventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			TileSet tileSet = (TileSet)box.Tag;

			if ( tileSet.Entries.Count > 0 && tileSet.Entries[0] is TileSetEntry && ((TileSetEntry)tileSet.Entries[0]).Destroy )
				m_Designer.TileCursor = (TileSetEntry)tileSet.Entries[0];
			else
				SetTileSet( tileSet, false );
		}

		private void tileEntry_Click(object sender, EventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			TileSetEntry tileEntry = (TileSetEntry)box.Tag;

			m_Designer.TileCursor = tileEntry;
		}
	}
}