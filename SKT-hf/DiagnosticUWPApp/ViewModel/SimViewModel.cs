using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace DiagnosticUWPApp.ViewModel
{
    public class SimViewModel : ObservableObject
    {
        public readonly SimModel Model;

        public SimViewModel ()
        {
            this.Model = new SimModel();
            Model.PropertyChanged += Model_PropertyChanged;
        }
        public float Velocity 
        { 
            get => Model.Velocity;
            set
            {
                Model.Velocity = value;
                Model.PropertyChanged += Model_PropertyChanged;
            }
        }

        public float Orientation 
        {
            get => Model.Orientation;
            set
            {
                Model.Orientation = value;
                Model.PropertyChanged += Model_PropertyChanged;
            }
        }

        public bool SimIsRunning
        { 
            get => Model.SimIsRunning;
            set
            {
                Model.SimIsRunning = value;
                Model.PropertyChanged += Model_PropertyChanged;
            }
        }

        public bool IsManualControl
        { 
            get => Model.IsManualControl;
            set
            {
                Model.IsManualControl = value;
                Model.PropertyChanged += Model_PropertyChanged;
            }
        }
        
        public float GetModelSensorData(int i)
        {
            return Model.GetSensorData(i);
        }
        public void SetModelSensorData(int i, float value)
        {
            Model.SetSensorData(i, value);
            Model.PropertyChanged += Model_PropertyChanged;
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
