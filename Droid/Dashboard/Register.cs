using System;
using Xamarin.Forms;
using Parse;
using Xamarin.Controls;

namespace SocialNetwork.Droid
{
	public class Register : ContentPage
	{
		public Register () {

			var realnameEntry = new Entry {		
				BackgroundColor = xColor.transWhite,
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center,
				Placeholder = "fullname (min. 6)"
			};

			var usernameEntry = new Entry {		
				BackgroundColor = xColor.transWhite,
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center,
				Placeholder = "username (min. 4)"
			};

			var passwordEntry = new Entry {
				Placeholder = "password (min. 4)",
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center,
				IsPassword = true,
				BackgroundColor = xColor.transWhite
			};

			var phonenumberEntry = new Entry {
				Placeholder = "phone # (min. 10)",
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = xColor.transWhite
			};

			Label _hint = new Label {
				Text = "already registered? swipe ←",
				FontSize = 14,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.White,
				HorizontalOptions = LayoutOptions.Center
			};

			Label _disclaimer = new Label {
				Text = "by registering, you are agreeing to follow the",
				FontSize = 11,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.White,
				HorizontalOptions = LayoutOptions.Center
			};

			Label __disclaimer = new Label {
				Text = "terms of service and privacy policy",
				FontSize = 11,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.White,
				HorizontalOptions = LayoutOptions.Center
			};

			/*
			 * Create a new button called _register, this will be our main button
			 * that once clicked, registers the user. The properties are filled out
			 * and the color is gray, like everything else. Then we add an onClick
			 * event that handles the passing and populating of variables for the
			 * Async Register function. Explained down there.
			 */
			Button _register = new Button {
				Text = "REGISTER",
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = xColor.Gray,
				WidthRequest = 250,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center
			};
			_register.Clicked += (sender, ea) => {
				string username = usernameEntry.Text;
				string password = passwordEntry.Text;
				string phonenumber = phonenumberEntry.Text;
				string name = realnameEntry.Text;
				RegisterAsynchronous(username, password, phonenumber, name);

			};

			/*
			 * Register Button Spacer, 30 thickness on the top, 5 thickness
			 * on the bottom
			 */
			Frame __register = new Frame {
				Padding = new Thickness (0, 30, 0, 5),
				Content = _register
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
			Frame ______spacer = new Frame {
				Padding = new Thickness (0, 0, 0, 55)
			};

			/*
			 * Spacer, 50 thickness on the bottom
			 */
			Frame _______spacer = new Frame {
				Padding = new Thickness (0, 0, 0, 50)
			};

			/*
			 * Spacer, 5 thickness on the bottom
			 */
			Frame ____spacer = new Frame {
				Padding = new Thickness (0, 5, 0, 0)
			};

			/*
			 * Spacer, 5 thickness on the bottom
			 */
			Frame _____spacer = new Frame {
				Padding = new Thickness (0, 5, 0, 0)
			};

			Label title = new Label {
				Text = "REGISTER",
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

			/*
			 * Creating a new StackLayout. A StackLayout does exactly what it sounds like,
			 * it stacks everything you add to it perfectly, in order, from top to bottom.
			 * Adding it's children so they appear on the UI.
			 */
			StackLayout child = new StackLayout {
				Padding = 0,
				Spacing = 0,
				Children = {
					pageHeader,
					_______spacer,
					realnameEntry,
					_____spacer,
					usernameEntry,
					__spacer,
					passwordEntry,
					____spacer,
					phonenumberEntry,
					__register,
					_disclaimer,
					__disclaimer,
					______spacer,
					_hint
				}
			};

			AbsoluteLayout parent = new AbsoluteLayout ();
			pageHeader.Children.Add (title, new Rectangle (0.5,0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			parent.Children.Add (pictureBackground, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (child, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			Content = parent;
		}

		async void RegisterAsynchronous(string username, string password, string phonenumber, string fullname) {
			try {
				
				//Do a check to make sure that the inputted credentials fit the required minimum
				//letter count
				if(username.Length > 3 && password.Length > 3 && phonenumber.Length > 9 && fullname.Length > 5) {

					//create a new parse user
					var user = new ParseUser()
					{
						//Defaultly, Parse only allows signup with a user and pass and email.
						//Since we are not using email, we will not assign it.
						Username = username,
						Password = password
					};

					//But we can add other fields to the registration here. Yet, these
					//are forced to be optional. But the if function at the beginning
					//checking for string lenghts forces them to be filled, effectivley
					//solving that problem.
					user["phone"] = phonenumber;
					user["name"] = fullname;
					user["community"] = "null";

					//Call the parse server to signup the new user
					await user.SignUpAsync();

					// Registration was successful
					OnRegisterSuccess();
				} else {
					//If not all the spots are filled, throw an exception so we can catch
					//it in the catch statement which will throw them the red x error
					throw(new Exception("Not enough characters!"));
				}
			} catch (Exception e) {
				// The Register failed. Process it.
				OnRegisterFail(e);
			}
		}

		/*
		 * Register was a success, route the user to the dashboard.
		 */
		void OnRegisterSuccess() {
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 0, 500);
			AlertCenter.Default.BackgroundColor = Android.Graphics.Color.LimeGreen;
			AlertCenter.Default.PostMessage ("null", "null", Resource.Drawable.correct8);
		}

		/*
		 * Register was a fucking failure. Fuck the fuck off. Fucking
		 * process the fucked up exception. Fuck.
		 */
		void OnRegisterFail(Exception e) {
			//Failed Register, process the exception.
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 0, 500);
			AlertCenter.Default.BackgroundColor = Android.Graphics.Color.Red;
			AlertCenter.Default.PostMessage ("null", "null", Resource.Drawable.remove11);
		}
	}
}


