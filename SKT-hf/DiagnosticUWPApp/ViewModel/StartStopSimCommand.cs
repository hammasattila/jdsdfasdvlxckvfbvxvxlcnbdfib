using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
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
            /*if (this.vm.SimIsRunning == false)
            {
                SimSkeleton.csharp_StartSimulation(SimSkeleton.Simulation);
            }
            else
            {
                SimSkeleton.csharp_StopSimulation(SimSkeleton.Simulation);
            }*/

            vm.SimIsRunning = !vm.SimIsRunning;
        }
    }
}
