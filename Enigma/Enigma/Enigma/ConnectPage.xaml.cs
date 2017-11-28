using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.BlueTooth.Mock;
using Enigma.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    {
        private bool busy = false;

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
            IBlueToothManager manager = DependencyService.Get<IBlueToothManager>();
            var device = manager.Connect();
            var buffer = SLIPPacket.ToByteArray(new Parameter()
            {
                Id = 1,
                Value = 0
            });
            device.Write(buffer, 0, buffer.Length);

            var hmm = device.BytesToRead;
        }

        private void BluetoothConnect(object sender, EventArgs e)
        {
            BluetoothConnecting();
        }
    }
}