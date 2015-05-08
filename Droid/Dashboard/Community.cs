/*
 * Created By Nick Kunes March 31st 2015
 */

using System;
using Xamarin.Forms;

namespace SocialNetwork.Droid
{
	public class Community : ContentPage
	{
		public static CircularProgress progressBar;
		public static Label loading;
		public static AbsoluteLayout parent;
		public static TableView overcontrolledList;
			
		public Community ()
		{
			Label title = new Label {
				Text = "MY BLOCK",
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

			overcontrolledList = new TableView {
				Intent = TableIntent.Data,
				RowHeight = 50,
				Root = { Functions.overControlledListSource }
			};

			Frame _spacer = new Frame {
				Padding = -25
			};

			progressBar = new CircularProgress {
				ProgressColor = xColor.Blue,
				ProgressBackgroundColor = xColor.Gray,
				WidthRequest = 50,
				HeightRequest = 50
			};

			loading = new Label {
				Text = "discovering blocks near you",
				FontSize = 15,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.White 
			};

			StackLayout child = new StackLayout {
				Padding = 0,
				Spacing = 0,
				Children = {
					pageHeader,
					_spacer,
					overcontrolledList
				}
			};
					
			parent = new AbsoluteLayout ();
			pageHeader.Children.Add (title, new Rectangle (0.5,0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			parent.Children.Add (pictureBackground, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (child, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (progressBar, new Rectangle (0.5, 0.5, 0.3, 0.3), AbsoluteLayoutFlags.All);
			parent.Children.Add (loading, new Rectangle (0.5, 0.35, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			Content = parent;

			//Redirect to Entry Point, pass in the user
			Check ();
		}

		public void Check() {
			
			//Do a quick check to see if they're in a community
			if (Functions.Properties.UserCommunity != "null") {

				/*
			    * Destroy the progress bar when loading of cities is finished.
			    */
				Community.parent.Children.Remove (Community.progressBar);
				Community.parent.Children.Remove (Community.loading);

				/*
				 * They Are, load it up -- asynchronously.
				 */
				Functions.LoadCommunity ();

			} else {
				/*
				 * This method will always pass if the first fails, because
				 * well there are only two possible options.
				 * They Are Not, display the nearby's -- asynchronously.
				 */
				Functions.LoadNearbyCommunities ();
			}
		}
	}
}


