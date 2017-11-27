using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Enigma.BlueTooth.Mock;
using Enigma.Model;
using Enigma.Resources;
using Xamarin.Forms;

namespace Enigma
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ConnectPage();
            

            var assembly = typeof(AppResource).GetTypeInfo().Assembly; // "EmbeddedImages" should be a class in your app
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            //AppResource.Culture = new CultureInfo("en-GB");
            //IBlueToothManager manager = DependencyService.Get<IBlueToothManager>();
            //var device = manager.Connect();
            //var buffer = SLIPPacket.ToByteArray(new Parameter()
            //{
            //    Id = 1,
            //    Value = 0
            //});

            //device.Write(buffer, 0, buffer.Length);

            //var hmm = device.BytesToRead;

            //MainPage = new ContentPage()
            //{
            //    Content = new Label()
            //    {
            //        Text = AppResource.PowerUpsText,
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center,
            //        TextColor = Color.Red,
            //        FontSize = 22
            //    }
            //};
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
