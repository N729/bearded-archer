using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;
using Xamarin.Controls;
using Xamarin.Forms;

namespace SocialNetwork.Droid
{
	[Activity (Label = "SocialNetwork.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			AlertCenter.Default.Init (Application);
			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
			App.ScreenSize = new Size(
				Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density,
				Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
			LoadApplication (new App ());
		}
	}
}

