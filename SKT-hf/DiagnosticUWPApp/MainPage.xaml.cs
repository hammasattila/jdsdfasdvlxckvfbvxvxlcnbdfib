using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.ViewModel;
using System;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DiagnosticUWPApp
{

    public sealed partial class MainPage : Page
    {
        SimSkeleton simSkeleton;
        
        SimViewModel viewModel;

        StartStopSimCommand startStopSimCommand;

        ToggleManualControlCommand toggleManualControlCommand;

        Task simulationTask;
        Task sensorDataTask;

        private async void storeData()
        {
            (viewModel.Velocity, viewModel.Orientation, _) = SimSkeleton.GetData();
        }

        private async void storeSensorData()
        {
            for (int i = 16; i > 0; i--)
                viewModel.SetModelSensorData((i - 1), SimSkeleton.GetSensorData(i - 1));
        }

        private async void runSimulation()
        {
            while(true)
                if (viewModel.SimIsRunning)
                {
                    SimSkeleton.SimIteration();
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>
                        {
                            storeData();
                        }
                    ).AsTask();
                }
        }

        public MainPage()
        {
            this.InitializeComponent();

            viewModel = new SimViewModel();
            startStopSimCommand = new StartStopSimCommand(viewModel);
            toggleManualControlCommand = new ToggleManualControlCommand(viewModel);
            
            simSkeleton = new SimSkeleton(19997);

            simulationTask = new Task(runSimulation);
            simulationTask.Start();
            sensorDataTask = new Task(storeSensorData);
            sensorDataTask.Start();
        }
    }
}
