using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticUWPApp.ViewModel
{
    public class ToggleManualControlCommand : CommandBase
    {
        private SimViewModel vm;
        public ToggleManualControlCommand (SimViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (vm.IsManualControl == false)
            {
                //TODO: DLL-ben lévő függvényt meghívva szimuláció vezérlésének átvétele
            }
            else
            {
                //TODO: DLL - ben lévő függvényt meghívva szimuláció vezérlésének elengedése
            }
            
            vm.IsManualControl = !vm.IsManualControl;
        }
    }
