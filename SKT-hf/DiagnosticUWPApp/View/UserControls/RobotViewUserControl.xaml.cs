using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.ViewModel;
using DiagnosticUWPApp.ViewModel.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private RobotViewUserControlViewModel viewModel = new RobotViewUserControlViewModel();
        public RobotViewUserControlViewModel ViewModel => viewModel;

        [Description("Angles of the distance sensors"), Category("Data")]
        public double[] DistanceSensorAngles { set => viewModel.DistanceSensorAngles = value; }
        [Description("Sensor values"), Category("Data")]
        public double[] DistanceSensors { set => viewModel.DistanceSensors = value; }

        public RobotViewUserControl()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) { }
    }
}
