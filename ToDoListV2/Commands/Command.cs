using System;
using System.Windows.Input;

namespace ToDoListV2.Commands
{
    class Command : CommandBase, ICommand
    {
        private Action execute;

        public Command(Action execute, Func<bool> canExecute = null) : base(canExecute)
        {
            this.execute = execute;
        }

        public void Execute(object parameter) => execute?.Invoke();
    }
}
