using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Enigma.Annotations;
using Enigma.Message;
using Xamarin.Forms;

namespace Enigma
{
    public class SettingsView : INotifyPropertyChanged
    {
        private Dictionary<string, ShowInfoMessage> _messages = new Dictionary<string, ShowInfoMessage>();

        public SettingsView()
        {
            CalibrationStatus = "OFF";

            StartCalibrationCommand = new Command(OnStartCalibrationCommand);
            ShowInfoCommand = new Command<string>(OnShowInfoCommand);

            _messages.Add("StartCalibrationInfo", new ShowInfoMessage("Start Calibration:", "1"));
            _messages.Add("UseStartPositionInfo", new ShowInfoMessage("Use Start Position:", "2"));
            _messages.Add("StartPositionInfo", new ShowInfoMessage("Start Position:", "3"));
            _messages.Add("STOP_MODEMechInfo", new ShowInfoMessage("STOP_MODE Mech:", "4"));
            _messages.Add("PowerUpWaitTimeInfo", new ShowInfoMessage("Power Up Wait Time:", "5"));
            _messages.Add("SpeedInfo", new ShowInfoMessage("Speed:", "6"));
            _messages.Add("MotionShiftInfo", new ShowInfoMessage("Motion Shift:", "7"));
            _messages.Add("PositiveDirectionInfo", new ShowInfoMessage("Positive Direction:", "8"));
        }

        #region ShowInfoCommand

        public Command ShowInfoCommand { get; set; }

        private void OnShowInfoCommand(string id)
        {
            if(_messages.ContainsKey(id))
                MessagingCenter.Send(this, "ShowInfo", _messages[id]);
            else
            {

                MessagingCenter.Send(this, "ShowInfo", new ShowInfoMessage("Error:", "Unknown info"));
            }

        }

        #endregion

        #region StartCalibrationCommand

        private void OnStartCalibrationCommand()
        {
            CalibrationStatus = CalibrationStatus == "OFF" ? "ON" : "OFF";
        }

        public Command StartCalibrationCommand { get; set; }

        #endregion

        private string _calibrationStatus;

        public string CalibrationStatus
        {
            get { return _calibrationStatus; }
            set
            {
                _calibrationStatus = value;
                OnPropertyChanged();
            }
        }

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
