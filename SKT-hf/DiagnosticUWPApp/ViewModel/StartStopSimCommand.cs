using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.ViewModel
{
    public class StartStopSimCommand : CommandBase
    {
        private SimViewModel vm;

        public StartStopSimCommand (SimViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (vm.SimIsRunning == false)
            {
                vm.SimStep = 0.0;
                SimSkeleton.StartSimulation();
            }
            else
            {
                SimSkeleton.StopSimulation();
                if (vm.IsManualControl)
                    vm.IsManualControl = false;
            }

            vm.SimIsRunning = !vm.SimIsRunning;
        }
    }
}
