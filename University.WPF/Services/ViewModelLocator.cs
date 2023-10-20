using DesktopApp;
using DesktopApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using University.WPF.ViewModel;

namespace University.WPF.Services;

internal class ViewModelLocator
{
    public MainWindowViewModel MainVM => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
    public SectionBarViewModel SectionBarVM => App.ServiceProvider.GetRequiredService<SectionBarViewModel>();
    public GroupViewModel GroupVM => App.ServiceProvider.GetRequiredService<GroupViewModel>();
}
