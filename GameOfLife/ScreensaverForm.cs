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
			if (previewMode) return;

			Random r;
			switch (e.KeyCode) {
				///////// keys for new games ////////
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
						RandomlyPlacePattern(InterestingPatterns.Bomb, rand:r);
					break;
				case Keys.D4:
					ClearAll();
					bool[,] p = PatternLoader.LoadPatternFromBMP(ImageResource.breeder);
					LeftPlacePattern(p);
					break;
				case Keys.D5:
				case Keys.D6:
				case Keys.D7:
				case Keys.D8:
				case Keys.D9:
					break; //These keys will do something in the future!
				//////// Control Keys ////////
				case Keys.MediaPlayPause: //pause/resume playback
				case Keys.F9:
					if (gameTimer.Enabled)
						gameTimer.Stop();
					else
						gameTimer.Start();
					break;
				case Keys.MediaNextTrack: //next frame, if possible
				case Keys.F11:
					if (gameTimer.Enabled) gameTimer.Stop();
					StepForward();
					this.Invalidate();
					break;
				case Keys.MediaPreviousTrack: //previous frame, if possible
				case Keys.F10:
					if (gameTimer.Enabled) gameTimer.Stop();
					StepBackwards();
					this.Invalidate();
					break;
				case Keys.MediaStop: //pauses the playback, just to give it something logical to do
					if (gameTimer.Enabled) gameTimer.Stop();
					break; 
				//////// Default Case: Exit /////////
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
		public int historyLimit { get; set; }

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

		private int ARRAYX, ARRAYY;
		private int oldestframe, currframe; //indexes into the cells array, for current frame, and oldest frame
		private bool[][,] cells; //the cells and a history of them
		private bool[,] nowc, prevc; //pointers into the cells array, cells now and cells in the previous step

		private void ApplyDefaults() {
			historyLimit = 31;
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
			ARRAYX = this.Bounds.Width / cellSize;
			ARRAYY = this.Bounds.Height / cellSize;

			oldestframe = currframe = 0;
			cells = new bool[historyLimit][,];
			/*
			for (int i = 0; i < cells.GetLength(0); i++) {
				cells[i] = new bool[ARRAYX, ARRAYY];
			}
			nowc = prevc = cells[0]; 
			/*/
			nowc = prevc = new bool[ARRAYX, ARRAYY];
			cells[0] = nowc;
			//*/
			
			/*
			if (!altMode) { //the correct way to do it
				nowc = new bool[x, y];
				prevc = new bool[x, y];
			} else { //the "alternate way", which still produces interesting results
				nowc = prevc = new bool[x, y];
			}*/

			gameTimer.Interval = ticklength;

		}

		private bool StepForward(bool create = false) {
			//returns false if can't step forward
			
			int newframe = (currframe + 1) % historyLimit; //newframe wraps around the cells array

			//if we don't want to step forward in the simulation, return false when it hits the end
			if (!create && newframe == oldestframe) return false;
			//*
			if (cells[newframe] == null) {
				if (!create) return false;

				cells[newframe] = new bool[ARRAYX, ARRAYY];
			} //*/

			//destruction begins here
			prevc = nowc; //switch cell arrays around
			nowc = cells[newframe];
			if (altMode) prevc = nowc;
			if (oldestframe == newframe) oldestframe = (oldestframe + 1) % historyLimit; //erase oldest frame
			currframe = newframe;

			return true;
		}
		private bool StepBackwards() {
			int newframe = currframe - 1; //note, % doesn't work as expected in reverse
			if (newframe < 0) newframe += historyLimit; //newframe wraps around the cells array

			if (newframe == oldestframe) return false; //can't step into oldest frame, as we need somewhere for prevc to point to

			//never should the previous cell frames be null. throw error if we're stepping into one though, sanity check
			if (cells[newframe] == null) throw new Exception("Null Cell Frames!");
			
			//destruction begins here
			int newprevframe = newframe - 1;
			if (newprevframe < 0) newprevframe += historyLimit;
			nowc = prevc;
			prevc = cells[newprevframe];
			if (altMode) prevc = nowc;
			currframe = newframe;
			return true;
		}

		private void Randomize() {
			Random r = new Random();
			gametime = 0;
			for (int x = 0; x < prevc.GetLength(0); x++) {
				for (int y = 0; y < prevc.GetLength(1); y++) {
					prevc[x, y] = nowc[x, y] = (r.Next(randomRatio) == 1);
				}
			}
		}

		private void ClearAll() {
			gametime = 0;
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
			/*var tempc = prevc;
			prevc = nowc;
			nowc = tempc;*/
			StepForward(true);

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
