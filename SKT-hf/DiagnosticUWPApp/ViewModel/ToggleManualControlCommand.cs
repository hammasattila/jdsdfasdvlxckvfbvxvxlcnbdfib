using DiagnosticUWPApp.Model;
using DiagnosticUWPApp.View;
using System;
using System.Collections.Generic;
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

        public override bool CanExecute(object parameter) => vm.SimIsRunning;

        public override void Execute(object parameter)
        {
            /*if (vm.IsManualControl == false)
            {
                SimSkeleton.csharp_GetPioneerControl(SimSkeleton.Simulation);
            }
            else
            {
                SimSkeleton.csharp_ReleasePioneerControl(SimSkeleton.Simulation);
            }*/

            vm.IsManualControl = !vm.IsManualControl;
        }
    }
}
