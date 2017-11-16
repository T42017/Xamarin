using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Enigma.BlueTooth.Mock;
using Xamarin.Forms;

[assembly: Dependency(typeof(Enigma.Droid.BlueToothManager))]
namespace Enigma.Droid
{
    public class BlueToothManager : Enigma.BlueTooth.Mock.BlueToothManager
    {
    }
}