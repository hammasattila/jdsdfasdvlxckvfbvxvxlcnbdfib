using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.ViewModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiagnosticUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //SimSkeleton simSkeleton;

        SimViewModel ViewModel;

        StartStopSimCommand StartStopSimCommand;

        ToggleManualControlCommand ToggleManualControlCommand;

        public MainPage()
        {
            this.InitializeComponent();
            
            //simSkeleton = new SimSkeleton(19997);

            ViewModel = new SimViewModel();
            StartStopSimCommand = new StartStopSimCommand(ViewModel);
            ToggleManualControlCommand = new ToggleManualControlCommand(ViewModel);
        }
    }
}
