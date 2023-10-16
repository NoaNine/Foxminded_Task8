using System;
using University.WPF.Core;

namespace University.WPF.Services.Navigator;

public class Navigator : ObservableObject, INavigator
{
    private readonly Func<Type, ViewModelBase> _viewModelFactory;
    private ViewModelBase _currentView;

    public ViewModelBase CurrentView
    { 
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged("CurrentView");
        }
    }

    public Navigator(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<T>() where T : ViewModelBase
    {
        ViewModelBase viewModelBase = _viewModelFactory.Invoke(typeof(T));
        CurrentView = viewModelBase;
    }
}
