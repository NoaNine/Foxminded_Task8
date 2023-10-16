using University.WPF.Core;

namespace University.WPF.Services.Navigator;

public interface INavigator
{
    ViewModelBase CurrentView { get; }

    void NavigateTo<T>() where T : ViewModelBase;
}
