using System;
using System.Windows.Input;

namespace DiagnosticUWPApp.ViewModel
{
    public abstract class CommandBase : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
