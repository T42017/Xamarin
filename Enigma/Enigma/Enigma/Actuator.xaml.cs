using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma
{
    public partial class Actuator : ContentView
    {
        public static readonly BindableProperty ActuatorRotationProperty = BindableProperty.Create(
            propertyName: "ActuatorRotation",
            returnType: typeof(int),
            declaringType: typeof(Actuator),
            defaultValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ActuatorRotationPropertyChanged);

        private static void ActuatorRotationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Actuator)bindable;
            control.CircleImage.Rotation = (int)newValue * -1;
        }

        public Actuator()
        {
            InitializeComponent();
        }

        public int ActuatorRotation
        {
            get { return (int)GetValue(ActuatorRotationProperty); }
            set { SetValue(ActuatorRotationProperty, value); }
        }

    }
}