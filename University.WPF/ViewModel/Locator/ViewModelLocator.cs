using DesktopApp;
using DesktopApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace University.WPF.ViewModel.Locator;

public class ViewModelLocator
{
    public MainWindowViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
}
