using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Helpers
{
    public class RelayCommand : ICommand
    {
        // Параметры 
        readonly Action<object> _execute; // Действие после вызова
        readonly Predicate<object> _canExecute; // Возможность вызова

        // Конструктор для случая если можно не всегда вызвать
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute==null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        // Конструктор для случая, когда нет ограничений на вызов
        public RelayCommand(Action<object> execute): this(execute, null) { }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
