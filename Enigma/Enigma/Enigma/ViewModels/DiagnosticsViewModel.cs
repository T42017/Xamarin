﻿using System;
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
using Xamarin.Forms;

namespace Enigma
{
    class DiagnosticsViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, ShowInfoMessage> _messages = new Dictionary<string, ShowInfoMessage>();
        private IEnumerable<Parameter> _parameters;

        public DiagnosticsViewModel()
        {
            ShowInfoCommand = new Command<Parameter>(OnShowInfoCommand);
            Parameters = LoadParameterData().ToList();

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

        #region Load Parameters

        private IEnumerable<Parameter> LoadParameterData()
        {
            var assembly = typeof(DiagnosticsViewModel).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Enigma.Data.Parameters.xml");
            var text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var doc = XDocument.Parse(text);

            var parameters = from s in doc.Descendants("readParamsStandard").Descendants("param")
                select new Parameter
                {
                    Id = ushort.Parse(s.Attribute("id").Value),
                    Name = s.Attribute("name").Value,
                    Desc = s.Element("desc").Value,
                    Type = s.Attribute("type").Value,
                    Content = s.Attribute("content").Value

                };

            return parameters;
        }

        #endregion

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
