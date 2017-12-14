using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Enigma.Annotations;
using Enigma.Messages;
using Enigma.Model;
using Enigma.ViewModels;
using Xamarin.Forms;

namespace Enigma
{
    public class DiagnosticsViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, ShowInfoMessage> _messages = new Dictionary<string, ShowInfoMessage>();
        private IEnumerable<Parameter> _parameters;

        public DiagnosticsViewModel()
        {
            ShowInfoCommand = new Command<Parameter>(OnShowInfoCommand);
            Parameters = DeviceViewModel.Instance.Parameters;
        }

        public IEnumerable<Parameter> Parameters
        {
            get => _parameters;
            set
            {
                _parameters = value;
                OnPropertyChanged();
            }
        }

        #region ShowInfoCommand

        public Command ShowInfoCommand { get; set; }

        private void OnShowInfoCommand(Parameter parameter)
        {
            MessagingCenter.Send(this, "ShowInfo", new ShowInfoMessage(parameter.Name, parameter.Desc));
        }
        #endregion


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
