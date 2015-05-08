/*
 * Created By Nick Kunes March 31st 2015
 */

using System;
using Xamarin.Forms;
using Xamarin.Facebook;
using System.Collections.Generic;

namespace SocialNetwork.Droid
{
	public class Profile : ContentPage
	{
		struct Section {
			public string fullName;
			public string userName;
		}

		public Profile ()
		{
			//BindingContext = properties;

			Label title = new Label {
				Text = "ME",
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

			ImageCircle.Forms.Plugin.Abstractions.CircleImage picture = new ImageCircle.Forms.Plugin.Abstractions.CircleImage {
				BorderColor = xColor.Gray,
				BorderThickness = 25,
				Source = "placeholder.jpg",
				WidthRequest = 250,
				HeightRequest = 250
			};

			AbsoluteLayout pageHeader = new AbsoluteLayout {
				Children = {
					header
				}
			};

			BoxView pictureBackground = new BoxView {
				BackgroundColor = xColor.TextGray,
				WidthRequest = 5000,
				HeightRequest = 5000,
				HorizontalOptions = LayoutOptions.Center
			};

			Frame _spacer = new Frame {
				Padding = 120
			};
					
			var profileList = new TableView {
				Intent = TableIntent.Data,
				Root = {
					new TableSection {
						new DataCell("FullName", "UserName", 1),
						new DataCell("Settings", "", 0),
						new DataCell("Logout", "", 0)
					}
				},
				RowHeight = 60,
			};
				
			StackLayout child = new StackLayout {
				Padding = 0,
				Spacing = 0,
				Children = {
					pageHeader,
					_spacer,
					profileList
				}
			};
					
			AbsoluteLayout parent = new AbsoluteLayout ();
			pageHeader.Children.Add (title, new Rectangle (0.5,0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			parent.Children.Add (pictureBackground, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			parent.Children.Add (picture, new Rectangle (0.5,0.2075, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
			parent.Children.Add (child, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All);
			Content = parent;
		}
	}
}


