using Enigma.Messages;
using Enigma.ViewModels;
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
            MessagingCenter.Subscribe<SettingsViewModel, ShowInfoMessage>(this, "ShowInfo", OnShowInfoMessage);

            BindingContext = ViewModelLocator.Current.SettingsViewModel;
        }

        private void OnShowInfoMessage(SettingsViewModel sender, ShowInfoMessage message)
        {
            DisplayAlert(message.Title, message.Message, message.ButtonText);
        }
    }
}