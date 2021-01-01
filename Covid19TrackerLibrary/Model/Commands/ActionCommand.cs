using Covid19TrackerLibrary.Model.Commands.Base;
using System;

namespace Covid19TrackerLibrary.Model.Commands
{
    public class ActionCommand : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
        public override void Execute(object parameter) => _Execute?.Invoke(parameter);

        public ActionCommand(Action<object> execute, Func<object,bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }
    }
}
