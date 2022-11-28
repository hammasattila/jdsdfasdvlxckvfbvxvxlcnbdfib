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
            if (this.vm.SimIsRunning == false)
            {
                //TODO: DLL-ben lévő függvényt meghívva szimuláció elindítása
            }
            else
            {
                //TODO: DLL-ben lévő függvényt meghívva szimuláció leállítása
            }

            vm.SimIsRunning = !vm.SimIsRunning;
        }
    }
}
