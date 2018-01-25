using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Enigma.Common;
using Enigma.Messages;
using Enigma.Model;
using Enigma.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace Enigma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiagnosticsPage : ContentPage
    {
        
        public DiagnosticsPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<DiagnosticsViewModel, ShowInfoMessage>(this, "ShowInfo", OnShowInfoMessage);

            BindingContext = new DiagnosticsViewModel();
            
        }

        private void OnShowInfoMessage(DiagnosticsViewModel sender, ShowInfoMessage message)
        {
            DisplayAlert(message.Title, message.Message, message.ButtonText);
        }

        private void saveclick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("mommyhelpme ");
            var locator = CrossGeolocator.Current;
            string text,xmlcode;
            var _currentLocation= locator.GetPositionAsync(TimeSpan.FromSeconds(5)); 
            xmlcode = @"<Root><Xcordinate>"+_currentLocation+"</Xcordinate></Root>";
            System.Diagnostics.Debug.WriteLine(xmlcode);
            DependencyService.Get<ISaveAndLoad>().SaveText("statistics.xml", xmlcode);
        }
    }
}