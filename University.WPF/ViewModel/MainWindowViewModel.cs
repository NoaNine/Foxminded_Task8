using System;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    private INavigator _navigator;
    public INavigator Navigator
    {
        get => _navigator;
        set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel(INavigator navigator)
    {
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
    }
}
