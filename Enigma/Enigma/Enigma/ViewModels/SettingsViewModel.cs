using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Enigma.Annotations;
using Enigma.Messages;
using Enigma.Model;
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

            Parameters = LoadParameterData().ToList();

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

        private IEnumerable<Parameter> _parameters;

        public IEnumerable<Parameter> Parameters
        {
            get { return _parameters;}
            set
            {
                _parameters = value;
                OnPropertyChanged();
            } 
            
        }

        #region Load Parameters

        private IEnumerable<Parameter> LoadParameterData()
        {
            var assembly = typeof(SettingsView).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Enigma.Data.Parameters.xml");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            XDocument doc = XDocument.Parse(text);

            IEnumerable<Parameter> parameters = from s in doc.Descendants("param")
                                                select new Parameter
                                                {
                                                    Id = ushort.Parse(s.Attribute("id").Value),
                                                    Name = s.Attribute("name").Value,
                                                    Desc = s.Element("desc").Value
                                                };

            return parameters;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
