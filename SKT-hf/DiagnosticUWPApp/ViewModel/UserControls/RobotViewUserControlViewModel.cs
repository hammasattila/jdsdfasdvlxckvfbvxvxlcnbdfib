using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.ViewModel.UserControls
{
    public class RobotViewUserControlViewModel : ObservableObject
    {
        private ObservableCollection<DistanceSensorIndicator> distanceSensorIndicators =
            new ObservableCollection<DistanceSensorIndicator>();
        public ObservableCollection<DistanceSensorIndicator> DistanceSensorIndicators =>
            distanceSensorIndicators;

        private double[] distanceSenorAngles;
        public double[] DistanceSensorAngles
        {
            get => distanceSenorAngles;
            set
            {
                if (value == null) { return; }
                distanceSenorAngles = value;
                DistanceSensorIndicators.Clear();
                foreach (var angle in value)
                {
                    DistanceSensorIndicators.Add(new DistanceSensorIndicator(angle));
                }
                Notify(nameof(DistanceSensorIndicators));
            }
        }

        public double[] DistanceSensors
        {
            set
            {
                if (value == null || DistanceSensorAngles == null || value.Length != DistanceSensorIndicators.Count) { return; }
                for (int i = 0; i < value.Length; ++i)
                {
                    DistanceSensorIndicators[i].Value = value[i];
                    DistanceSensorIndicators[i] = new DistanceSensorIndicator(DistanceSensorAngles[i], value[i]);
                }
                //Notify(nameof(DistanceSensorIndicators));
            }
        }
    }
}
