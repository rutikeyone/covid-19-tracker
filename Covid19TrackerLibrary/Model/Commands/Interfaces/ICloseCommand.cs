using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Covid19TrackerLibrary.Model.Commands.Interfaces
{
    public interface ICloseCommand
    {
        public RelayCommand<Window> Close { get; set; }

        public void CloseWindow(Window window);

    }
}
