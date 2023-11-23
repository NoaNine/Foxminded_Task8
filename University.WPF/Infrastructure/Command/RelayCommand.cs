using System.Windows.Input;
using System;

namespace University.WPF.Infrastructure.Command;

public class RelayCommand : ICommand
{
    private Action<object> _execute;
    private Predicate<object> _canExecute;

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException("execute");
        _canExecute = canExecute ?? throw new ArgumentNullException("canExecute");
    }

    public bool CanExecute(object parameter) => _canExecute(parameter);

    public void Execute(object parameter) => _execute(parameter);
}
