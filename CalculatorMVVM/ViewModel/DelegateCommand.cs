using System;
using System.Windows.Input;

namespace CalculatorMVVM
{
    /// <summary>
    /// Класс, реализующий интерфейс ICommand
    /// </summary>
    class DelegateCommand:ICommand
    {
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        private Action<object> execute;
        private Func<object, bool> canExecute;
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            this.execute(parameter);
        }
    }
}
