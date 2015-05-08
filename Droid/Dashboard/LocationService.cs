using System;
using Android.OS;
using Android.App;
using Android.Locations;

namespace SocialNetwork.Droid
{
	public class LocationServiceBinder : Binder
	{
		public LocationService Service
		{
			get { return this.service; }
		} protected LocationService service;

		public bool IsBound { get; set; }            
		public LocationServiceBinder (LocationService service) { this.service = service; }
	}

	[Service]public class LocationService : Service, ILocationListener
	{
		IBinder binder;
		public override IBinder OnBind (Intent intent)
		{
			binder = new LocationServiceBinder (this);
			return binder;
		}

		public override StartCommandResult OnStartCommand (Intent intent, StartCommandFlags flags, int startId)
		{
			return StartCommandResult.Sticky;
		}
	}
}

