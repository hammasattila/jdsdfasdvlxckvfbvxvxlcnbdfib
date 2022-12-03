using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.ViewModel
{
    public class ToggleManualControlCommand : CommandBase
    {
        private SimViewModel vm;
        public ToggleManualControlCommand(SimViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (vm.SimIsRunning)
            {
                if (vm.IsManualControl == false)
                {
                    SimSkeleton.GetControl();
                    SimSkeleton.SetWheelSpeed(0, 0);
                }
                else
                {
                    SimSkeleton.ReleaseControl();
                }

                vm.IsManualControl = !vm.IsManualControl;
            }
        }
    }
}
