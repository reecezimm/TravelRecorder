using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();

            GetPermissions();
		}

        private async void GetPermissions()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
            if(status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse))
                {
                    await DisplayAlert("Need your location", "We need it location now", "Ok");
                }

                var r = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                if (r.ContainsKey(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse))
                    status = r[Plugin.Permissions.Abstractions.Permission.LocationWhenInUse];           
            }

            if(status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                locationMaps.IsShowingUser = true;
            }
        }
	}
}