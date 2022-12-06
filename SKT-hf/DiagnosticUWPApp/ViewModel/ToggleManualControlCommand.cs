using DiagnosticUWPApp.Model;
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

        public override async void Execute(object parameter)
        {
            if (vm.SimIsRunning)
            {
                if (vm.IsManualControl == false)
                {
                    vm.SimIsRunning = false;
                    await Task.Delay(10);
                    SimSkeleton.GetControl();
                    await Task.Delay(10);
                    SimSkeleton.SetWheelSpeed(10f, 10f);
                    vm.SimIsRunning = true;
                }
                else
                {
                    vm.SimIsRunning = false;
                    SimSkeleton.ReleaseControl();
                    vm.SimIsRunning = true;
                }

                vm.IsManualControl = !vm.IsManualControl;
            }
        }
    }
}
