using System;
using System.Windows.Input;

namespace DiagnosticUWPApp.ViewModel
{
    public abstract class CommandBase : ICommand
    {
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
