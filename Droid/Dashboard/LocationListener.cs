using System.Linq;
using System.Text;
using Android.App;
using Android.Locations;
using Android.OS;
using Android.Widget;
using Java.IO;

namespace SocialNetwork.Droid
{
	public class LocationListener : Activity, ILocationListener
	{
		public LocationListener ()
		{
			//Nothing
		}

		#region ILocationListener implementation

		public void OnLocationChanged (Location location)
		{
			if (Functions.canRefresh) {
				Functions.canRefresh = false;
				Functions.GetNearbyCities (location);
			}
		}

		public void OnProviderDisabled (string provider)
		{
			//Nothing
		}

		public void OnProviderEnabled (string provider)
		{
			//Nothing
		}

		public void OnStatusChanged (string provider, Availability status, Android.OS.Bundle extras)
		{
			//Nothing
		}

		#endregion
	}
}

