using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;

using S = GameOfLife.SettingsForm;

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
			if (!previewMode) {
				Cursor.Hide();
#if !DEBUG
				this.TopMost = true;
#endif
			}
			this.ApplyDefaults();
			this.LoadSettings();

			this.OnBegin();
			this.Randomize();
			gameTimer.Start();
		}

		private void OnMouseMove(object sender, MouseEventArgs e) {
			if (previewMode) return;
			if (!lastMouseLoc.IsEmpty) {
				if (Math.Abs(lastMouseLoc.X - e.X) > SIG_MOUSE_MOVE || Math.Abs(lastMouseLoc.Y - e.Y) > SIG_MOUSE_MOVE) {
					Application.Exit();
				}
			}

			lastMouseLoc = e.Location;
		}

		private void OnMouseClick(object sender, MouseEventArgs e) {
			if (previewMode) return;
			Application.Exit();
		}

		private void OnKeyDown(object sender, KeyEventArgs e) {
			Random r;

			gametime = 0;

			if (previewMode) return;
			switch (e.KeyCode) {
				case Keys.F5:
					this.Randomize();
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
					r = new Random();
					for (int i = 0; i < 200; i++)
						RandomlyPlacePattern(InterestingPatterns.Glider, 1, rand:r);
					break;
				case Keys.D3:
					ClearAll();
					r = new Random();
					for (int i = 0; i < 50; i++)
						RandomlyPlacePattern(InterestingPatterns.Bomb2, rand:r);
					break;
				case Keys.D4:
					ClearAll();
					bool[,] p = PatternLoader.LoadPatternFromBMP(ImageResource.breeder);
					LeftPlacePattern(p);
					break;
				default:
					Application.Exit(); return;
			}
		}

		private void LoadSettings() {
			// Get the value stored in the Registry
			RegistryKey key = Registry.CurrentUser.OpenSubKey(S.REG_SETTING_KEY);
			if (key == null) return;

			///// Sim Settings /////
			liveLimit = (ulong) S.RegKeyOrDefault(key, S.KEY_SIMLIM, (int)liveLimit);
			ticklength = S.RegKeyOrDefault(key, S.KEY_TICKLEN, ticklength);
			altMode = S.RegKeyOrDefault(key, S.KEY_ALTMODE, altMode);

			int u = S.RegKeyOrDefault(key, S.KEY_BORNLIVE_BITS, 0x10003000);
			bornBits = new BitArray(new int[] { (int)(u & 0xffff0000) >> 16 });
			liveBits = new BitArray(new int[] { (int)(u & 0x0000ffff) });

			///// Display Settings /////
			cellSize = S.RegKeyOrDefault(key, S.KEY_CELLSIZE, 6);

			enableClock = S.RegKeyOrDefault(key, S.KEY_CLOCKEN, true);
			applyClock = S.RegKeyOrDefault(key, S.KEY_CLOCKAP, true);
		}

		/////////////////////////////////////// Logic ////////////////////////////////////////////

		/**** Begin Settings ****/

		public int randomRatio { get; set; }
		public ulong liveLimit { get; set; }
		public int ticklength { get; set; }
		public BitArray bornBits { get; set; }
		public BitArray liveBits { get; set; }
		public bool altMode { get; set; }

		public int cellSize { get; set; }
		public bool enableClock { get; set; } //show clock
		public bool applyClock { get; set; } //apply the clock to the simulation
		public int[] clockOffset { get; set; }

		/**** End Settings ****/

		private ulong gametime = 0;
		private bool[,] nowc, prevc; //cells now and cells in the previous step

		private void ApplyDefaults() {
			liveLimit = 1000;
			ticklength = 60;
			altMode = false;
			randomRatio = 7;
			//                                      0,     1,     2,     3,     4,     5,     6,     7,     8,     9
			bornBits =	new BitArray(new bool[] { false, false, false,  true, false, false, false, false, false, false });
			liveBits =	//new BitArray(new bool[] { true, true, true, true, true, true, true, true, true, true });
						new BitArray(new bool[] { false, false,  true,  true, false, false, false, false, false, false });

			cellSize = 10;
			enableClock = applyClock = true;
			clockOffset = new int[] { 5, 5 };

			if (previewMode) {
				liveLimit = 100;
				enableClock = false;
				randomRatio = 2;
			}
		}

		private void OnBegin() {
			int x = this.Bounds.Width / cellSize;
			int y = this.Bounds.Height / cellSize;
			if (!altMode) { //the correct way to do it
				nowc = new bool[x, y];
				prevc = new bool[x, y];
			} else { //the "alternate way", which still produces interesting results
				nowc = prevc = new bool[x, y];
			}

			gameTimer.Interval = ticklength;

		}

		private void Randomize() {
			Random r = new Random();
			for (int x = 0; x < prevc.GetLength(0); x++) {
				for (int y = 0; y < prevc.GetLength(1); y++) {
					prevc[x, y] = nowc[x, y] = (r.Next(randomRatio) == 1);
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
					if (destx + x >= prevc.GetLength(0) || destx + x < 0) continue;
					if (desty + y >= prevc.GetLength(1) || desty + y < 0) continue;

					prevc[destx + x, desty + y] = nowc[destx + x, desty + y] = pattern[x, y];
				}
			}
		}

		private void LeftPlacePattern(bool[,] pattern) {
			int destx = 0;
			int desty = (prevc.GetLength(1) / 2) - (pattern.GetLength(1) / 2);

			for (int x = 0; x < pattern.GetLength(0); x++) {
				for (int y = 0; y < pattern.GetLength(1); y++) {
					if (destx + x >= prevc.GetLength(0) || destx + x < 0) continue;
					if (desty + y >= prevc.GetLength(1) || desty + y < 0) continue;

					prevc[destx + x, desty + y] = nowc[destx + x, desty + y] = pattern[x, y];
				}
			}
		}

		private void RandomlyPlacePattern(bool[,] pattern, int numDice = 4, Random rand = null) {
			if (rand == null) rand = new Random();
			if (numDice < 1) numDice = 1;

			int divx = (prevc.GetLength(0) - pattern.GetLength(0)) / numDice;
			int divy = (prevc.GetLength(1) - pattern.GetLength(1)) / numDice;

			int rx = 0, ry = 0;
			for (int i = 0; i < numDice; i++) {
				rx += rand.Next(divx);
				ry += rand.Next(divy);
			}

			int destx = rx - (pattern.GetLength(0) / 2);
			int desty = ry - (pattern.GetLength(1) / 2);

			for (int x = 0; x < pattern.GetLength(0); x++) {
				for (int y = 0; y < pattern.GetLength(1); y++) {
					if (destx + x >= prevc.GetLength(0) || destx + x < 0) continue;
					if (desty + y >= prevc.GetLength(1) || desty + y < 0) continue;

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

			if (enableClock && applyClock) {
				bool[,] clpat = Clock.GetCurrentTimePattern();
				int xorg = nowc.GetLength(0) - clockOffset[0] - clpat.GetLength(0);
				int yorg = nowc.GetLength(1) - clockOffset[1] - clpat.GetLength(1);

				nowc.OverlayPattern(clpat, xorg, yorg);
			}

			this.Invalidate();
//			this.Refresh();
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

			if (enableClock) {
				bool[,] clpat = Clock.GetCurrentTimePattern();

				int xorg = nowc.GetLength(0) - clockOffset[0] - clpat.GetLength(0);
				int yorg = nowc.GetLength(1) - clockOffset[1] - clpat.GetLength(1);
				for (int x = 0; x < clpat.GetLength(0); x++) {
					for (int y = 0; y < clpat.GetLength(1); y++) {
						if (clpat[x, y]) {
							g.FillRectangle(Brushes.Red, (xorg + x) * cellSize, (yorg + y) * cellSize, cellSize, cellSize);
						}
					}
				}
			}
		}

	}
}
