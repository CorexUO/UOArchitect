using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Ultima;

namespace UOArchitect
{
	public class HouseDesigner : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

		private HouseDesign m_Design;

		private int m_Level;
		private int m_X, m_Y, m_Z;
		private int m_W=1,m_H=1;
		private System.Windows.Forms.MainMenu mmMain;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miDesign;
		private System.Windows.Forms.MenuItem miLevel;
		private System.Windows.Forms.MenuItem miFirst;
		private System.Windows.Forms.MenuItem miSecond;
		private System.Windows.Forms.MenuItem miThird;
		private System.Windows.Forms.MenuItem miRoof;
		private System.Windows.Forms.SaveFileDialog saveDialog;
		private System.Windows.Forms.MenuItem miVirtFloor;
		private TileSetEntry m_Cursor;
		private System.Windows.Forms.MenuItem miSeperator;
		private System.Windows.Forms.MenuItem miClear;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miBuild;
		private System.Windows.Forms.MenuItem miBuildQuick;

		private bool m_DrawVirtualFloor = true;

		private bool m_Shifting;
		private int m_ShiftX, m_ShiftY;
		private int m_ShiftCX, m_ShiftCY;
		private int m_CameraX, m_CameraY;
		private System.Windows.Forms.MenuItem miFoundation;
		private System.Windows.Forms.MenuItem miRenderImage;
		private System.Windows.Forms.MenuItem miRenderPng;
		private System.Windows.Forms.MenuItem miRenderJpeg;
		private System.Windows.Forms.MenuItem miRenderGif;
		private System.Windows.Forms.MenuItem miRenderBitmap;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuSaveAs;

		private bool m_MouseDown = false;
		private Point m_MousePos;
		private UOArchitect.ToolBox toolBox2;
		private System.Windows.Forms.MenuItem miFifth;
		private System.Windows.Forms.MenuItem miSixth;

		private int m_buildZ;
		private bool m_ShiftKeyDown = false;

		private Bitmap m_ShiftImage = new Bitmap( "Internal/Graphics/scroll.png" );

		public TileSetEntry TileCursor
		{
			get
			{
				return m_Cursor;
			}
			set
			{
				if ( m_Cursor != value )
				{
					int xOffset = (ClientSize.Width / 2);
					int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

					xOffset += m_CameraX;
					yOffset += m_CameraY;

					if ( m_Cursor==null||value==null||m_Cursor.Image.Width!=value.Image.Width||m_Cursor.Image.Height!=value.Image.Height)
					{
						if ( m_Cursor != null )
						{
							for ( int x = m_X; x < m_X + m_W; ++x )
								for ( int y = m_Y; y < m_Y + m_H; ++y )
									Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
						}
					}

					m_Cursor = value;

					if ( m_Cursor != null )
					{
						for ( int x = m_X; x < m_X + m_W; ++x )
							for ( int y = m_Y; y < m_Y + m_H; ++y )
								Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
					}
				}
			}
		}

		public void Translate( ref int x, ref int y, out int z )
		{
			int xOffset = (ClientSize.Width / 2);
			int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

			xOffset += m_CameraX;
			yOffset += m_CameraY;

			x-=xOffset;
			y-=yOffset;

			y += HouseDesign.LevelZ[m_Level]*4;
			y += 44;

			int vx = (x+y);
			int vy = (y-x);

			if ( vx<0)
				vx-=44;
			if (vy<0)
				vy-=44;

			vx/=44;
			vy/=44;

			x = vx;
			y = vy;
			z = HouseDesign.LevelZ[m_Level];

			if ( x >= 0 && x < m_Design.Width && y >= 0 && y < m_Design.Height )
			{
				ArrayList list = m_Design.Components[x][y][m_Level];

				for ( int i = 0; i < list.Count; ++i )
				{
					HouseComponent hc = (HouseComponent)list[i];
					int top = hc.Z + hc.Height;

					if ( top > z )
						z = top;
				}

				if ( m_Cursor != null && !m_Cursor.Destroy && z >= HouseDesign.LevelZ[m_Level]+20 )
					z -= 20;
			}
		}

		public void SetCursorXY( int x, int y, int z, bool ignoreSame )
		{
			if ( !ignoreSame && m_X == x && m_Y == y && m_Z == z )
				return;
			else if ( m_Cursor == null )
				return;

			int xOffset = (ClientSize.Width / 2);
			int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

			xOffset += m_CameraX;
			yOffset += m_CameraY;

			for ( int vx = m_X; vx < m_X + m_W; ++vx )
				for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
					Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((vx + vy) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );

			m_X = x;
			m_Y = y;
			m_Z = z;

			for ( int vx = m_X; vx < m_X + m_W; ++vx )
				for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
					Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((vx + vy) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
		}

		public void SetCursorMouseXY( int x, int y, bool ignoreSame )
		{
			int z;

			Translate( ref x, ref y, out z );

			SetCursorXY( x, y, z, ignoreSame );
		}

		public void FixPoints( ref int xStart, ref int yStart, ref int xEnd, ref int yEnd )
		{
			int xLow = xStart, yLow = yStart;
			int xHigh = xEnd, yHigh = yEnd;

			if ( xEnd < xLow )
			{
				xLow = xEnd;
				xHigh = xStart;
			}

			if ( yEnd < yLow )
			{
				yLow = yEnd;
				yHigh = yStart;
			}

			xStart = xLow;
			xEnd = xHigh;

			yStart = yLow;
			yEnd = yHigh;
		}

		private bool m_Resizing;
		private int m_ResizeX, m_ResizeY;

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ( m_Shifting )
			{
				m_CameraX = e.X - m_ShiftX + m_ShiftCX;
				m_CameraY = e.Y - m_ShiftY + m_ShiftCY;

				Invalidate();
			}
			else if ( m_Resizing )
			{
				int mx = e.X, my = e.Y;
				int tx = mx, ty = my, z;

				Translate( ref tx, ref ty, out z );

				int xStart = m_ResizeX, yStart = m_ResizeY;
				int xEnd = tx, yEnd = ty;

				FixPoints( ref xStart, ref yStart, ref xEnd, ref yEnd );

				int xOffset = (ClientSize.Width / 2);
				int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

				xOffset += m_CameraX;
				yOffset += m_CameraY;

				int oldX = m_X, oldY = m_Y;
				int oldW = m_W, oldH = m_H;

				if ( xStart != oldX || yStart != oldY || (xEnd-xStart+1) != m_W || (yEnd-yStart+1) != m_H )
				{
					m_X = xStart;
					m_Y = yStart;
					m_W = xEnd-xStart+1;
					m_H = yEnd-yStart+1;

					int xLo = xStart, yLo = yStart;
					int xHi = xEnd, yHi = yEnd;

					if ( oldX < xLo )
						xLo = oldX;

					if ( oldY < yLo )
						yLo = oldY;

					if ( (oldX + oldW - 1) > xHi )
						xHi = oldX + oldW - 1;

					if ( (oldY + oldH - 1) > yHi )
						yHi = oldY + oldH - 1;

					if ( m_Cursor != null )
					{
						for ( int x = xLo; x <= xHi; ++x )
						{
							for ( int y = yLo; y <= yHi; ++y )
							{
								bool oldCursor = ( x >= oldX && x < (oldX + oldW) && y >= oldY && y < (oldY + oldH) );
								bool newCursor = ( x >= m_X && x < (m_X + m_W) && y >= m_Y && y < (m_Y + m_H) );

								if ( oldCursor != newCursor )
									Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
							}
						}
					}
				}
			}
			else
			{
				m_Resizing = false;
				m_W=1;
				m_H=1;

				int xOffset = (ClientSize.Width / 2);
				int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

				xOffset += m_CameraX;
				yOffset += m_CameraY;

				if ( m_Cursor != null )
				{
					for ( int vx = m_X; vx < m_X + m_W; ++vx )
						for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
							Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((vx + vy) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
				}

				int x = m_X, y = m_Y;

				SetCursorMouseXY(e.X,e.Y,false);

				if ( e.Button != MouseButtons.None )
				{
					if ( m_Cursor != null && (m_X != x || m_Y != y) )
					{
						if ( m_Cursor.Destroy || e.Button == MouseButtons.Right )
						{
							HouseComponent tc = null;

							for ( int vx = m_X; vx < m_X + m_W; ++vx )
							{
								for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
								{
									if ( vx >= 0 && vx < m_Design.Width && vy >= 0 && vy < m_Design.Height )
									{
										ArrayList list = m_Design.Components[vx][vy][m_Level];
										//int z = HouseDesign.LevelZ[m_Level];
										int z = m_buildZ;

										for ( int i = 0; i < list.Count; ++i )
										{
											HouseComponent hc = (HouseComponent)list[i];
											int top = hc.Z + hc.Height;

											if ( top >= z )
											{
												z = top;
												tc= hc;
											}
										}

										if ( tc != null )
										{
											Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (tc.Image.Width / 2), yOffset + ((vx + vy) * 22) - tc.Image.Height - (tc.Z*4), tc.Image.Width, tc.Image.Height ) );

											list.Remove(tc);
										}
									}
								}
							}

							SetCursorMouseXY(e.X,e.Y,true);
						}
						else
						{
							for ( int vx = m_X; vx < m_X + m_W; ++vx )
							{
								for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
								{
									m_Design.AddComponent( vx, vy, m_Z, m_Level, m_Cursor.GetRandomIndex(), m_Cursor.BaseIndex, m_Cursor.Count );
									Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((vx + vy) * 22) - m_Cursor.Image.Height - (m_Z*4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
								}
							}
						}
					}
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.KeyCode == Keys.ShiftKey)
			{
				m_ShiftKeyDown = true;
			}

			base.OnKeyDown (e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			m_ShiftKeyDown = false;

			base.OnKeyUp (e);
		}


		protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
		{	
			if(m_ShiftKeyDown)
			{
				if(e.Delta > 0)
				{
					if(m_Level + 1 != HouseDesign.Levels)
					{
						ChangeLevel(m_Level + 1);
					}
				}
				else if(e.Delta < 0)
				{
					if(m_Level != 0)
					{
						ChangeLevel(m_Level - 1);
					}
				}
			}
//			else
//			{
//				if ( e.Delta < 0 ) // MouseWheel down
//					LowerBuildZ();
//				else if ( e.Delta > 0 ) // MouseWheel up
//					RaiseBuildZ();
//			}
		}

		private void RaiseBuildZ()
		{
			if(m_buildZ < HouseDesign.LevelZ[m_Level] + 19)
			{
				m_buildZ++;
				Invalidate();
			}
		}

		private void LowerBuildZ()
		{
			if(m_buildZ > HouseDesign.LevelZ[m_Level])
			{
				m_buildZ--;
				Invalidate();
			}
		}


		private void ChangeLevel(int level)
		{
			m_Level = level;
			m_buildZ = HouseDesign.LevelZ[level];

			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ( m_Shifting )
			{
				m_Shifting = false;

				m_CameraX = e.X - m_ShiftX + m_ShiftCX;
				m_CameraY = e.Y - m_ShiftY + m_ShiftCY;

				Invalidate();
			}
			else if ( m_Resizing )
			{
				int mx = e.X, my = e.Y;
				int tx = mx, ty = my, tz;

				Translate( ref tx, ref ty, out tz );

				int xStart = m_ResizeX, yStart = m_ResizeY;
				int xEnd = tx, yEnd = ty;

				FixPoints( ref xStart, ref yStart, ref xEnd, ref yEnd );

				int xOffset = (ClientSize.Width / 2);
				int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

				xOffset += m_CameraX;
				yOffset += m_CameraY;

				if ( m_Cursor != null )
				{
					for ( int x = m_X; x < m_X + m_W; ++x )
						for ( int y = m_Y; y < m_Y + m_H; ++y )
							Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
				}

				m_X = xStart;
				m_Y = yStart;
				m_W = xEnd-xStart+1;
				m_H = yEnd-yStart+1;

				if ( m_Cursor != null )
				{
					for ( int x = m_X; x < m_X + m_W; ++x )
						for ( int y = m_Y; y < m_Y + m_H; ++y )
							Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );

					if ( m_Cursor.Destroy || e.Button == MouseButtons.Right )
					{
						Clipboard.SetDataObject( String.Format( ", new Rectangle2D( {0}, {1}, {2}, {3} )", m_X - m_Design.xc, m_Y - m_Design.yc, m_W, m_H ) );
						HouseComponent tc = null;

						for ( int vx = m_X; vx < m_X + m_W; ++vx )
						{
							for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
							{
								if ( vx >= 0 && vx < m_Design.Width && vy >= 0 && vy < m_Design.Height )
								{
									ArrayList list = m_Design.Components[vx][vy][m_Level];
									//int z = HouseDesign.LevelZ[m_Level];
									int z = m_buildZ;

									for ( int i = 0; i < list.Count; ++i )
									{
										HouseComponent hc = (HouseComponent)list[i];
										int top = hc.Z + hc.Height;

										if ( top >= z )
										{
											z = top;
											tc= hc;
										}
									}

									if ( tc != null )
									{
										Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (tc.Image.Width / 2), yOffset + ((vx + vy) * 22) - tc.Image.Height - (tc.Z*4), tc.Image.Width, tc.Image.Height ) );

										list.Remove(tc);
									}
								}
							}
						}
					}
					else
					{
						Clipboard.SetDataObject( String.Format( ", new Rectangle2D( {0}, {1}, {2}, {3} )", m_X - m_Design.xc, m_Y - m_Design.yc, m_W, m_H ) );
						for ( int vx = m_X; vx < m_X + m_W; ++vx )
						{
							for ( int vy = m_Y; vy < m_Y + m_H; ++vy )
							{
								m_Design.AddComponent( vx, vy, m_Z, m_Level, m_Cursor.GetRandomIndex(), m_Cursor.BaseIndex, m_Cursor.Count );
								Invalidate( new Rectangle( xOffset + ((vx - vy) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((vx + vy) * 22) - m_Cursor.Image.Height - (m_Z*4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
							}
						}
					}
				}

				m_Resizing = false;
				m_W=1;
				m_H=1;

				if ( m_Cursor != null )
				{
					for ( int x = m_X; x < m_X + m_W; ++x )
						for ( int y = m_Y; y < m_Y + m_H; ++y )
							Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
				}
			}
			else
			{
				int xOffset = (ClientSize.Width / 2);
				int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

				xOffset += m_CameraX;
				yOffset += m_CameraY;

				m_Resizing = false;
				m_W=1;
				m_H=1;

				if ( m_Cursor != null )
				{
					for ( int x = m_X; x < m_X + m_W; ++x )
						for ( int y = m_Y; y < m_Y + m_H; ++y )
							Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ( (Control.ModifierKeys & Keys.Shift) != 0 )
			{
				m_Shifting = true;

				m_ShiftX = e.X;
				m_ShiftY = e.Y;
				m_ShiftCX = m_CameraX;
				m_ShiftCY = m_CameraY;

				Invalidate( new Rectangle( m_ShiftX - (m_ShiftImage.Width / 2), m_ShiftY - (m_ShiftImage.Height / 2), m_ShiftImage.Width, m_ShiftImage.Height ) );

				if ( m_Cursor != null )
				{
					int xOffset = (ClientSize.Width / 2);
					int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

					xOffset += m_CameraX;
					yOffset += m_CameraY;

					for ( int x = m_X; x < m_X + m_W; ++x )
						for ( int y = m_Y; y < m_Y + m_H; ++y )
							Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
				}
			}
			else if ( true )//if ( (Control.ModifierKeys & Keys.Shift) != 0 )
			{
				if ( m_Shifting )
				{
					m_Shifting = false;

					Invalidate( new Rectangle( m_ShiftX - (m_ShiftImage.Width / 2), m_ShiftY - (m_ShiftImage.Height / 2), m_ShiftImage.Width, m_ShiftImage.Height ) );
				}

				int mx = e.X, my = e.Y;
				int tx = mx, ty = my, z;

				Translate( ref tx, ref ty, out z );

				m_Resizing = true;
				m_ResizeX = tx;
				m_ResizeY = ty;

				int xStart = m_ResizeX, yStart = m_ResizeY;
				int xEnd = tx, yEnd = ty;

				FixPoints( ref xStart, ref yStart, ref xEnd, ref yEnd );

				int xOffset = (ClientSize.Width / 2);
				int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

				xOffset += m_CameraX;
				yOffset += m_CameraY;

				int oldX = m_X, oldY = m_Y;
				int oldW = m_W, oldH = m_H;

				if ( xStart != oldX || yStart != oldY || (xEnd-xStart+1) != m_W || (yEnd-yStart+1) != m_H )
				{
					m_X = xStart;
					m_Y = yStart;
					m_W = xEnd-xStart+1;
					m_H = yEnd-yStart+1;

					int xLo = xStart, yLo = yStart;
					int xHi = xEnd, yHi = yEnd;

					if ( oldX < xLo )
						xLo = oldX;

					if ( oldY < yLo )
						yLo = oldY;

					if ( (oldX + oldW - 1) > xHi )
						xHi = oldX + oldW - 1;

					if ( (oldY + oldH - 1) > yHi )
						yHi = oldY + oldH - 1;

					if ( m_Cursor != null )
					{
						for ( int x = xLo; x <= xHi; ++x )
						{
							for ( int y = yLo; y <= yHi; ++y )
							{
								bool oldCursor = ( x >= oldX && x < (oldX + oldW) && y >= oldY && y < (oldY + oldH) );
								bool newCursor = ( x >= m_X && x < (m_X + m_W) && y >= m_Y && y < (m_Y + m_H) );

								if ( oldCursor != newCursor )
									Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
							}
						}
					}
				}
			}
#if false
			else if ( e.Button != MouseButtons.None )
			{
				m_Resizing = false;
				m_W=1;
				m_H=1;

				m_Shifting=false;

				int xOffset = (ClientSize.Width / 2);
				int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

				xOffset += m_CameraX;
				yOffset += m_CameraY;

				if ( m_Cursor != null )
				{
					for ( int x = m_X; x < m_X + m_W; ++x )
						for ( int y = m_Y; y < m_Y + m_H; ++y )
							Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z * 4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
				}
				SetCursorMouseXY( e.X,e.Y,true );

				if ( m_Cursor != null )
				{
					if ( m_Cursor == DestroyEntry.Instance || e.Button == MouseButtons.Right )
					{
						HouseComponent tc = null;

						for ( int x = m_X; x < m_X + m_W; ++x )
						{
							for ( int y = m_Y; y < m_Y + m_H; ++y )
							{
								if ( x >= 0 && x < m_Design.Width && y >= 0 && y < m_Design.Height )
								{
									ArrayList list = m_Design.Components[x][y][m_Level];
									int z = HouseDesign.LevelZ[m_Level];

									for ( int i = 0; i < list.Count; ++i )
									{
										HouseComponent hc = (HouseComponent)list[i];
										int top = hc.Z + hc.Height;

										if ( top >= z )
										{
											z = top;
											tc= hc;
										}
									}

									if ( tc != null )
									{
										Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (tc.Image.Width / 2), yOffset + ((x + y) * 22) - tc.Image.Height - (tc.Z*4), tc.Image.Width, tc.Image.Height ) );

										list.Remove(tc);
									}
								}
							}
						}

						SetCursorMouseXY(e.X,e.Y,true);
					}
					else
					{
						for ( int x = m_X; x < m_X + m_W; ++x )
						{
							for ( int y = m_Y; y < m_Y + m_H; ++y )
							{
								m_Design.AddComponent( x, y, m_Z, m_Level, m_Cursor.GetRandomIndex(), m_Cursor.BaseIndex, m_Cursor.Count );
								Invalidate( new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z*4), m_Cursor.Image.Width, m_Cursor.Image.Height ) );
							}
						}
					}
				}
			}
#endif
		}

		public HouseDesigner( HouseDesign design)
		{
			m_Design = design;

			// set starting level
			ChangeLevel(1);

			InitializeComponent();

			toolBox2.Designer = this;

			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true );

			UpdateText();
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}


		public void UpdateText()
		{
			Text = String.Format( "{0} ({1}x{2})", m_Design.Name, m_Design.UserWidth, m_Design.UserHeight );
		}

		private Brush m_LevelBrush = new SolidBrush( Color.FromArgb( 96, 32, 192, 32 ) );

		public Point GetPoint( int xOffset, int yOffset, int x, int y )
		{
			return new Point( xOffset + ((x - y) * 22), yOffset + ((x + y) * 22) - (m_buildZ * 4) - 44 );
		}

		private static ColorMatrix m_CursorMatrix = new ColorMatrix( new float[][]
			{
				new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f },
				new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f },
				new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f },
				new float[5]{ 0.0f, 0.0f, 0.0f, 0.5f, 0.0f },
				new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1.0f }
			} );

		private static ImageAttributes m_CursorAttributes = null;

		protected override void OnPaint( PaintEventArgs e )
		{
			if ( m_CursorAttributes == null )
			{
				m_CursorAttributes = new ImageAttributes();
				m_CursorAttributes.SetColorMatrix( m_CursorMatrix );
			}

			Graphics g = e.Graphics;

			g.Clear( SystemColors.ControlDark );

			int xOffset = (ClientSize.Width / 2);
			int yOffset = (ClientSize.Height - ((m_Design.Height + m_Design.Width) * 22)) /*/ 2*/ + 22;

			xOffset += m_CameraX;
			yOffset += m_CameraY;

			for ( int i = 0; i <= m_Level; ++i )
			{
				if ( i == m_Level && m_DrawVirtualFloor )
					g.FillPolygon( m_LevelBrush, new Point[]{ GetPoint( xOffset, yOffset, 1, 1 ), GetPoint( xOffset, yOffset, m_Design.UserWidth, 1 ), GetPoint( xOffset, yOffset, m_Design.UserWidth, m_Design.UserHeight ), GetPoint( xOffset, yOffset, 1, m_Design.UserHeight ) } );

				for ( int x = 0, vx = 0; x < m_Design.Width; ++x, vx += 22 )
				{
					int px = vx + xOffset, py = vx + yOffset;

					for ( int y = 0; y < m_Design.Height; ++y, px -= 22, py += 22 )
					{
						ArrayList components = m_Design.Components[x][y][i];

						for ( int j = 0; j < components.Count; ++j )
						{
							HouseComponent hc = (HouseComponent)components[j];

							g.DrawImage( hc.Image, px - (hc.Image.Width / 2), py - (hc.Z * 4) - hc.Image.Height );
						}

						if ( !m_Shifting && m_Cursor != null && x >= m_X && y >= m_Y && x < (m_X + m_W) && y < (m_Y + m_H) && m_Level == i )
							g.DrawImage( m_Cursor.Image, new Rectangle( xOffset + ((x - y) * 22) - (m_Cursor.Image.Width / 2), yOffset + ((x + y) * 22) - m_Cursor.Image.Height - (m_Z*4), m_Cursor.Image.Width, m_Cursor.Image.Height ), 0, 0, m_Cursor.Image.Width, m_Cursor.Image.Height, GraphicsUnit.Pixel, m_CursorAttributes );
					}
				}
			}

			if ( m_Shifting )
				g.DrawImage( m_ShiftImage, m_ShiftX - (m_ShiftImage.Width / 2), m_ShiftY - (m_ShiftImage.Height / 2), m_ShiftImage.Width, m_ShiftImage.Height );
		}

		private Bitmap GetBitmap()
		{
			int xMin = int.MaxValue, yMin = int.MaxValue;
			int xMax = int.MinValue, yMax = int.MinValue;

			for ( int i = 0; i <= m_Level; ++i )
			{
				for ( int x = 0, vx = 0; x < m_Design.Width; ++x, vx += 22 )
				{
					int px = vx, py = vx;

					for ( int y = 0; y < m_Design.Height; ++y, px -= 22, py += 22 )
					{
						ArrayList components = m_Design.Components[x][y][i];

						for ( int j = 0; j < components.Count; ++j )
						{
							HouseComponent hc = (HouseComponent)components[j];
							Bitmap img = hc.Image;

							int dx = px - (img.Width / 2);
							int dy = py - (hc.Z * 4) - img.Height;

							if ( dx < xMin )
								xMin = dx;

							if ( dy < yMin )
								yMin = dy;

							dx += img.Width;
							dy += img.Height;

							if ( dx > xMax )
								xMax = dx;

							if ( dy > yMax )
								yMax = dy;
						}
					}
				}
			}

			if ( xMin == int.MaxValue || yMin == int.MaxValue || xMax == int.MinValue || yMax == int.MinValue )
				return new Bitmap( 0, 0 );

			Bitmap bmp = new Bitmap( xMax - xMin, yMax - yMin );
			Graphics g = Graphics.FromImage( bmp );

			int xOffset = -xMin;
			int yOffset = -yMin;

			for ( int i = 0; i <= m_Level; ++i )
			{
				for ( int x = 0, vx = 0; x < m_Design.Width; ++x, vx += 22 )
				{
					int px = vx + xOffset, py = vx + yOffset;

					for ( int y = 0; y < m_Design.Height; ++y, px -= 22, py += 22 )
					{
						ArrayList components = m_Design.Components[x][y][i];

						for ( int j = 0; j < components.Count; ++j )
						{
							HouseComponent hc = (HouseComponent)components[j];

							g.DrawImage( hc.Image, px - (hc.Image.Width / 2), py - (hc.Z * 4) - hc.Image.Height );
						}
					}
				}
			}

			g.Dispose();

			return bmp;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HouseDesigner));
			this.mmMain = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.mnuSaveAs = new System.Windows.Forms.MenuItem();
			this.miRenderImage = new System.Windows.Forms.MenuItem();
			this.miRenderPng = new System.Windows.Forms.MenuItem();
			this.miRenderJpeg = new System.Windows.Forms.MenuItem();
			this.miRenderGif = new System.Windows.Forms.MenuItem();
			this.miRenderBitmap = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miDesign = new System.Windows.Forms.MenuItem();
			this.miLevel = new System.Windows.Forms.MenuItem();
			this.miFoundation = new System.Windows.Forms.MenuItem();
			this.miFirst = new System.Windows.Forms.MenuItem();
			this.miSecond = new System.Windows.Forms.MenuItem();
			this.miThird = new System.Windows.Forms.MenuItem();
			this.miRoof = new System.Windows.Forms.MenuItem();
			this.miFifth = new System.Windows.Forms.MenuItem();
			this.miSixth = new System.Windows.Forms.MenuItem();
			this.miVirtFloor = new System.Windows.Forms.MenuItem();
			this.miSeperator = new System.Windows.Forms.MenuItem();
			this.miClear = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miBuild = new System.Windows.Forms.MenuItem();
			this.miBuildQuick = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolBox2 = new UOArchitect.ToolBox();
			this.SuspendLayout();
			// 
			// mmMain
			// 
			this.mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miFile,
																				   this.miDesign,
																				   this.menuItem2});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miSave,
																				   this.mnuSaveAs,
																				   this.miRenderImage,
																				   this.menuItem3});
			this.miFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
			this.miFile.Text = "&File";
			// 
			// miSave
			// 
			this.miSave.Index = 0;
			this.miSave.Text = "&Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// mnuSaveAs
			// 
			this.mnuSaveAs.Index = 1;
			this.mnuSaveAs.Text = "Save &As...";
			this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
			// 
			// miRenderImage
			// 
			this.miRenderImage.Index = 2;
			this.miRenderImage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.miRenderPng,
																						  this.miRenderJpeg,
																						  this.miRenderGif,
																						  this.miRenderBitmap});
			this.miRenderImage.Text = "Render &Image";
			// 
			// miRenderPng
			// 
			this.miRenderPng.Index = 0;
			this.miRenderPng.Text = "Png";
			this.miRenderPng.Click += new System.EventHandler(this.miRenderPng_Click);
			// 
			// miRenderJpeg
			// 
			this.miRenderJpeg.Index = 1;
			this.miRenderJpeg.Text = "Jpg";
			this.miRenderJpeg.Click += new System.EventHandler(this.miRenderJpeg_Click);
			// 
			// miRenderGif
			// 
			this.miRenderGif.Index = 2;
			this.miRenderGif.Text = "Gif";
			this.miRenderGif.Click += new System.EventHandler(this.miRenderGif_Click);
			// 
			// miRenderBitmap
			// 
			this.miRenderBitmap.Index = 3;
			this.miRenderBitmap.Text = "Bitmap";
			this.miRenderBitmap.Click += new System.EventHandler(this.miRenderBitmap_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// miDesign
			// 
			this.miDesign.Index = 1;
			this.miDesign.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miLevel,
																					 this.miVirtFloor,
																					 this.miSeperator,
																					 this.miClear,
																					 this.menuItem1,
																					 this.miBuild,
																					 this.miBuildQuick});
			this.miDesign.MergeOrder = 2;
			this.miDesign.Text = "&Design";
			this.miDesign.Popup += new System.EventHandler(this.miDesign_Popup);
			// 
			// miLevel
			// 
			this.miLevel.Index = 0;
			this.miLevel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miFoundation,
																					this.miFirst,
																					this.miSecond,
																					this.miThird,
																					this.miRoof,
																					this.miFifth,
																					this.miSixth});
			this.miLevel.Text = "&Level";
			this.miLevel.Popup += new System.EventHandler(this.miLevel_Popup);
			// 
			// miFoundation
			// 
			this.miFoundation.Index = 0;
			this.miFoundation.Text = "F&oundation";
			this.miFoundation.Click += new System.EventHandler(this.miFoundation_Click);
			// 
			// miFirst
			// 
			this.miFirst.Index = 1;
			this.miFirst.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.miFirst.Text = "F&irst";
			this.miFirst.Click += new System.EventHandler(this.miFirst_Click);
			// 
			// miSecond
			// 
			this.miSecond.Index = 2;
			this.miSecond.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.miSecond.Text = "&Second";
			this.miSecond.Click += new System.EventHandler(this.miSecond_Click);
			// 
			// miThird
			// 
			this.miThird.Index = 3;
			this.miThird.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.miThird.Text = "&Third";
			this.miThird.Click += new System.EventHandler(this.miThird_Click);
			// 
			// miRoof
			// 
			this.miRoof.Index = 4;
			this.miRoof.Shortcut = System.Windows.Forms.Shortcut.F4;
			this.miRoof.Text = "&Fourth";
			this.miRoof.Click += new System.EventHandler(this.miRoof_Click);
			// 
			// miFifth
			// 
			this.miFifth.Index = 5;
			this.miFifth.Shortcut = System.Windows.Forms.Shortcut.F6;
			this.miFifth.Text = "Fifth";
			this.miFifth.Click += new System.EventHandler(this.miFifth_Click);
			// 
			// miSixth
			// 
			this.miSixth.Index = 6;
			this.miSixth.Shortcut = System.Windows.Forms.Shortcut.F7;
			this.miSixth.Text = "Sixth";
			this.miSixth.Click += new System.EventHandler(this.miSixth_Click);
			// 
			// miVirtFloor
			// 
			this.miVirtFloor.Index = 1;
			this.miVirtFloor.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.miVirtFloor.Text = "&Virtual Floor";
			this.miVirtFloor.Click += new System.EventHandler(this.miVirtFloor_Click);
			// 
			// miSeperator
			// 
			this.miSeperator.Index = 2;
			this.miSeperator.Text = "-";
			// 
			// miClear
			// 
			this.miClear.Index = 3;
			this.miClear.Text = "&Clear";
			this.miClear.Click += new System.EventHandler(this.miClear_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// miBuild
			// 
			this.miBuild.Index = 5;
			this.miBuild.Text = "&Build";
			this.miBuild.Click += new System.EventHandler(this.miBuild_Click);
			// 
			// miBuildQuick
			// 
			this.miBuildQuick.Index = 6;
			this.miBuildQuick.Text = "Build &Quick";
			this.miBuildQuick.Click += new System.EventHandler(this.miBuildQuick_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6});
			this.menuItem2.MergeOrder = 2;
			this.menuItem2.Text = "&Build";
			this.menuItem2.Visible = false;
			// 
			// menuItem4
			// 
			this.menuItem4.Enabled = false;
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "Build Design";
			// 
			// menuItem5
			// 
			this.menuItem5.Enabled = false;
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "Extract Design";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Text = "-";
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "uoh";
			this.saveDialog.Filter = "House Design Files (*.uoh)|*.uoh";
			this.saveDialog.Title = "Save";
			// 
			// toolBox2
			// 
			this.toolBox2.Designer = null;
			this.toolBox2.Location = new System.Drawing.Point(0, 0);
			this.toolBox2.Name = "toolBox2";
			this.toolBox2.Size = new System.Drawing.Size(600, 160);
			this.toolBox2.TabIndex = 0;
			this.toolBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolBox2_MouseUp);
			this.toolBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolBox2_MouseMove);
			this.toolBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolBox2_MouseDown);
			// 
			// HouseDesigner
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 481);
			this.Controls.Add(this.toolBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Menu = this.mmMain;
			this.Name = "HouseDesigner";
			this.Text = "HouseDesigner";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

		private void miSave_Click(object sender, System.EventArgs e)
		{
			if(m_Design.IsNewRecord)
			{
				DesignPropertyEditor dlg = new DesignPropertyEditor();
				dlg.LoadForm(ref m_Design, this);
				dlg.Dispose();
			}
	
			Cursor.Current = Cursors.WaitCursor;
			m_Design.Save();
			m_Design.FileHeader.Unload();
			Cursor.Current = Cursors.Default;
		}

		private void miFirst_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 1 )
			{
				ChangeLevel(1);
			}
		}

		private void miSecond_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 2 )
			{
				ChangeLevel(2);
			}
		}

		private void miThird_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 3 )
			{
				ChangeLevel(3);
			}
		}

		private void miRoof_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 4 )
			{
				ChangeLevel(4);
			}
		}

		private void miFoundation_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 0 )
			{
				ChangeLevel(0);
			}
		}

		private void miLevel_Popup(object sender, System.EventArgs e)
		{
			miFoundation.Checked = ( m_Level == 0 );
			miFirst.Checked = ( m_Level == 1 );
			miSecond.Checked = ( m_Level == 2 );
			miThird.Checked = ( m_Level == 3 );
			miRoof.Checked = ( m_Level == 4 );
		}

		private void miDesign_Popup(object sender, System.EventArgs e)
		{
			miVirtFloor.Checked = m_DrawVirtualFloor;
		}

		private void miVirtFloor_Click(object sender, System.EventArgs e)
		{
			m_DrawVirtualFloor = !m_DrawVirtualFloor;

			Invalidate();
		}

		private void miClear_Click(object sender, System.EventArgs e)
		{
			m_Design.Clear();
			m_Design.BuildFoundation();
			Invalidate();
		}

		private void miBuild_Click(object sender, System.EventArgs e)
		{
			if ( Client.Running )
			{
				ArrayList list = m_Design.Compress();

				for ( int i = 0; i < list.Count; ++i )
					((BuildEntry)list[i]).Send();
			}
			else
			{
				MessageBox.Show( "Start Ultima Online first." );
			}
		}

		private void miBuildQuick_Click(object sender, System.EventArgs e)
		{
			ArrayList list = m_Design.Compress();

			StringBuilder sb = new StringBuilder();

			for ( int i = 0; i < list.Count; ++i )
				((BuildEntry)list[i]).Append( sb );

			Clipboard.SetDataObject( sb.ToString() );
		}

		private void miRenderPng_Click(object sender, System.EventArgs e)
		{
			GetBitmap().Save( m_Design.Name + ".png", ImageFormat.Png );
		}

		private void miRenderJpeg_Click(object sender, System.EventArgs e)
		{
			GetBitmap().Save( m_Design.Name + ".jpg", ImageFormat.Jpeg );
		}

		private void miRenderGif_Click(object sender, System.EventArgs e)
		{
			GetBitmap().Save( m_Design.Name + ".gif", ImageFormat.Gif );
		}

		private void miRenderBitmap_Click(object sender, System.EventArgs e)
		{
			GetBitmap().Save( m_Design.Name + ".bmp", ImageFormat.Bmp );
		}

		private void mnuSaveAs_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			DesignPropertyEditor dlg = new DesignPropertyEditor();
			dlg.LoadForm(ref m_Design, this);
			dlg.Dispose();

			m_Design.Save(true);

			Cursor.Current = Cursors.Default;
		}

		private void toolBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				Cursor.Current = Cursors.Hand;
				m_MouseDown = true;
				m_MousePos = new Point(e.X, e.Y);
			}
		}

		private void toolBox2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point newLocation;
			int x;
			int y;
			Point location;
			Rectangle rectangle;

			if (!m_MouseDown)
			{
				return;
			}

			location = this.toolBox2.Location;

			newLocation = new Point((location.X + (e.X - m_MousePos.X)), (location.Y + (e.Y - m_MousePos.Y)));
			
			if (newLocation.X < 0)
			{
				x = 0;
			}
			else
			{
				rectangle = base.ClientRectangle;

				if ((newLocation.X + this.toolBox2.Width) > rectangle.Width)
				{
					rectangle = base.ClientRectangle;
					x = (rectangle.Width - this.toolBox2.Width);
				}

				x = newLocation.X;
			}
 
			if (newLocation.Y < 0)
			{
				y = 0;

			}
			else
			{
				rectangle = base.ClientRectangle;
				
				if ((newLocation.Y + this.toolBox2.Height) > rectangle.Height)
				{
					rectangle = base.ClientRectangle;
					y = (rectangle.Height - this.toolBox2.Height);
				}
				y = newLocation.Y;

			}
 
			this.toolBox2.Location = new Point(x, y);
		}

		private void toolBox2_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				m_MouseDown = false;
				Cursor.Current = Cursors.Default;
			}
		}

		private void miFifth_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 5 )
			{
				ChangeLevel(5);
			}
		}

		private void miSixth_Click(object sender, System.EventArgs e)
		{
			if ( m_Level != 6 )
			{
				ChangeLevel(6);
			}
		}
	}
}