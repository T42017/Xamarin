using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.Message;
using Xamarin.Forms;

namespace Enigma
{
    class DiagnosticsViewModel
    {
        private Dictionary<string, ShowInfoMessage> _messages = new Dictionary<string, ShowInfoMessage>();

        public DiagnosticsViewModel()
        {
            ShowInfoCommand = new Command<string>(OnShowInfoCommand);

            _messages.Add("ActuatorIDInfo", new ShowInfoMessage("Actuator ID:", "1"));
            _messages.Add("ManufacturingDateInfo", new ShowInfoMessage("Manufacturing Date Info:", "2"));
            _messages.Add("SWVersionInfo", new ShowInfoMessage("Sw Version:", "3"));
            _messages.Add("FactorySettingsIDInfo", new ShowInfoMessage("Factory Settings ID:", "4"));
            _messages.Add("StrokeLengthInfo", new ShowInfoMessage("Stroke Length:", "5"));
            _messages.Add("TotalRunningInfo", new ShowInfoMessage("Total Running:", "6"));
            _messages.Add("TotalRunningTimeInfo", new ShowInfoMessage("Total Running Time:", "7"));
            _messages.Add("PowerUpsInfo", new ShowInfoMessage("Power Ups:", "8"));
            _messages.Add("CWEndStopsInfo", new ShowInfoMessage("Cw End Stops:", "9"));
            _messages.Add("CCWEndStopsInfo", new ShowInfoMessage("CCW End Stops:", "10"));
            _messages.Add("FirstErrorPositionInfo", new ShowInfoMessage("First Error Position:", "11"));
        }

        #region ShowInfoCommand

        public Command ShowInfoCommand { get; set; }

        private void OnShowInfoCommand(string id)
        {
            if (_messages.ContainsKey(id))
                MessagingCenter.Send(this, "ShowInfo", _messages[id]);
            else
            {

                MessagingCenter.Send(this, "ShowInfo", new ShowInfoMessage("Error:", "Unknown info"));
            }

        }

        #endregion
    }
}
