using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enigma.BlueTooth.Mock;
using Enigma.Model;
using Xamarin.Forms;

namespace Enigma
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Enigma.ConnectPage();

            
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

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
