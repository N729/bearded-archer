using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.Locations;

namespace SocialNetwork.Droid
{
	public class userStatistics : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string _fullName;
		public string FullName
		{
			get { return _fullName; }
			set
			{
				if (value.Equals(_fullName, StringComparison.Ordinal))
				{
					// Nothing to do - the value hasn't changed;
					return;
				}
				_fullName = value;
				OnPropertyChanged();

			}
		}

		string _userName;
		public string UserName
		{
			get { return _userName; }
			set
			{
				if (value.Equals(_userName, StringComparison.Ordinal))
				{
					// Nothing to do - the value hasn't changed;
					return;
				}
				_userName = value;
				OnPropertyChanged();

			}
		}

		string _joinedCommunity;
		public string UserCommunity
		{
			get { return _joinedCommunity; }
			set
			{
				if (value.Equals(_joinedCommunity, StringComparison.Ordinal))
				{
					// Nothing to do - the value hasn't changed;
					return;
				}
				_joinedCommunity = value;
				OnPropertyChanged();

			}
		}

		Geolocator.Plugin.Abstractions.Position _userPosition;
		public Geolocator.Plugin.Abstractions.Position UserPosition
		{
			get { return _userPosition; }
			set
			{
				_userPosition = value;
				OnPropertyChanged();
			}
		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

