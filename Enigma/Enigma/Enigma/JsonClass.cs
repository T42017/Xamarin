using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace Enigma
{
    public class JsonClass
    {
        #region Public int

        public int AcuatorId { get; set; }
        public int CCWEndStops { get; set; }
        public int CWEndStops { get; set; }
        public int PowerUps { get; set; }
        public int PowerUpWaitTime { get; set; }
        public int StrokeLength { get; set; }
        #endregion

        #region Public string

        public string name { get; set; }

        public string FactorySettingsID { get; set; }
        public string StopModeMechText { get; set; }
        public string SWVersion { get; set; }
        public string TotalRunning { get; set; }
        public string TotalRunningTime { get; set; }
        public string Speed { get; set; }
        public string StartCalibration { get; set; }
        public string StartPosition { get; set; }
        #endregion

        #region Public bool
        
        public bool MotionShift { get; set; }
        public bool PositiveDirection { get; set; }
        public bool UseStartPosition { get; set; }
        #endregion

        #region Public Position

        public Position FirstErrorPosition { get; set; }
        public Position MarkerPosition { get; set; }
        #endregion

        #region Public DateTime
        
        public DateTime ManufacturingDate { get; }
        #endregion
    }
}
