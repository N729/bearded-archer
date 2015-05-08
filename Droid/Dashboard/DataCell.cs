using System;
using Xamarin.Forms;

namespace SocialNetwork.Droid
{
	public class DataCell : ViewCell
	{
		public DataCell (string value, string value2, int type)
		{
			if (type == 0) {
				
				Button btn = new  Button {
					FontSize = 16,
					FontAttributes = FontAttributes.Bold,
					BackgroundColor = xColor.Gray,
					Text = value,
					WidthRequest = 100,
					BindingContext = Functions.Properties
				};
				btn.Clicked += (object sender, EventArgs e) => Functions.OnButtonClicked (sender, e);

				View = new StackLayout {
					Padding = 6.5,
					Children = {
						btn
					}
				};
			} else if (type == 1) {
				Label lbl = new Label {
					XAlign = TextAlignment.Center,
					FontAttributes = FontAttributes.Bold,
					FontSize = 16,
					BindingContext = Functions.Properties,
					TextColor = xColor.White
				};
				lbl.SetBinding (Label.TextProperty, "FullName");

				Label lbl1 = new Label {
					XAlign = TextAlignment.Center,
					FontAttributes = FontAttributes.Bold,
					FontSize = 14,
					BindingContext = Functions.Properties,
					TextColor = xColor.White
				};
				lbl1.SetBinding (Label.TextProperty, "UserName");

				View = new StackLayout {
					Spacing = 0,
					Padding = 10,
					Children = {
						lbl,
						lbl1
					}
				};
			} else if (type == 2) {
				Label lbl = new Label {
					XAlign = TextAlignment.Center,
					FontAttributes = FontAttributes.Bold,
					FontSize = 16,
					Text = value,
					TextColor = xColor.White
				};

				Label lbl1 = new Label {
					XAlign = TextAlignment.Center,
					FontAttributes = FontAttributes.Bold,
					FontSize = 14,
					Text = value2,
					TextColor = xColor.White
				};

				View = new StackLayout {
					Spacing = 0,
					Padding = 5,
					Children = {
						lbl,
						lbl1
					}
				};
			}
		}
	}
}

