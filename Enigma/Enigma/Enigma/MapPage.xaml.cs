using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Enigma
{
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
		   
		    InitializeComponent();
		    var map = new Map()
		    {
               
                MyLocationEnabled = true,  
		        VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
		    };
            
		    var position = new Position(55.686047, 13.185772);

		    var pin = new Pin()
		    {   
		        Type = PinType.Place,
		        Position = position,
                Icon = BitmapDescriptorFactory.FromBundle("Mapmarker.png"),
		        Label = "NTI-Gymnasiet",               
		        Address = "Sankt Lars väg 11, 222 70 Lund"
            };

		    map.Pins.Add(pin);
		    map.UiSettings.CompassEnabled = true;
		    map.UiSettings.MyLocationButtonEnabled = true;
		    map.UiSettings.ZoomControlsEnabled = true;
		    var position1= new Position(56.172442, 14.860493);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position1, Distance.FromKilometers(150)));
		    this.Content = map;
        }
	}
}