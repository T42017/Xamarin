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
		            new Position(55.686047, 13.185772), Distance.FromMiles(1.0)))
		    {
		        IsShowingUser = true,
		        HeightRequest = 320,
		        WidthRequest = 200,
		        VerticalOptions = LayoutOptions.CenterAndExpand
		    };
		    var position = new Position(55.686047, 13.185772);
		    var pin = new Pin
		    {
		        Type = PinType.Place,
		        Position = position,
		        Label = "NTI-Gymnasiet",
		        Address = "Sankt Lars väg 11, 222 70 Lund"
            };

		    var position2 = new Position(55.376692, 13.145149);
		    var pin2 = new Pin
		    {
		        Type = PinType.Place,
		        Position = position2,
		        Label = "Trelleborgen",
		        Address = "Västra Vallgatan 6, 231 64 Trelleborg"
            };

            map.Pins.Add(pin);
		    map.Pins.Add(pin2);
            //var cp = new ContentPage
            //{
            //    Content = map,
            //};

            this.Content = map;
        }
	}
}