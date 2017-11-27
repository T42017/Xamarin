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


    }
}
