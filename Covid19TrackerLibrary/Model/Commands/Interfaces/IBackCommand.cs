using System;
using System.Windows.Input;

namespace Covid19TrackerLibrary.Model.Commands.Interfaces
{
    public interface IBackCommand
    {
        public ICommand Back { get; set; }
        public bool CanBackExecute(object sender);
        public void BackExecute(object sender);
    }
}
