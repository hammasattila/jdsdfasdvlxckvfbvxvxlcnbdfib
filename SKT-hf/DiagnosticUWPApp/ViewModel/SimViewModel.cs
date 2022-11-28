using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.ViewModel
{
    public class SimViewModel : ObservableObject
    {
        public readonly SimModel Model;

        public SimViewModel (SimModel model)
        {
            this.Model = model;
            Model.PropertyChanged += Model_PropertyChanged;
        }
        public double Velocity { get => Model.Velocity; }

        public double Orientation { get => Model.Orientation; }

        public bool SimIsRunning
        { 
            get => Model.SimIsRunning;
            set
            {
                Model.SimIsRunning = value;
            }
        }

        public bool IsManualControl
        { 
            get => Model.IsManualControl;
            set
            {
                Model.IsManualControl = value;
            }
        }

        private readonly string[] propertyNames = 
            { nameof(SimModel.Velocity), nameof(SimModel.Orientation),
            nameof(SimModel.SimIsRunning), nameof(SimModel.IsManualControl) };

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (propertyNames.Contains(e.PropertyName))
                Notify(e.PropertyName);
        }
    }
}
