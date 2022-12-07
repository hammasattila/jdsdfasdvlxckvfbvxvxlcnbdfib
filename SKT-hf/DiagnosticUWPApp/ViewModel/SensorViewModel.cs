using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.ViewModel
{
    public class SensorViewModel : ObservableObject
    {
        public readonly Sensor sensor;

        public SensorViewModel(Sensor sensor)
        {
            this.sensor = sensor;
            sensor.PropertyChanged += Sensor_PropertyChanged;
        }

        public int Id
        {
            get => sensor.Id;
            set => sensor.Id = value;
        }

        public float Data
        {
            get => sensor.Data;
            set => sensor.Data = value;
        }

        private readonly string[] propertyNames =
            { nameof(Sensor.Id), nameof(Sensor.Data)};

        private void Sensor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (propertyNames.Contains(e.PropertyName))
                Notify(e.PropertyName);
        }
    }
}
