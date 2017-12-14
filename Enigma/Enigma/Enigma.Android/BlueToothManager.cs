using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Enigma.BlueTooth.Mock;
using MvvmCross.Platform;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using Xamarin.Forms;

[assembly: Dependency(typeof(Enigma.Droid.BlueToothManager))]
namespace Enigma.Droid
{
    public class BlueToothManager : Enigma.BlueTooth.Mock.IBlueToothManager
    {
        private IBluetoothLE ble;
        private IAdapter adapter;
        List<IDevice> deviceList = new List<IDevice>();

        public void initializeBluetooth()
        {

            ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;


            var state = ble.State;

            ble.StateChanged += (s, e) =>
            {

            };

            Scan();
        }

        async Task Scan()
        {
            adapter.ScanTimeout = 5000;
            adapter.ScanMode = ScanMode.Balanced;
            adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
            await adapter.StartScanningForDevicesAsync();
            Log.WriteLine(LogPriority.Info, "Info", deviceList[0].Name);

            Connecting();
            var services = await deviceList.FirstOrDefault().GetServicesAsync();
            foreach (var service in services)
            {
                Log.WriteLine(LogPriority.Info, "Info", service.Name );
            }

        }


        async Task Connecting()
        {
            try
            {
                Log.WriteLine(LogPriority.Info, "Info", "Connecting...");
                await adapter.ConnectToDeviceAsync(deviceList.FirstOrDefault());
            }
            catch (DeviceConnectionException e)
            {
                Log.WriteLine(LogPriority.Warn, "Warning", "Could not connect to device");
            }
        }

        public IBlueToothDevice Connect()
        {
            throw new NotImplementedException();
        }
    }
}