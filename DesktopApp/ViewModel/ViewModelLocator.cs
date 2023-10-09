using Microsoft.Extensions.DependencyInjection;

namespace DesktopApp.ViewModel;

public class ViewModelLocator
{
    public MainWindowViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
}
