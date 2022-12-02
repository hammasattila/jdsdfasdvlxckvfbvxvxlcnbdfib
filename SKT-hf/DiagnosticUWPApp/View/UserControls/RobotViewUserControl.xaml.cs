using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DiagnosticUWPApp.View.UserControls
{
    public class DistanceSensorIndicator : ObservableObject
    {
        private double angle;
        private double value;

        public double Angle => angle;
        public double Value
        { 
            get { return value; }
            set { this.value = Math.Max(0.0, Math.Min(value, 1.0)); }
        }

        public DistanceSensorIndicator(double angle, double value = 1.0)
        {
            this.angle = angle;
            this.value = value;
        }
    }

    public sealed partial class RobotViewUserControl : UserControl
    {
        private ObservableCollection<DistanceSensorIndicator> distanceSensorIndicators = new ObservableCollection<DistanceSensorIndicator>();
        public ObservableCollection<DistanceSensorIndicator> DistanceSensorIndicators => distanceSensorIndicators;

        public RobotViewUserControl()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Dummy distance sensors
            for (uint i = 315; i <= 405; i += 15)
            {
                var tmp = new DistanceSensorIndicator(i % 360);
                tmp.Value = i * 1.0 / 420;
                distanceSensorIndicators.Add(tmp);
            }

            for (uint i = 135; i <= 225; i += 15)
            {
                var tmp = new DistanceSensorIndicator(i % 360);
                tmp.Value = i * 1.0 / 420;
                distanceSensorIndicators.Add(tmp);
            }

            double[] lata = { 80, 100, 260, 280 };
            foreach (var angle in lata)
            {
                distanceSensorIndicators.Add(new DistanceSensorIndicator(angle));
            }


            //for (uint i = 0; i < 360; i += 20)
            //{
            //    if (i == 60 || i == 120 || i == 240 || i == 300) continue;
            //    var tmp = new DistanceSensorIndicator(i);
            //    tmp.Value = i * 1.0 / 380;
            //    distanceSensorIndicators.Add(tmp);
            //}
        }
    }
}
