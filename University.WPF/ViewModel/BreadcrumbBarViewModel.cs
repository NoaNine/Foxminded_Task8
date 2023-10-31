using System;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class BreadcrumbBarViewModel : BaseViewModel
{
    private INavigator _navigator;
    public INavigator Navigator
    {
        get => _navigator;
        private set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }

    public BreadcrumbBarViewModel(INavigator navigator)
    {
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
    }
}
