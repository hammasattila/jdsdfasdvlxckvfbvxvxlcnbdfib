using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Background;

namespace DiagnosticUWPApp.ViewModel
{
    public class GoBackwardCommand : CommandBase
    {
        private SimViewModel vm;

        public GoBackwardCommand(SimViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => (bool)parameter;

        public override void Execute(object parameter)
        {
            if (vm.Velocity < 0.001f)
                SimSkeleton.SetWheelSpeed(-2f, -2f);
            else
                SimSkeleton.SetWheelSpeed(0f, 0f);
        }
    }
}
