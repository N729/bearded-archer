using System;
using Android.App;
using Android;
using Parse;
using Xamarin.Forms;
using Xamarin.Controls;
using System.Collections.Generic;
using Android.Locations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using Geolocator.Plugin;

namespace SocialNetwork.Droid
{

	public class Functions
	{
		public static userStatistics Properties;
		public static TableSection overControlledListSource = new TableSection();

		public Functions ()
		{

		}

		static public void OnButtonClicked(object sender, EventArgs args)
		{
			if (((Button)sender).Text == "Logout") {
				try {
					ParseUser.LogOutAsync ();
					AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 3, 0);
					AlertCenter.Default.BackgroundColor = Android.Graphics.Color.LimeGreen;
					AlertCenter.Default.PostMessage ("", "", Resource.Drawable.correct8);
					//Logout was successful, move them back home.
					BackToHome ();

				} catch (ParseException e) {
					AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 3, 0);
					AlertCenter.Default.BackgroundColor = Android.Graphics.Color.Red;
					AlertCenter.Default.PostMessage ("", "", Resource.Drawable.remove11);
					//Do nothing, logout was not successful.
				}
			} else if (((Button)sender).Text == "Settings") {
				//TODO : ADD SETTINGS
			}
		}

		static public void BackToHome() {
			App.Current.LogoutUser ();
		}

		static public async void LoadCommunity () {
			//TODO: LOAD USER COMMUNITY
		}

		static public async void LoadNearbyCommunities () {

			/*
			 * Clear our list of cities, we don't want doubles in-case of a literal
			 * glitch. Which seems to be happening. Until one of us finds the source
			 * of said glitch. A clear must occur every load, sadly this lags the UI
			 * but oh well.
			 */
			Functions.overControlledListSource.Clear ();

			/*
			 * Inititate the progress bar animation sequence. Pass in our progressBar for use
			 * in the method.
			 */
			StartProgressAsync (Community.progressBar);

			try {
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;
				var position = await locator.GetPositionAsync (timeout: 10000);
				GetNearbyCities (position);
			} 
			catch (Geolocator.Plugin.Abstractions.GeolocationException ex) {
				/*
				 * TODO: Inform the user their GPS is off. Prompt them to enter
				 * the settings application to turn it on. Do not ask to turn
				 * it on for them, we don't need the extra permissions.
				 */
			}
		}

		public static async void StartProgressAsync (CircularProgress progress) {
			for (float i = 200; i > progress.Progress; i += -1f) {
				await Task.Delay (5);
				progress.Progress += 1f;
			}

			/*
			 * Once the progress bar has gone around a full once, it does
			 * something cool : Clears itself and then restarts it's own
			 * method from within itself. Pretty cool loop, eh? Then passes
			 * itself into itself. LoopCeption.
			 */
			progress.Progress = 0;
			StartProgressAsync (progress);
		}

		public static async void GetNearbyCities (Geolocator.Plugin.Abstractions.Position location) {
			/*
			 * Store the location in our userStatistics for global access, even know
			 * we will never globally access it. It's good practice. Then add the lat/
			 * long to a Vector2 for use locally, in the GeoNames API
			 */
			Properties.UserPosition = new Geolocator.Plugin.Abstractions.Position(location);
			Vec2 userPosition = new Vec2 (Properties.UserPosition.Latitude, Properties.UserPosition.Longitude);

			/*
			 * Using the URL, fetch all the cities in the userPosition's 10 kilometer
			 * radius. This is our call to the geonames API
			 */
			string url = "http://api.geonames.org/findNearbyPlaceNameJSON?lat=" +
				userPosition.X +
				"&lng=" +
				userPosition.Y +
				"&radius=10" +
				"&username=n7292";

			/*
			 * Deseralize the JSON response. Go from Value -> Object -> Array. JSON has an
			 * awkward way of doing things so it took a bit of casting.
			 */
			JsonObject json;
			json = (JsonObject)await FetchCitiesAsync (url);
			JsonArray cityPack;
			cityPack = (JsonArray)json ["geonames"];

			/*
			 * Destroy the progress bar when loading of cities is finished.
			 */
			Community.parent.Children.Remove (Community.progressBar);
			Community.parent.Children.Remove (Community.loading);

			/*
			 * Loop through all the geonames information gathered, and only display
			 * the toponymName (the city name), and the countryCode (Ex : US)
			 */
			for (int i = 0; i < cityPack.Count; i++) {
				if ((cityPack [i] ["toponymName"]).ToString().Contains ("(historical)")) {
					/*
					 * Nothing, we don't want a historical on the list, they're simply
					 * historical, old, and non-existent anymore.
					 */

				} else {
					Functions.overControlledListSource.Add (
						new DataCell (
							cityPack [i] ["toponymName"], 
							cityPack [i] ["countryCode"], 
							2
						));
				}
			}
		}

		public static async Task<JsonValue> FetchCitiesAsync (string url)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ())
			{
				using (Stream stream = response.GetResponseStream ())
				{
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					return jsonDoc;
				}
			}
		}
	}
}

