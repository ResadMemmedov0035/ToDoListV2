using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoListV2.Commands
{
    class Command : ICommand
    {
        private Action<object> action;
        private Predicate<object> predicate;

        public Command(Action<object> action, Predicate<object> predicate = null)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => predicate?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => action?.Invoke(parameter);
    }
}
