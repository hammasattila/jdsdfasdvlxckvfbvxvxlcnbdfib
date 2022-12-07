using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.ViewModel;
using System;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Windows.UI.Core;
using System.ComponentModel;

namespace DiagnosticUWPApp
{

    public sealed partial class MainPage : Page
    {
        SimSkeleton simSkeleton;
        
        SimViewModel viewModel;

        StartStopSimCommand startStopSimCommand;

        ToggleManualControlCommand toggleManualControlCommand;

        Task simulationTask;

        private async void storeData()
        {
            double[] values = new double[viewModel.UltrasonicSensorsOrientations.Length];
            (viewModel.Velocity, viewModel.Orientation, _) = SimSkeleton.GetData();
            for (int i = 15; i >= 0; i--)
            {
                values[i] = SimSkeleton.GetSensorData(i);
                viewModel.ultrasonicSensors[i].Data = (float)values[i];
            }
            viewModel.UltrasonicSensorValues = values;
            viewModel.SimStep += 1.0;
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

        private void OnViewModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(viewModel.SimIsRunning).Equals(e.PropertyName))
            {
                if (viewModel.SimIsRunning)
                {
                    SimulationIsRunningStoryBoard.Begin();
                }
                else
                {
                    SimulationIsRunningStoryBoard.Stop();
                }
            }

            if (nameof(viewModel.IsManualControl).Equals(e.PropertyName))
            {
                if (viewModel.IsManualControl)
                {
                    ControlIsManualStoryBoard.Begin();
                }
                else
                {
                    ControlIsManualStoryBoard.Begin();
                }
            }
        }

        public MainPage()
        {
            simSkeleton = new SimSkeleton(19997);

            this.InitializeComponent();

            viewModel = new SimViewModel();
            startStopSimCommand = new StartStopSimCommand(viewModel);
            toggleManualControlCommand = new ToggleManualControlCommand(viewModel);


            viewModel.PropertyChanged += OnViewModelChanged;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            simulationTask = new Task(runSimulation);
            simulationTask.Start();
        }
    }
}
