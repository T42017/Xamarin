using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Enigma
{
    public partial class MainPage : TabbedPage
    {
        private ModelView modelView = new ModelView();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = modelView;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            modelView.ActuatorRotation += 4f;
        }
    }
}
