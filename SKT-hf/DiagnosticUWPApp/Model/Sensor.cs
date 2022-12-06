using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.Model
{
    public class Sensor : ObservableObject
    {
        private int id;

        public int Id
        {
            get => id;
            set
            {
                if(id != value)
                {
                    id = value;
                    Notify();
                }
            }
        }

        private float data;

        public float Data
        {
            get => data;
            set
            {
                if(data != value)
                {
                    data = value;
                    Notify();
                }
            }
        }
    }
}
