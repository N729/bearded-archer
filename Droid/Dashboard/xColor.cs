using System;
using Xamarin.Forms;

namespace SocialNetwork.Droid
{
	public static class xColor
	{
		static Color gray = Color.FromRgb(223, 223, 223);

		public static Color Gray {
			get {
				return gray;
			}
			set {
				gray = value;
			}
		}

		static Color white = Color.FromRgb (245, 245, 245);

		public static Color White {
			get {
				return white;
			}
			set {
				white = value;
			}
		}

		static Color tWhite = Color.FromRgba (245, 245, 245, 0.1f);

		public static Color transWhite {
			get {
				return tWhite;
			}
			set {
				tWhite = value;
			}
		}

		static Color textGray = Color.FromRgb (175, 175, 175);

		public static Color TextGray {
			get {
				return textGray;
			}
			set {
				textGray = value;
			}
		}

		static Color blue = Color.FromRgb (121, 166, 255);

		public static Color Blue {
			get {
				return blue;
			}
			set {
				blue = value;
			}
		}
	}
}

