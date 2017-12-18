using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Util;
using Enigma.BlueTooth.Mock;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using Xamarin.Forms;
using BlueToothManager = Enigma.Droid.BlueToothManager;

[assembly: Dependency(typeof(BlueToothManager))]

namespace Enigma.Droid
{
    public class BlueToothManager : IBlueToothManager
    {
        private static Guid specificService = new Guid("e093f3b5-00a3-a9e5-9eca-40016e0edc24");
        private readonly List<IDevice> deviceList = new List<IDevice>();
        private IAdapter adapter;
        private IBluetoothLE ble;
        private ICharacteristic theOne;

        public void initializeBluetooth()
        {
            ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;


            var state = ble.State;

            ble.StateChanged += (s, e) => { };

            Scan();
        }

        public IBlueToothDevice Connect()
        {
            throw new NotImplementedException();
        }


        private async Task Scan()
        {
            adapter.ScanTimeout = 5000;
            adapter.ScanMode = ScanMode.Balanced;
            adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
            await adapter.StartScanningForDevicesAsync();

            Log.WriteLine(LogPriority.Info, "Info", deviceList[0].Name);

            await Connecting();


            var services = await deviceList.FirstOrDefault().GetServicesAsync();

            foreach (var service in services)
            {
                Log.WriteLine(LogPriority.Info, "Info", service.Id.ToString());
                var characts = service.GetCharacteristicsAsync();
                foreach (var charact in characts.Result)
                {
                    Log.WriteLine(LogPriority.Info, "CharName", charact.Name);
                    Log.WriteLine(LogPriority.Info, "CharUuid", charact.Uuid);
                    if (charact.Uuid == "e093f3b5-00a3-a9e5-9eca-40036e0edc24")
                    {
                        theOne = charact;
                        await theOne.WriteAsync(new[] {(byte) 'H'});
                    }
                }
            }
        }


        private async Task Connecting()
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
    }
}