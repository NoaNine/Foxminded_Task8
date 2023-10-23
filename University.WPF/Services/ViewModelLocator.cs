using Microsoft.Extensions.DependencyInjection;
using University.WPF.ViewModel;
using University.WPF.ViewModel.Base;

namespace University.WPF.Services;

internal class ViewModelLocator
{
    public BaseViewModel MainVM => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
    public BaseViewModel SectionBarVM => App.ServiceProvider.GetRequiredService<SectionBarViewModel>();
    public BaseViewModel GroupVM => App.ServiceProvider.GetRequiredService<GroupViewModel>();
    public BaseViewModel StudentVM => App.ServiceProvider.GetRequiredService<StudentViewModel>();
    public BaseViewModel CourseVM => App.ServiceProvider.GetRequiredService<CourseViewModel>();
    public BaseViewModel TeacherVM => App.ServiceProvider.GetRequiredService<TeacherViewModel>();
    public BaseViewModel BreadcrumbBarVM => App.ServiceProvider.GetRequiredService<BreadcrumbBarViewModel>();
    public HomeViewModel HomeVM => App.ServiceProvider.GetRequiredService<HomeViewModel>();
}
