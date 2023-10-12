using DesktopApp;
using DesktopApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace University.WPF.Services.Locator;

internal class ViewModelLocator
{
    public MainWindowViewModel MainVM => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
}
