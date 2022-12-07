using DiagnosticUWPApp.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DiagnosticUWPApp.ViewModel
{
    public class SimViewModel : ObservableObject
    {
        public readonly SimModel Model;

        private static readonly double[] ultrasonicSensorOrientations = { 285, 315, 333, 351, 9, 27, 45, 75, 105, 135, 153, 171, 189, 207, 225, 255 };
        public double[] UltrasonicSensorsOrientations => ultrasonicSensorOrientations;
        private double[] ultrasonicSensorValues = Enumerable.Range(1, ultrasonicSensorOrientations.Length).Select(i => 0.0).ToArray();
        public double[] UltrasonicSensorValues
        {
            get => ultrasonicSensorValues;
            set
            {
                ultrasonicSensorValues = value;
                Notify(nameof(UltrasonicSensorValues));
            }
        }
        public ObservableCollection<SensorViewModel> ultrasonicSensors { get; set; }

        private double _simStep = 0.0;
        public double SimStep
        {
            get => _simStep;
            set
            {
                _simStep = Math.Max(0.0, value);
                Notify(nameof(SimStep));
            }
        }

        public SimViewModel ()
        {
            this.Model = new SimModel();
            Model.PropertyChanged += Model_PropertyChanged;
            initSensors();
        }

        private void initSensors()
        {
            ultrasonicSensors = new ObservableCollection<SensorViewModel>();
            for (int i = 0; i < 16; i++)
            {
                ultrasonicSensors.Add(new SensorViewModel(Model.ultrasonicSensors[i]));
            }
        }

        public float Velocity 
        { 
            get => Model.Velocity;
            set => Model.Velocity = value;
        }

        public float Orientation 
        {
            get => Model.Orientation;
            set => Model.Orientation = value;
        }

        public bool SimIsRunning
        { 
            get => Model.SimIsRunning;
            set => Model.SimIsRunning = value;
        }

        public bool IsManualControl
        { 
            get => Model.IsManualControl;
            set => Model.IsManualControl = value;
        }

        private readonly string[] propertyNames = 
            { nameof(SimModel.Velocity), nameof(SimModel.Orientation),
            nameof(SimModel.SimIsRunning), nameof(SimModel.IsManualControl),
            "sensorData"};

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (propertyNames.Contains(e.PropertyName))
                Notify(e.PropertyName);
        }
    }
}
