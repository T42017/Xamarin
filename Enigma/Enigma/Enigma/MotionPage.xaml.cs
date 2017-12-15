using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MotionPage : ContentPage
	{
		public MotionPage ()
		{
			InitializeComponent();
            BindingContext = new MotionViewModel();
		}
	}
}