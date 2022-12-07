using DiagnosticUWPApp.ViewModel.UserControls;
using System;
using System.Collections.Generic;
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
    public sealed partial class RobotHistoricValuesUserControl : UserControl
    {
        public RobotHistoricValuesUserControlViewModel ViewModel { get; private set; } =
            new RobotHistoricValuesUserControlViewModel();

        public double SimulationStep { set => ViewModel.SimulationStep = value; }
        public double Velocity { set => ViewModel.Velocity = value; }

        public RobotHistoricValuesUserControl()
        {
            this.InitializeComponent();
        }
    }
}
