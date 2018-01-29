using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.BlueTooth.Mock;
using Enigma.Model;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Enigma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    {
        private List<IDevice> devices;
        private bool busy = false;
        private bool Clicked = false;


        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public bool IsClicked
        {
            get { return Clicked; }
            set
            {
                if (Clicked == value)
                    return;

                Clicked = value;
                OnPropertyChanged("IsClicked");
            }
        }



        public ConnectPage()
        {
            InitializeComponent();  
        }

        async void BluetoothConnecting()
        {
            if (!this.IsBusy)
            {
                try
                {
                    this.IsBusy = true;
                    await Task.Run(() => {BluetoothManage();});
                }
                finally
                {
                    this.IsBusy = false;
                }
            }
        }

        public void BluetoothManage()
        {
            //InitializeBluetooth();

            var manager = DependencyService.Get<IBlueToothManager>();
            manager.initializeBluetooth();
            //var device = manager.Connect();
            //var buffer = SLIPPacket.ToByteArray(new Parameter()
            //{
            //Id = 1,
            //Value = 0
            //});
            //device.Write(buffer, 0, buffer.Length);

            //var hmm = device.BytesToRead;
        }

        private void BluetoothConnect(object sender, EventArgs e)
        {
            if (!this.IsClicked)
            {
                this.IsClicked = true;
            }
            BluetoothConnecting();
        }

        private void OnButtonTapped(object sender, EventArgs e)
        {
            StackLayout item1 = new StackLayout();
            Label label1 = new Label();

            label1.Text = "item 2";
            
            item1.Children.Add(label1);

            Stacklist.Children.Add(item1);
        }
    }
}