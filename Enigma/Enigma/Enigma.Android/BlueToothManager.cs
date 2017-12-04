using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Enigma.BlueTooth.Mock;
using MvvmCross.Platform;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;
using IAdapter = Android.Widget.IAdapter;

[assembly: Dependency(typeof(Enigma.Droid.BlueToothManager))]
namespace Enigma.Droid
{
    public class BlueToothManager : Enigma.BlueTooth.Mock.BlueToothManager
    {
        public void initializeBluetooth()
        {
            var ble = Mvx.Resolve<IBluetoothLE>();
            var adapter = Mvx.Resolve<IAdapter>();
        }


    }
}