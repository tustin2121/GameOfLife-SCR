using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace GameOfLife {
	public class PatternLoader {
		public static bool[,] LoadPatternFromBMP(Bitmap bmp) {
			try {
				bool[,] final = new bool[bmp.Width, bmp.Height];

				for (int y = 0; y < bmp.Height; y++) {
					for (int x = 0; x < bmp.Width; x++) {
						final[x, y] = bmp.GetPixel(x, y).GetBrightness() > 0.5; //this seems ugly
					}
				}
				bmp.Dispose();

				return final;
			} catch (IOException) {
				return null;
			}
		}

		public static bool[,] LoadPatternFromBMP(string filename) {
			if (!File.Exists(filename)) return null;
			Bitmap bmp = new Bitmap(filename);
			return LoadPatternFromBMP(bmp);
		}
	}
}
