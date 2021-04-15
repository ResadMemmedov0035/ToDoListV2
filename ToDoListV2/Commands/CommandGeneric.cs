using System;
using System.Windows.Input;

namespace ToDoListV2.Commands
{
    class Command<T> : CommandBase, ICommand where T : class
    {
        private Action<T> execute;

        public Command(Action<T> execute, Func<bool> canExecute = null) : base(canExecute)
        {
            this.execute = execute;
        }

        public void Execute(object parameter) => execute?.Invoke(parameter as T);
    }
}
