using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;

namespace GameOfLife {
	public partial class SettingsForm : Form {
		public const string REG_SETTING_KEY = "SOFTWARE\\Digiplex\\GameOfLifeSCR";

		public const string KEY_SIMLIM = "simlim";
		public const string KEY_RANDRATIO = "randratio";
		public const string KEY_TICKLEN = "ticklen";
		public const string KEY_BORNLIVE_BITS = "bornlivebits";
		public const string KEY_ALTMODE = "altmode";
		public const string KEY_CELLSIZE = "cellsize";
		public const string KEY_CLOCKEN = "clocken";
		public const string KEY_CLOCKAP = "clockap";
		public const string KEY_CLOCKOFF = "clockoff";
		public const string KEY_CELL_COLOR = "cellcolor";

		private static int[] validPixelSizes = new int[] { 1, 2, 3, 5, 6, 10, 12, 24 };

		private CheckBox[] bornChks, liveChks;

		public SettingsForm() {
			InitializeComponent();

            bornChks = new CheckBox[] { 
                chkBorn0, chkBorn1, chkBorn2, chkBorn3, chkBorn4, 
                chkBorn5, chkBorn6, chkBorn7, chkBorn8, chkBorn9
            };
            liveChks = new CheckBox[] {
                chkLive0, chkLive1, chkLive2, chkLive3, chkLive4,
                chkLive5, chkLive6, chkLive7, chkLive8, chkLive9
            };

			boxPixelSize.Items.Clear();
			boxPixelSize.Items.AddRange(validPixelSizes.Select<int, string>(x => x.ToString()).ToArray<string>());
		}

		private void SaveSettings() {
			// Create or get existing Registry subkey
			RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_SETTING_KEY);

			///// Sim Settings //////
			key.SetValue(KEY_SIMLIM, numSimLimit.Value, RegistryValueKind.DWord);
			key.SetValue(KEY_TICKLEN, numTick.Value, RegistryValueKind.DWord);
			key.SetValue(KEY_ALTMODE, chkAltMode.Checked, RegistryValueKind.Binary);
			{
				BitArray born = new BitArray(9);
				BitArray live = new BitArray(9);
				for (int i = 0; i < born.Count; i++) {
					born[i] = bornChks[i].Checked;
					live[i] = liveChks[i].Checked;
				}
				//copy the bit array into a single 32-bit int, to put into the registry
				int[] u = new int[2];
				born.CopyTo(u, 0);
				live.CopyTo(u, 1);
				u[0] = (u[0] & 0xffff) << 16 | (u[1] & 0xffff);
				key.SetValue(KEY_BORNLIVE_BITS, u[0], RegistryValueKind.DWord);
			}

			///// Display Settings /////
			key.SetValue(KEY_CELLSIZE, validPixelSizes[boxPixelSize.SelectedIndex], RegistryValueKind.DWord);
		}

        private void LoadSettings() {
			// Get the value stored in the Registry
			RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_SETTING_KEY);

			///// Sim Settings /////
			numSimLimit.Value = RegKeyOrDefault(key, KEY_SIMLIM, 1000);
			numTick.Value = RegKeyOrDefault(key, KEY_TICKLEN, 200);
			chkAltMode.Checked = RegKeyOrDefault(key, KEY_ALTMODE, false);

			int u = RegKeyOrDefault(key, KEY_BORNLIVE_BITS, 0x10003000);
			BitArray born = new BitArray(new int[] { (int)(u & 0xffff0000) >> 16 });
			BitArray live = new BitArray(new int[] { (int)(u & 0x0000ffff) });
			for (int i = 0; i < born.Count; i++) {
				bornChks[i].Checked = born[i];
				liveChks[i].Checked = live[i];
			}

			///// Display Settings /////
			int pxSize = RegKeyOrDefault(key, KEY_CELLSIZE, 6);
			boxPixelSize.SelectedValue = Array.IndexOf(validPixelSizes, pxSize);

			chkClockEnable.Checked = RegKeyOrDefault(key, KEY_CLOCKEN, true);
			chkClockApply.Checked = RegKeyOrDefault(key, KEY_CLOCKAP, true);
		}

		#region RegKeyOrDefault

		public static int RegKeyOrDefault(RegistryKey regkey, string key, int def) {
			if (regkey == null) return def;
			return (int)regkey.GetValue(key, def);
		}
		public static bool RegKeyOrDefault(RegistryKey regkey, string key, bool def) {
			if (regkey == null) return def;
			return (bool)regkey.GetValue(key, def);
		}
		public static Color RegKeyOrDefault(RegistryKey regkey, string key, Color def) {
			if (regkey == null) return def;
			return (Color)regkey.GetValue(key, def);
		}

		#endregion

		private void btnOk_Click(object sender, EventArgs e) {
			SaveSettings();
			Close();
		}

		private void SettingsForm_Load(object sender, EventArgs e) {
			LoadSettings();
		}

		private void standardToolStripMenuItem_Click(object sender, EventArgs e) {
			chkAltMode.Checked = false;

			for (int i = 0; i < 10; i++) {
				bornChks[i].Checked = false;
				liveChks[i].Checked = false;
			}
			bornChks[3].Checked = true;
			liveChks[2].Checked = true;
			liveChks[3].Checked = true;
		}

		private void highLifeToolStripMenuItem_Click(object sender, EventArgs e) {
			standardToolStripMenuItem_Click(sender, e);
			bornChks[6].Checked = true;
		}

		private void mayanMazeToolStripMenuItem_Click(object sender, EventArgs e) {
			chkAltMode.Checked = true;

			for (int i = 0; i < 10; i++) {
				bornChks[i].Checked = false;
				liveChks[i].Checked = false;
			}
			bornChks[2].Checked = true;
			liveChks[1].Checked = true;
			liveChks[2].Checked = true;
		}

		private void dayNightToolStripMenuItem_Click(object sender, EventArgs e) {
			chkAltMode.Checked = false;

			for (int i = 0; i < 10; i++) {
				bornChks[i].Checked = false;
				liveChks[i].Checked = false;
			}
			bornChks[3].Checked = true;
			bornChks[6].Checked = true;
			bornChks[7].Checked = true;
			bornChks[8].Checked = true;

			liveChks[3].Checked = true;
			liveChks[4].Checked = true;
			liveChks[6].Checked = true;
			liveChks[7].Checked = true;
			liveChks[8].Checked = true;
		}

		private void lifeWithoutDeathToolStripMenuItem_Click(object sender, EventArgs e) {
			chkAltMode.Checked = false;

			for (int i = 0; i < 10; i++) {
				bornChks[i].Checked = false;
				liveChks[i].Checked = true; //<--- key, all of them are on
			}
			bornChks[3].Checked = true;
		}

		private void seedsToolStripMenuItem_Click(object sender, EventArgs e) {
			chkAltMode.Checked = false;

			for (int i = 0; i < 10; i++) {
				bornChks[i].Checked = false;
				liveChks[i].Checked = false;
			}
			bornChks[2].Checked = true;
		}
	}
}
