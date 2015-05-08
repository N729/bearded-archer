/*
 * Created By Nick Kunes March 31st 2015
 */
using Xamarin.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;


#pragma warning disable 108

using Android.App;
using Parse;
using Xamarin.Forms;

namespace SocialNetwork.Droid
{
	public class App : Xamarin.Forms.Application
	{
		public static Size ScreenSize {
			get;
			set;
		}
			
		public static App Current {
			get;
			set;
		}

		public App ()
		{
			Current = this;

			/*
			 * Creating a new List of ContentPages, calling it pages, and adding 
			 * Login and Register to the List
			 */

			Label title = new Label {
				Text = "LOADING",
				FontSize = 25,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.TextGray 
			};

			BoxView header = new BoxView
			{
				Color = xColor.Gray,
				WidthRequest = 5000,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center 
			};

			BoxView pictureBackground = new BoxView {
				BackgroundColor = xColor.TextGray,
				WidthRequest = 5000,
				HeightRequest = 5000,
				HorizontalOptions = LayoutOptions.Center
			};

			AbsoluteLayout pageHeader = new AbsoluteLayout {
				Children = {
					header
				}
			};

			CircularProgress progressBar = new CircularProgress {
				ProgressColor = xColor.Blue,
				ProgressBackgroundColor = xColor.Gray,
				WidthRequest = 50,
				HeightRequest = 50
			};

			StackLayout child = new StackLayout {
				Padding = 0,
				Spacing = 0,
				Children = {
					pageHeader
				}
			};

			AbsoluteLayout parent = new AbsoluteLayout ();
			pageHeader.Children.Add (title, new Rectangle (0.5,0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			parent.Children.Add (pictureBackground, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (child, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (progressBar, new Rectangle (0.5, 0.5, 0.3, 0.3), AbsoluteLayoutFlags.All);

			this.MainPage = new ContentPage { Content = parent };
			CheckUser ();
		}

		public async void CheckUser() 
		{
			ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init ();
			await Task.Run(() => ParseClient.Initialize("IfCbhdnMl0FJGe34xwSlTSBYmYN3ESO1HhBnmOGl", "sVEkUfMlgz0uSdO6uRZrAZfhuvWeUxDey8tYjBvC"));

			if (ParseUser.CurrentUser != null)
			{
				//Check if user is logged in : They Are
				//Force them to the dashboard
				LoginSaved();
			}
			else
			{
				//Check if user is logged in : They Are Not
				//Force them to login

				List<ContentPage> pages = new List<ContentPage> (0);

				pages.Add (new Login ());
				pages.Add (new Register ());

				this.MainPage = new CarouselPage {
					Children = {
						pages [0],
						pages [1]
					}
				};
			}
		}

		public void LogoutUser() {
			/*
			 * Creating a new List of ContentPages, calling it pages, and adding 
			 * Login and Register to the List
			 */
			List<ContentPage> pages = new List<ContentPage> (0);

			pages.Add (new Login ());
			pages.Add (new Register ());

			if (ParseUser.CurrentUser != null)
			{
				//Check if user is logged in : They Are
				//Force them to the dashboard
				LoginSaved();
			}
			else
			{
				//Check if user is logged in : They Are Not
				//Force them to login
				MainPage = new CarouselPage {
					Children = {
						pages [0],
						pages [1]
					}
				};
			}
		}

		protected override void OnStart ()
		{
			/*
			 * Triggered when the application is opened
			 */
		}

		protected override void OnSleep ()
		{
			/*
			 * Triggered when the application has slept
			 */		
		}

		protected override void OnResume ()
		{
			/*
			 * Triggered when the application is resumed from sleep, 
			 * closed but not shut down, or switched-to.
			 */		
		}

		/*
		 * Called from the Login Page, this will only be called every
		 * time a user logs in. It will display the rules, TOS, and PP to
		 * said user. Then log them into the dashboard.
		 */
		public async void LoginStandard () 
		{
			ParseUser user = await ParseUser.Query.GetAsync(ParseUser.CurrentUser.ObjectId);
			Functions.Properties = new userStatistics ();
			Functions.Properties.FullName = user.Get<string>("name");
			Functions.Properties.UserName = user.Get<string>("username");
			Functions.Properties.UserCommunity = user.Get<string> ("community");

			/*
			 * Creating a new List of ContentPages, calling it pages, and adding Profile, 
			 * Community, and Communitites to the created list
			 */
			List<ContentPage> pages = new List<ContentPage> (0);

			pages.Add (new Profile ());
			pages.Add (new Community ());
			pages.Add (new Person ());

			/*
			 * MainPage is the container of all the UI, it is native in Xamarin.Forms
			 */
			MainPage = new CarouselPage {
				Children = {
					pages [0],
					pages [1],
					pages [2]
				}
			};
		}

		/*
		 * Called from the Login Page, this will only be called every
		 * time a user logs in. It will display the rules, TOS, and PP to
		 * said user. Then log them into the dashboard.
		 */
		public async void LoginSaved () 
		{
			Functions.Properties = new userStatistics ();
			Functions.Properties.FullName = ParseUser.CurrentUser.Get<string>("name");
			Functions.Properties.UserName = ParseUser.CurrentUser.Get<string>("username");
			Functions.Properties.UserCommunity = ParseUser.CurrentUser.Get<string> ("community");

			/*
			 * Creating a new List of ContentPages, calling it pages, and adding Profile, 
			 * Community, and Communitites to the created list
			 */
			List<ContentPage> pages = new List<ContentPage> (0);

			pages.Add (new Profile ());
			pages.Add (new Community ());
			pages.Add (new Person ());

			/*
			 * MainPage is the container of all the UI, it is native in Xamarin.Forms
			 */
			MainPage = new CarouselPage {
				Children = {
					pages [0],
					pages [1],
					pages [2]
				}
			};
		}
	}
}

