using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife {
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

		public static bool[,] Bomb {
			get {
				return new bool[,] {
					{ false,  true, false },
					{  true,  true,  true },
					{ false,  true, false },
				};
			}
		}

		public static bool[,] Bomb2 {
			get {
				return new bool[,] {
					{ false, false, false, false, false },
					{ false,  true, false, false, false },
					{  true,  true,  true, false, false },
					{ false,  true, false, false, false },
					{ false, false, false, false, false },
				};
			}
		}


		//Extension method
		public static bool[,] OverlayPattern(this bool[,] b, bool[,] pattern, int offx, int offy){
			if (offx < 0 || offy < 0 ||
				offx + pattern.GetLength(0) > b.GetLength(0) ||
				offy + pattern.GetLength(1) > b.GetLength(1))
				throw new IndexOutOfRangeException("pattern and offset must fit within the range!");

			for (int x = 0; x < pattern.GetLength(0); x++) {
				for (int y = 0; y < pattern.GetLength(1); y++) {
					b[x + offx, y + offy] = pattern[x, y];
				}
			}
			return b;
		}
	}
	
}
