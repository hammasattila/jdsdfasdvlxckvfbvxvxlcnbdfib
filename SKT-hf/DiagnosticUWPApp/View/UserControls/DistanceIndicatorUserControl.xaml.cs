using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.ViewModel.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class DistanceIndicatorUserControl : UserControl
    {
        private DistanceIndicatorUserControlViewModel viewModel =
            new DistanceIndicatorUserControlViewModel();
        public DistanceIndicatorUserControlViewModel ViewModel => viewModel;

        [Description("Angle of the distance sensor"), Category("Data")]
        public double SensorAngle { set => ViewModel.SensorAngle = value; }

        [Description("Value of the distance sensor"), Category("Data")]
        public double SensorValue { set => ViewModel.SensorValue = value; }

        public DistanceIndicatorUserControl()
        {
            this.InitializeComponent();
        }
    }
}
