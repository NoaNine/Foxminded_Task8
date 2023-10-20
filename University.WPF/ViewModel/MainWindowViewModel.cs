using Microsoft.EntityFrameworkCore.Metadata;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace DesktopApp.ViewModel;

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
        _navigator = navigator;
    }
}
