/*
 * Created By Nick Kunes March 31st 2015
 */

using System;
using Xamarin.Forms;
using Xamarin.Facebook;

namespace SocialNetwork.Droid
{
	public class Person : ContentPage
	{
		public Person ()
		{

			Label title = new Label {
				Text = "THEM",
				FontSize = 25,
				FontAttributes = FontAttributes.Bold,
				TextColor = xColor.TextGray };

			BoxView header = new BoxView
			{
				Color = xColor.Gray,
				WidthRequest = 5000,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.Center };

			AbsoluteLayout pageHeader = new AbsoluteLayout {
				Children = {
					header
				}
			};

			AbsoluteLayout.SetLayoutFlags (title,
				AbsoluteLayoutFlags.PositionProportional);

			AbsoluteLayout.SetLayoutBounds (title,
				new Rectangle (0.5,
					0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			pageHeader.Children.Add (title);

			/*
			 * Basic Spacer, 50 thickness
			 * on the bottom
			 */
			Frame _spacer = new Frame {
				Padding = new Thickness (0, 0, 0, 50),
			};

			/*
			 * Creating a new StackLayout. A StackLayout does exactly what it sounds like,
			 * it stacks everything you add to it perfectly, in order, from top to bottom.
			 * Adding it's children so they appear on the UI.
			 */
			Content = new StackLayout {
				Children = {
					pageHeader
				}
			};

		}
	}
}




