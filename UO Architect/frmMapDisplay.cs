using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ultima;

namespace UOArchitect
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMapDisplay : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		int m_MapWidth = Map.Trammel.Tiles.Width;
		int m_MapHeight = Map.Trammel.Tiles.Height;
		int m_CameraX = 1625;
		int m_CameraY = 1035;

		public frmMapDisplay()
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
				if (components != null) 
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 566);
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		protected override void OnPaint( PaintEventArgs e )
		{
			Graphics g = e.Graphics;

			g.Clear( SystemColors.ControlDark );

			
			DrawBlock(g, m_CameraX, m_CameraY);

			//					Bitmap image = Art.GetLand(Map.Trammel.Tiles.GetLandTile(x + m_CameraX, y + m_CameraY).ID);
			//					g.DrawImage( image, px - (image.Width / 2), py - image.Height );

															
		}

		private void DrawBlock(Graphics g, int mapx, int mapy)
		{
			int viewHeight = (ClientSize.Height / 22) + 22;
			int viewWidth = (ClientSize.Width / 22) + 22;

			int startX = mapx - (viewWidth / 2);
			int startY = mapy - (viewHeight / 2);

			int screenX = 0;
			int screenY = -22;

			int currentX = startX;
			int currentY = startY;

			for(int y = 0; y < viewHeight; ++y)
			{
				if(y % 2 != 0)
				{
					screenX = -22;
					currentY++;
				}
				else
				{
					currentX++;
					screenX = 0;
				}

				for(int x = 0; x < viewWidth; ++x)
				{
					Bitmap image = Art.GetLand(Map.Trammel.Tiles.GetLandTile(currentX + x, currentY - x).ID);
					g.DrawImage( image, screenX, screenY);

					screenX += 44;
				}

				screenY += 22;
			}
		}
	}
}
