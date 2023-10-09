using System;

namespace DesktopApp.Command;

public interface ICommand
{
    event EventHandler CanExecuteChanged;

    bool CanExecute(object parameter);
    void Execute(object parameter);
}