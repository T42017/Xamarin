using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.Message;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enigma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsView sView;

        public SettingsPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SettingsView, ShowInfoMessage>(this, "ShowInfo", OnShowInfoMessage);

            var vm = new SettingsView();
            BindingContext = vm;
            sView = vm;
        }

        private void OnShowInfoMessage(SettingsView sender, ShowInfoMessage message)
        {
            DisplayAlert(message.Title, message.Message, message.ButtonText);
        }


        private void ButtonInfo(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var classId = button.ClassId;

            switch (classId)
            {
                case "StartCalibrationInfo":
                    DisplayAlert("Start Calibration:", "Praesent tincidunt est eget tempus tincidunt. Mauris venenatis blandit massa a ultrices. Phasellus a hendrerit. ", "Close");
                    break;

                case "UseStartPositionInfo":
                    DisplayAlert("Use Start Position:", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin at nisi porttitor, mattis ante ut.", "Close");
                    break;

                case "StartPositionInfo":
                    DisplayAlert("Start Position:", "Curabitur ornare diam ante, ut scelerisque libero placerat a. Pellentesque ut cursus lectus. Nullam tristique.", "Close");
                    break;

                case "STOP_MODEMechInfo":
                    DisplayAlert("STOP_MODE.Mech. stops both dir:", "Phasellus hendrerit ultricies arcu ut iaculis. Maecenas nec porta nibh. Phasellus scelerisque efficitur pretium.", "Close");
                    break;

                case "PowerUpWaitTimeInfo":
                    DisplayAlert("Power Up Wait Time:", "In in ornare lacus. Quisque ullamcorper, ante consequat tincidunt sollicitudin, nibh lectus vestibulum diam.", "Close");
                    break;

                case "SpeedInfo":
                    DisplayAlert("Speed:", "Maecenas mattis dignissim consequat. Sed bibendum felis ut pulvinar luctus. Ut hendrerit erat in pharetra.", "Close");
                    break;

                case "MotionShiftInfo":
                    DisplayAlert("Motion Shift:", "Maecenas mattis dignissim consequat. Sed bibendum felis ut pulvinar luctus. Ut hendrerit erat in pharetra.", "Close");
                    break;

                case "PositiveDirectionInfo":
                    DisplayAlert("Positive Direction:", "Nulla non nisi id sem eleifend commodo. Vivamus scelerisque malesuada nunc, ac viverra ante finibus.", "Close");
                    break;
            }

            
        }

        private void ButtonEventHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var classId = button.ClassId;

            switch (classId)
            {
                case "StartCalibrationEvent":
                    if (sView.CalibrationStatus == "ON")
                    {
                        sView.CalibrationStatus = "OFF";
                    }
                    else if (sView.CalibrationStatus == "OFF")
                    {
                        sView.CalibrationStatus = "ON";
                    }
                    break;
            }
        }
    }
}