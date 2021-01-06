using System;
using System.Windows.Input;

namespace Covid19TrackerLibrary.Model.Commands.Base
{
    //Класс базовой команды, реализующий ICommand и изпользующийся в других классах
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
