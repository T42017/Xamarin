using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Enigma.Annotations;

namespace Enigma.ViewModels
{
   public class MotionViewModel: INotifyPropertyChanged
    {
        private float _actuatorRotation;
        public float ActuatorRotation
        {
            get => _actuatorRotation;
            set
            {
                _actuatorRotation = value;
                OnPropertyChanged(nameof(ActuatorRotation));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
