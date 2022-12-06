using DiagnosticUWPApp.Model;

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
                    vm.SimIsRunning = false;
                    SimSkeleton.GetControl();
                    SimSkeleton.SetWheelSpeed(0, 10);
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
