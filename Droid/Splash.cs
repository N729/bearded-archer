using System;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SocialNetwork.Droid
{
	[Activity(Label = "MyApp", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class Splash : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			LoadApplication (new SplashScreen ());
		}
	}
}

