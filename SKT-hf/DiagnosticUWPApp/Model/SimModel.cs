using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.Model
{
    public class SimModel : ObservableObject
    {
        private float velocity;

        public float Velocity
        {
            get => velocity;
            set
            {
                if (velocity != value)
                {
                    velocity = value;
                    Notify();
                }
            }
        }

        private float orientation;

        public float Orientation
        {
            get => orientation;
            set
            {
                if (orientation != value)
                {
                    orientation = value;
                    Notify();
                }
            }
        }

        private bool simIsRunning = false;

        public bool SimIsRunning
        {
            get => simIsRunning;
            set
            {
                if (simIsRunning != value)
                {
                    simIsRunning = value;
                    Notify();
                }
            }
        }

        private bool isManualControl = false;

        public bool IsManualControl
        {
            get => isManualControl;
            set
            {
                if (isManualControl != value)
                {
                    isManualControl = value;
                    Notify();
                }
            }
        }
    }
}
