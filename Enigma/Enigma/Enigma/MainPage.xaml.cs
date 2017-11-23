using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Enigma
{
    public partial class MainPage : TabbedPage
    {
        private SettingsPage setting;
        public MainPage()
        {
            InitializeComponent();
            setting = new SettingsPage();
        }
        


        public void BtnPageChangeSettings(object sender, EventArgs e)
        {

            this.CurrentPage = CurrentPage.FindByName<ContentPage>("SettingsPage");
        }

        private void BtnChangePageRotera(object sender, EventArgs e)
        {
            this.CurrentPage = CurrentPage.FindByName<ContentPage>("RotationPage");
        }

        private void BtnPageChangeDiagnostic(object sender, EventArgs e)
        {
            this.CurrentPage = CurrentPage.FindByName<ContentPage>("DiagnosticsPage");
        }

        private void BtnPageChangeMap(object sender, EventArgs e)
        {
            this.CurrentPage = CurrentPage.FindByName<ContentPage>("MapsPage");
        }
    }
}
