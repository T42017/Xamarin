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
    }
}