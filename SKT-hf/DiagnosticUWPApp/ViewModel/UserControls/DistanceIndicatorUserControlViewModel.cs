using DiagnosticUWPApp.Model;
using System.ComponentModel;

namespace DiagnosticUWPApp.ViewModel.UserControls
{
    public class DistanceIndicatorUserControlViewModel : ObservableObject
    {
        public double SensorAngle { get; set; }
        public double SensorValue 
        {
            get;
            set;
        } = 1.0;
    }
}
