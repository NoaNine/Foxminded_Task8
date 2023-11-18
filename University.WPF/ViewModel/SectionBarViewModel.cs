using System.Windows.Input;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class SectionBarViewModel : BaseViewModel
{
    private ICommand _openGroupView;
    private ICommand _openHomeView;
    private ICommand _openCourseView;
    private ICommand _openStudentView;
    private ICommand _openTeacherView;
    public ICommand OpenGroupView => 
        _openGroupView ??= new RelayCommand(o => Navigator.NavigateTo<GroupViewModel>(), o => true);
    public ICommand OpenHomeView => 
        _openHomeView ??= new RelayCommand(o => Navigator.NavigateTo<HomeViewModel>(), o => true);
    public ICommand OpenCourseView => 
        _openCourseView ??= new RelayCommand(o => Navigator.NavigateTo<CourseViewModel>(), o => true);
    public ICommand OpenStudentView => 
        _openStudentView ??= new RelayCommand(o => Navigator.NavigateTo<StudentViewModel>(), o => true);
    public ICommand OpenTeacherView => 
        _openTeacherView ??= new RelayCommand(o => Navigator.NavigateTo<TeacherViewModel>(), o => true);

    public SectionBarViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        
    }
}
