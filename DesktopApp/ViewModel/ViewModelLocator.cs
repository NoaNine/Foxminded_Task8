using DesktopApp.Command;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace DesktopApp.ViewModel;

public class ViewModelLocator
{
    public MainWindowViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
}
