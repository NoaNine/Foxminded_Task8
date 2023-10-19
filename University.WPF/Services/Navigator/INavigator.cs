using University.WPF.ViewModel.Base;

namespace University.WPF.Services.Navigator;

public interface INavigator
{
    BaseViewModel GetCurrentView { get; }

    void NavigateTo<T>() where T : BaseViewModel;
}
