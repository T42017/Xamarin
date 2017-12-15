using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Enigma
{
    public class ActuatorControl : Image
    {
        public static readonly BindableProperty ActuatorRotationProperty = BindableProperty.Create(
            propertyName: "ActuatorRotation",
            returnType: typeof(float),
            declaringType: typeof(ActuatorControl),
            defaultValue: 0f,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ActuatorRotationPropertyChanged);

        public static readonly BindableProperty ActuatorListProperty = BindableProperty.Create(
            propertyName: "ActuatorList",
            returnType: typeof(List<float>),
            declaringType: typeof(ActuatorControl),
            defaultValue: new List<float>(),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ActuatorListPropertyChanged);

        public static readonly BindableProperty EnableProperty = BindableProperty.Create(
            propertyName: "Enabled",
            returnType: typeof(bool),
            declaringType: typeof(ActuatorControl),
            defaultValue: true,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: EnablePropertyChanged);

        private static void EnablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ActuatorControl)bindable;
            control.Enabled = (bool) newValue;
        }

        private static void ActuatorListPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ActuatorControl)bindable;
            control.ActuatorList = (List<float>) newValue;
        }

        private static void ActuatorRotationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ActuatorControl) bindable;
            control.Rotation = (float) newValue;
        }

        public bool Enabled
        {
            get => (bool) GetValue(EnableProperty);
            set => SetValue(EnableProperty, value);
        }

        public List<float> ActuatorList
        {
            get => (List<float>) GetValue(ActuatorListProperty);
            set => SetValue(ActuatorListProperty, value);
        }

        public float ActuatorRotation
        {
            get => (float) GetValue(ActuatorRotationProperty);
            set => SetValue(ActuatorRotationProperty, value);
        }

        public ActuatorControl()
        {
            Source = "ARA_ratt.png";
        }
    }
}
