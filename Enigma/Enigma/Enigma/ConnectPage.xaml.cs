using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    {
        public ConnectPage()
        {
            InitializeComponent();

            
        }

        private void BluetoothConnect(object sender, EventArgs e)
        {
        }

        private void Continue(object sender, EventArgs e)
        {
        }
    }
}