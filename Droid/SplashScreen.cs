using Android.Content;
using Xamarin.Forms;

namespace SocialNetwork.Droid
{
	public class SplashScreen : ContentPage
	{
		public SplashScreen ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}

		public void Login () {
			Forms.Context.StartActivity(typeof(SplashScreen));
		}

		public void Dashboard () {
			Forms.Context.StartActivity(typeof(SplashScreen));
		}
	}
}


