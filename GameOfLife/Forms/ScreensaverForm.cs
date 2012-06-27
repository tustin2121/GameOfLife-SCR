using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GameOfLife {
	public partial class ScreensaverForm : Form {
		private const int SIG_MOUSE_MOVE = 5;

		private Point lastMouseLoc = Point.Empty;

		public ScreensaverForm(Rectangle bounds) {
			InitializeComponent();
			this.Bounds = bounds;
		}

		////////////////////////////////////////Events////////////////////////////////////////////

		private void OnLoad(object sender, EventArgs e) {
		//	Cursor.Hide();
		//	this.TopMost = true;

			this.OnBegin();
			this.Randomize();
			gameTimer.Start();
		}

		private void OnMouseMove(object sender, MouseEventArgs e) {
			if (!lastMouseLoc.IsEmpty) {
				if (Math.Abs(lastMouseLoc.X - e.X) > SIG_MOUSE_MOVE || Math.Abs(lastMouseLoc.Y - e.Y) > SIG_MOUSE_MOVE) {
					Application.Exit();
				}
			}

			lastMouseLoc = e.Location;
		}

		private void OnMouseClick(object sender, MouseEventArgs e) {
			Application.Exit();
		}

		private void OnKeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.F5:
					this.Randomize();
					gametime = 0;
					break;
				case Keys.D0:
					ClearAll();
					break;
				case Keys.D1:
					ClearAll();
					CenterPlacePattern(InterestingPatterns.Acorn);
					break;
				case Keys.D2:
					ClearAll();
					RandomlyPlacePattern(InterestingPatterns.Glider);
					break;
				case Keys.D3:
					ClearAll();
					RandomlyPlacePattern(InterestingPatterns.Blinker);
					break;
				default:
					Application.Exit(); return;
			}
		}

		/////////////////////////////////////// Logic ////////////////////////////////////////////

		private ulong liveLimit = 1000;
		private int ticklength = 200;
		private int cellSize = 6;//12;
		private BitArray bornBits;
		private BitArray liveBits;

		private ulong gametime = 0;
		private bool[,] nowc, prevc; //cells now and cells in the previous step

		private void OnBegin() {
			int x = this.Bounds.Width / cellSize;
			int y = this.Bounds.Height / cellSize;
			nowc = new bool[x,y];
			prevc = new bool[x, y];

			gameTimer.Interval = ticklength;

			//default                              0,     1,     2,     3,     4,     5,     6,     7,     8,     9
			bornBits = new BitArray(new bool[] { false, false, false,  true, false, false, false, false, false, false });
			liveBits = new BitArray(new bool[] { false, false,  true,  true, false, false, false, false, false, false });
		}

		private void Randomize() {
			Random r = new Random();
			for (int x = 0; x < prevc.GetLength(0); x++) {
				for (int y = 0; y < prevc.GetLength(1); y++) {
					prevc[x, y] = nowc[x, y] = (r.Next(7) == 1);
				}
			}
		}

		private void ClearAll() {
			for (int x = 0; x < prevc.GetLength(0); x++) {
				for (int y = 0; y < prevc.GetLength(1); y++) {
					prevc[x, y] = nowc[x, y] = false;
				}
			}
		}

		private void CenterPlacePattern(bool[,] pattern) {
			int destx = (prevc.GetLength(0) / 2) - (pattern.GetLength(0) / 2);
			int desty = (prevc.GetLength(1) / 2) - (pattern.GetLength(1) / 2);

			for (int x = 0; x < pattern.GetLength(0); x++) {
				for (int y = 0; y < pattern.GetLength(1); y++) {
					prevc[destx + x, desty + y] = nowc[destx + x, desty + y] = pattern[x, y];
				}
			}
		}

		private void RandomlyPlacePattern(bool[,] pattern) {
			Random r = new Random();

			int divx = (prevc.GetLength(0) - pattern.GetLength(0)) / 4;
			int divy = (prevc.GetLength(1) - pattern.GetLength(1)) / 4;

			int destx = (r.Next(divx) + r.Next(divx) + r.Next(divx) + r.Next(divx)) - (pattern.GetLength(0) / 2);
			int desty = (r.Next(divy) + r.Next(divy) + r.Next(divy) + r.Next(divy)) - (pattern.GetLength(1) / 2);

			for (int x = 0; x < pattern.GetLength(0); x++) {
				for (int y = 0; y < pattern.GetLength(1); y++) {
					prevc[destx + x, desty + y] = nowc[destx + x, desty + y] = pattern[x, y];
				}
			}
		}

		private void OnTick(object sender, EventArgs e) {
			//tick logic
			gametime++;
			if (liveLimit > 0 && gametime > liveLimit){
				this.Randomize();
				gametime = 0;
			}
	//		this.Refresh(); return;

			//switch the arrays, so the now step is in the previous step
			var tempc = prevc;
			prevc = nowc;
			nowc = tempc;

			int count;
			int xmin, xmax, ymin, ymax;
			for (int x = 0; x < prevc.GetLength(0); x++) {
				for (int y = 0; y < prevc.GetLength(1); y++) {
					count = 0;
					xmin = Math.Max(x-1, 0);
					xmax = Math.Min(x + 1, prevc.GetLength(0) - 1);
					ymin = Math.Max(y-1, 0);
					ymax = Math.Min(y + 1, prevc.GetLength(1) - 1);

				//	Console.Out.Write(xmin + " " + xmax + " " + ymin + " " + ymax + " ");

					for (int xx = xmin; xx <= xmax; xx++) {
						for (int yy = ymin; yy <= ymax; yy++) {
							if (xx == x && yy == y) continue; //skip own cell
							count += (prevc[xx, yy]) ? 1 : 0;
				//			Console.Out.Write(xx+","+yy+" ");
						}
					}
				//	Console.Out.WriteLine(count);

					if (count > 9) count = 9; //sanity check

					if (prevc[x, y]) { //if cell alive
						//checks if the count number is in the "live" array; if that bit is true, the cell lives
						nowc[x, y] = liveBits[count];
					} else { //else if cell dead
						//checks if the count number is in the "born" array; if that bit is true, the cell is born
						nowc[x, y] = bornBits[count];
					}
					
				}
			}

			this.Refresh();
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			if (gametime == 0) base.OnPaintBackground(e);
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			
			for (int x = 0; x < nowc.GetLength(0); x++) {
				for (int y = 0; y < nowc.GetLength(1); y++) {
					if (nowc[x, y]) {
						g.FillRectangle(Brushes.Green, x * cellSize, y * cellSize, cellSize, cellSize);
					} else {
						//do nothing?
						g.FillRectangle(Brushes.Black, x * cellSize, y * cellSize, cellSize, cellSize);
					}
				}
			}
		}

		/////////////////////////////////////////Interesting Patterns//////////////////////////////////////////

	}

	public static class InterestingPatterns {
		public static bool[,] Acorn {
			get { /*
				return new bool[,] { 
					{ false,  true, false, false, false, false, false },
					{ false, false, false,  true, false, false, false },
					{  true,  true, false, false,  true,  true,  true }
				}; //*/
				return new bool[,] { 
					{ false, false,  true },
					{  true, false,  true },
					{ false, false, false },
					{ false,  true, false },
					{ false, false,  true },
					{ false, false,  true },
					{ false, false,  true },
				};
			}
		}

		public static bool[,] Glider {
			get {
				return new bool[,] {
					{  true, false, false },
					{ false,  true,  true },
					{  true,  true, false },
				};
			}
		}

		public static bool[,] Blinker {
			get {
				return new bool[,] {
					{ false,  true, false },
					{ false,  true, false },
					{ false,  true, false },
				};
			}
		}
	}
}
