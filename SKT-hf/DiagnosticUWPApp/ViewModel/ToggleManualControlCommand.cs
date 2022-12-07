using DiagnosticUWPApp.Model;
using System;
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

        public override bool CanExecute(object parameter) => (bool)parameter;

        public override async void Execute(object parameter)
        {
            if (vm.IsManualControl == false)
            {
                SimSkeleton.GetControl();
            }
            else
            {
                SimSkeleton.ReleaseControl();
            }

            vm.IsManualControl = !vm.IsManualControl;
        }
    }
}
