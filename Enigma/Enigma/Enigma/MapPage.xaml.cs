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
                		        
		        HeightRequest = 320,
		        WidthRequest = 200,
		        VerticalOptions = LayoutOptions.CenterAndExpand
		    };
            
		    var position = new Position(55.696922, 13.195254);
		    var pin = new Pin()
		    {
                
		        Type = PinType.Place,
		        Position = position,
                Icon = BitmapDescriptorFactory.FromBundle("Mapmarker.png"),
		        Label = "custom pin",               
		        Address = "custom detail info"
		    };
		    map.Pins.Add(pin);
		    map.UiSettings.CompassEnabled = true;
		    var position1= new Position(56.172442, 14.860493);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position1, Distance.FromKilometers(150)));
		    this.Content = map;
        }
	}
}