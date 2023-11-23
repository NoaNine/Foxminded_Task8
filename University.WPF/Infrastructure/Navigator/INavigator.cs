using University.WPF.ViewModel.Base;

namespace University.WPF.Infrastructure.Navigator;

public interface INavigator
{
    BaseViewModel GetCurrentView { get; }

    void NavigateTo<T>() where T : BaseViewModel;
}
