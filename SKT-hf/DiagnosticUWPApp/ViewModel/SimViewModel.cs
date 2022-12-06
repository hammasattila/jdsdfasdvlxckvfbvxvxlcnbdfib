using DiagnosticUWPApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DiagnosticUWPApp.ViewModel
{
    public class SimViewModel : ObservableObject
    {
        public readonly SimModel Model;

        public ObservableCollection<SensorViewModel> ultrasonicSensors { get; set; }

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
