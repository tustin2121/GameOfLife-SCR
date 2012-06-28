using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife {
	class Clock {
		public static bool Clock24Hour { get; set; }

		public static bool[,] GetCurrentTimePattern() {
			DateTime dt = DateTime.Now;
			bool[,] finalPattern = new bool[(3+1)* 4 + (1+1), 5];

			int h = dt.Hour;
			int m = dt.Minute;
			if (!Clock24Hour && h > 12) {
				h -= 12;
			}

			return finalPattern
				.OverlayPattern(Get2DigitNumber(h), 0, 0)
				.OverlayPattern(NumColon, 8, 0)
				.OverlayPattern(Get2DigitNumber(m, true), 10, 0);
		}

		public static bool[,] Get2DigitNumber(int num) {
			return Get2DigitNumber(num, false);
		}
		public static bool[,] Get2DigitNumber(int num, bool zeroPrecede) {
			if (num > 99) throw new Exception("Number is not double digit!"); //sanity check
			bool[,] pattern = new bool[7,5];
			int ones = num % 10;
			int tens = (num - ones) / 10;

			bool[,] onesPattern = Get1DigitNumber(ones);
			bool[,] tensPattern = (tens == 0 && !zeroPrecede)? NumEmpty : Get1DigitNumber(tens);
			pattern.OverlayPattern(tensPattern, 0, 0).OverlayPattern(onesPattern, 4, 0);
			return pattern;
		}
		public static bool[,] Get1DigitNumber(int num) {
			switch (num) {
				case 0: return Num0;
				case 1: return Num1;
				case 2: return Num2;
				case 3: return Num3;
				case 4: return Num4;
				case 5: return Num5;
				case 6: return Num6;
				case 7: return Num7;
				case 8: return Num8;
				case 9: return Num9;
				default:
					throw new Exception("Number is not single digit!");
			}
		}

		#region Numbers
		//All patterns are flipped around the x=y axis
		public static bool[,] NumEmpty {
			get {
				return new bool[,] {
					{ false, false, false, false, false },
					{ false, false, false, false, false },
					{ false, false, false, false, false },
				};
			}
		}
		public static bool[,] NumColon {
			get {
				return new bool[,] {
					{ false,  true,  false,  true, false },
				};
			}
		}
		public static bool[,] Num0 {
			get {
				return new bool[,] {
					{  true,  true,  true,  true,  true },	
					{  true, false, false, false,  true },
					{  true,  true,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num1 {
			get {
				return new bool[,] {
					{ false, false, false, false, false },
					{  true,  true,  true,  true,  true },
					{ false, false, false, false, false },
				};
			}
		}
		public static bool[,] Num2 {
			get {
				return new bool[,] {
					{  true, false,  true,  true,  true },
					{  true, false,  true, false,  true },
					{  true,  true,  true, false,  true },
				};
			}
		}
		public static bool[,] Num3 {
			get {
				return new bool[,] {
					{  true, false, false, false,  true },
					{  true, false,  true, false,  true },
					{  true,  true,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num4 {
			get {
				return new bool[,] {
					{  true,  true,  true, false, false },
					{ false, false,  true, false, false },
					{  true,  true,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num5 {
			get {
				return new bool[,] {
					{  true,  true,  true, false,  true },
					{  true, false,  true, false,  true },
					{  true, false,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num6 {
			get {
				return new bool[,] {
					{  true,  true,  true,  true,  true },
					{  true, false,  true, false,  true },
					{  true, false,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num7 {
			get {
				return new bool[,] {
					{  true, false, false, false, false },
					{  true, false, false, false, false },
					{  true,  true,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num8 {
			get {
				return new bool[,] {
					{  true,  true,  true,  true,  true },
					{  true, false,  true, false,  true },
					{  true,  true,  true,  true,  true },
				};
			}
		}
		public static bool[,] Num9 {
			get {
				return new bool[,] {
					{  true,  true,  true, false,  true },
					{  true, false,  true, false,  true },
					{  true,  true,  true,  true,  true },
				};
			}
		}
		#endregion
	}
}
