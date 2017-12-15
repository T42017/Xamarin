using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Enigma;
using Enigma.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Debug = System.Diagnostics.Debug;

[assembly: ExportRenderer(typeof(ActuatorControl), typeof(ActuatorRenderer))]
namespace Enigma.Droid
{
    public class ActuatorRenderer : ImageRenderer
    {
        private double _lastX, _lastY;
        private ActuatorControl _control;

        private bool _isRecordingValues = false;
        private bool _isRotatingCCW = false;

        public ActuatorRenderer()
        {
            Touch += OnTouch;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement is ActuatorControl)
                _control = (ActuatorControl) e.NewElement;
        }

        private void OnTouch(object sender, TouchEventArgs touchEventArgs)
        {
            if (_control == null || !_control.Enabled) return;

            switch (touchEventArgs.Event.Action)
            {
                case MotionEventActions.Down:
                    _lastY = touchEventArgs.Event.RawY;
                    _lastX = touchEventArgs.Event.RawX;
                    _isRecordingValues = true;
                    _control.ActuatorList.Clear();
                    break;
                case MotionEventActions.Up:
                    _isRecordingValues = false;
                    break;
            }

            if (touchEventArgs.Event.Action != MotionEventActions.Move) return;

            var dx = touchEventArgs.Event.RawX - (this.GetX() + this.Width / 2f);
            var dy = touchEventArgs.Event.RawY - (this.GetY() + this.Height / 2f);
            var angle = Math.Atan2(dy, dx) * 180 / Math.PI + 90;

            var dx2 = _lastX - (this.GetX() + this.Width / 2f);
            var dy2 = _lastY - (this.GetY() + this.Height / 2f);
            var angle2 = Math.Atan2(dy2, dx2) * 180 / Math.PI + 90;
            
            if (_control.ActuatorList.Count == 0)
                _control.ActuatorList.Add(_control.ActuatorRotation);

            _control.ActuatorRotation += (float) (angle - angle2);

            //_control.ActuatorList.Add(_control.ActuatorRotation);
            System.Diagnostics.Debug.WriteLine((float) angle + " " + (float) angle2);

            _lastX = touchEventArgs.Event.RawX;
            _lastY = touchEventArgs.Event.RawY;
        }
    }
}