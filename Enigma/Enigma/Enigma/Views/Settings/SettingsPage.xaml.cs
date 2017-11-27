using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.Message;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsView sView;

        public SettingsPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SettingsView, ShowInfoMessage>(this, "ShowInfo", OnShowInfoMessage);

            var vm = new SettingsView();
            BindingContext = vm;
            sView = vm;
        }

        private void OnShowInfoMessage(SettingsView sender, ShowInfoMessage message)
        {
            DisplayAlert(message.Title, message.Message, message.ButtonText);
        }
    }
}