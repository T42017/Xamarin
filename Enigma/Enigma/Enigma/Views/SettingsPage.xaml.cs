using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.Messages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SettingsView, ShowInfoMessage>(this, "ShowInfo", OnShowInfoMessage);

            var vm = new SettingsView();
            BindingContext = vm;
        }

        private void OnShowInfoMessage(SettingsView sender, ShowInfoMessage message)
        {
            DisplayAlert(message.Title, message.Message, message.ButtonText);
        }
    }
}