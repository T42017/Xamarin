﻿using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Enigma.Annotations;
using Enigma.Messages;
using Enigma.Model;
using Enigma.ViewModels;
using Xamarin.Forms;

namespace Enigma
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _calibrationStatus;

        private IEnumerable<Parameter> _parameters;

        public SettingsViewModel()
        {
            CalibrationStatus = "OFF";

            StartCalibrationCommand = new Command(OnStartCalibrationCommand);
            ShowInfoCommand = new Command<Parameter>(OnShowInfoCommand);
            Parameters = DeviceViewModel.Instance.Parameters;
        }

        public string CalibrationStatus
        {
            get => _calibrationStatus;
            set
            {
                _calibrationStatus = value;
                OnPropertyChanged();
            }
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

        #region StartCalibrationCommand

        private void OnStartCalibrationCommand()
        {
            CalibrationStatus = CalibrationStatus == "OFF" ? "ON" : "OFF";
        }

        public Command StartCalibrationCommand { get; set; }

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