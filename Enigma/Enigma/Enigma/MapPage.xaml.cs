using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Enigma
{
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
		    InitializeComponent();
		    var map = new Map(
		        MapSpan.FromCenterAndRadius(
		            new Position(55.696922, 13.195254), Distance.FromMiles(1.0)))
		    {
		        IsShowingUser = true,
		        HeightRequest = 320,
		        WidthRequest = 200,
		        VerticalOptions = LayoutOptions.CenterAndExpand
		    };
		    var position = new Position(55.696922, 13.195254);
		    var pin = new Pin
		    {
		        Type = PinType.Place,
		        Position = position,
		        Label = "custom pin",
		        Address = "custom detail info"
		    };
		    map.Pins.Add(pin);
		    //var cp = new ContentPage
		    //{
		    //    Content = map,
		    //};

		    this.Content = map;
        }
	}
}