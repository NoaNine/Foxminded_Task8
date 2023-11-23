using Microsoft.Extensions.DependencyInjection;
using University.WPF.ViewModel;
using University.WPF.ViewModel.Base;

namespace University.WPF.Infrastructure;

internal class ViewModelLocator
{
    public BaseViewModel MainVM => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
    public BaseViewModel SectionBarVM => App.ServiceProvider.GetRequiredService<SectionBarViewModel>();
    public BaseViewModel GroupVM => App.ServiceProvider.GetRequiredService<GroupViewModel>();
    public BaseViewModel StudentVM => App.ServiceProvider.GetRequiredService<StudentViewModel>();
    public BaseViewModel CourseVM => App.ServiceProvider.GetRequiredService<CourseViewModel>();
    public BaseViewModel TeacherVM => App.ServiceProvider.GetRequiredService<TeacherViewModel>();
    public BaseViewModel HomeVM => App.ServiceProvider.GetRequiredService<HomeViewModel>();
    public BaseViewModel AddStudentVM => App.ServiceProvider.GetRequiredService<AddStudentViewModel>();
    public BaseViewModel EditStudentVM => App.ServiceProvider.GetRequiredService<EditStudentViewModel>();
}
