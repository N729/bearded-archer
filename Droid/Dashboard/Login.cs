using System;
using Xamarin.Forms;
using Parse;
using Xamarin.Controls;

namespace SocialNetwork.Droid
{
	public class Login : ContentPage
	{
		public Login () {
			
			Label title = new Label {
				Text = "LOGIN",
				FontSize = 25,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.TextGray
			};

			BoxView header = new BoxView {
				Color = xColor.Gray,
				WidthRequest = 5000,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center
			};

			/*
			 * Username input field. Self Explanatory. 
			 */
			var usernameEntry = new Entry {		
				BackgroundColor = xColor.transWhite,
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center,
				Placeholder = "username",
				TextColor = xColor.White
			};

			/*
			 * Password input field. Self Explanatory. 
			 */
			var passwordEntry = new Entry {
				Placeholder = "password",
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center,
				IsPassword = true,
				BackgroundColor = xColor.transWhite,
				TextColor = xColor.White
			};

			/*
			 * Hint label at the bottom to tell the user to swipe
			 * to register. Bold, 14 point font. Centered,
			 * and gray.
			 */
			Label _hint = new Label {
				Text = "not registered? swipe →",
				FontSize = 14,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.White,
				HorizontalOptions = LayoutOptions.Center
			};


			/*
			 * Disclaimer Line 1. Bold, 11 point font. Centered,
			 * and gray.
			 */
			Label _disclaimer = new Label {
				Text = "by logging in, you are agreeing to follow the",
				FontSize = 11,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				TextColor = xColor.White
			};

			/*
			 * Disclaimer Line 2. Bold, 11 point font. Centered,
			 * and gray.
			 */
			Label __disclaimer = new Label {
				Text = "terms of service and privacy policy",
				FontSize = 11,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				TextColor = xColor.White
			};

			/*
			 * Create the login button to handle the login request.
			 * Create a login.Clicked event to handle the true login
			 * request with Parse. Send the credentials, and call a
			 * LogInAsync which checks Parse to see if the user exists
			 * and the credentials are A-OK. If successful, route to
			 * OnLoginSuccess, if not, route to OnLoginFail and pass
			 * the exception. An exception is the response from Parse,
			 * it could be that the user is not connected to the
			 * internet, or their username is wrong. In OnLogin Fail we
			 * will process returned exception.
			 */
			Button _login = new Button {
				Text = "login",
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = xColor.Gray,
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center
			};
			_login.Clicked += (sender, ea) => {
				string username = usernameEntry.Text;
				string password = passwordEntry.Text;
				LoginAsynchronous(username, password);

			};

			/*
			 * Login Button Spacer, 30 thickness on the top, 5 thickness
			 * on the bottom
			 */
			Frame __login = new Frame {
				Padding = new Thickness (0, 30, 0, 5),
				Content = _login
			};

			Frame _userNameCase = new Frame {
				Padding = new Thickness(0, 2, 0, 2),
				Content = usernameEntry
			};

			Frame _passWordCase = new Frame {
				Padding = new Thickness(0, 2, 0, 2),
				Content = passwordEntry
			};

			/*
			 * Spacer, 5 thickness on the top
			 */
			Frame __spacer = new Frame {
				Padding = new Thickness (0, 5, 0, 0)
			};

			/*
			 * Spacer, 50 thickness on the bottom
			 */
			Frame ___spacer = new Frame {
				Padding = new Thickness (0, 0, 0, 105)
			};

			/*
			 * Spacer, 50 thickness on the bottom
			 */
			Frame ____spacer = new Frame {
				Padding = new Thickness (0, 0, 0, 105)
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

			StackLayout child = new StackLayout {
				Padding = 0,
				Spacing = 0,
				Children = {
					pageHeader,
					___spacer,
					_userNameCase,
					__spacer,
					_passWordCase,
					__login,
					_disclaimer,
					__disclaimer,
					____spacer,
					_hint
				}
			};

			AbsoluteLayout parent = new AbsoluteLayout ();
			pageHeader.Children.Add (title, new Rectangle (0.5,0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			parent.Children.Add (pictureBackground, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (child, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			Content = parent;
		}

		async void LoginAsynchronous(string username, string password) {
			try {
				await ParseUser.LogInAsync (username, password);
				// Login was successful.
				OnLoginSuccess();
			} catch (Exception e) {
				// The login failed. Process it.
				OnLoginFail(e);
			}
		}

		/*
		 * Login was a success, route the user to the dashboard.
		 */
		void OnLoginSuccess() {
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 0, 500);
			AlertCenter.Default.BackgroundColor = Android.Graphics.Color.LimeGreen;
			AlertCenter.Default.PostMessage ("", "", Resource.Drawable.correct8);
			App.Current.LoginStandard ();
		}

		/*
		 * Login was a fucking failure. Fuck the fuck off. Fucking
		 * process the fucked up exception. Fuck.
		 */
		void OnLoginFail(Exception e) {
			//Failed Login, process the exception.
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 0, 500);
			AlertCenter.Default.BackgroundColor = Android.Graphics.Color.Red;
			AlertCenter.Default.PostMessage ("", "", Resource.Drawable.remove11);
		}
	}
}


