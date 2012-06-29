using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GameOfLife {
	public partial class SettingsForm : Form {
		public static const string KEY_SIMLIM = "simlim";
		public static const string KEY_RANDRATIO = "randratio";
		public static const string KEY_TICKLEN = "ticklen";
		public static const string KEY_BORNBITS = "bornbits";
		public static const string KEY_LIVEBITS = "livebits";
		public static const string KEY_ALTMODE = "altmode";
		public static const string KEY_CELLSIZE = "cellsize";
		public static const string KEY_CLOCKEN = "clocken";
		public static const string KEY_CLOCKAP = "clockap";
		public static const string KEY_CLOCKOFF = "clockoff";
		public static const string KEY_CELL_COLOR = "cellcolor";


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
		}

        private void SaveSettings() {
            // Create or get existing Registry subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\GameOfLife");

            key.SetValue(KEY_SIMLIM, numSimLimit.Value);
        }

        private void LoadSettings()
        {
            // Get the value stored in the Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\GameOfLife");
			if (key == null) {
				numSimLimit.Value = 1000;
				numTick.Value = 200;
			} else {
				numSimLimit.Value = (int)key.GetValue(KEY_SIMLIM);
				numTick.Value = (int)key.GetValue(KEY_TICKLEN);
			}
        }

	}
}
