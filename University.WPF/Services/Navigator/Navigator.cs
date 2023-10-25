using System;
using University.WPF.ViewModel.Base;

namespace University.WPF.Services.Navigator;

public class Navigator : ObservableObject, INavigator
{
    private readonly Func<Type, BaseViewModel> _viewModelFactory;
    private BaseViewModel _currentView;

    public BaseViewModel GetCurrentView
    { 
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged("GetCurrentView");
        }
    }

    public Navigator(Func<Type, BaseViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
    }

    public void NavigateTo<T>() where T : BaseViewModel 
    {
        BaseViewModel viewModelBase = _viewModelFactory.Invoke(typeof(T));
        GetCurrentView = viewModelBase;
    }
}
