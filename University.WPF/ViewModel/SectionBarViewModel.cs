using System.Windows.Input;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class SectionBarViewModel : BaseViewModel
{
    private ICommand _openGroupViewCommand;
    private ICommand _openHomeViewCommand;
    private ICommand _openCourseViewCommand;
    private ICommand _openStudentViewCommand;
    private ICommand _openTeacherViewCommand;
    public ICommand OpenGroupViewCommand =>
        _openGroupViewCommand ??= new RelayCommand(o => Navigator.NavigateTo<GroupViewModel>(), o => true);
    public ICommand OpenHomeViewCommand =>
        _openHomeViewCommand ??= new RelayCommand(o => Navigator.NavigateTo<HomeViewModel>(), o => true);
    public ICommand OpenCourseViewCommand =>
        _openCourseViewCommand ??= new RelayCommand(o => Navigator.NavigateTo<CourseViewModel>(), o => true);
    public ICommand OpenStudentViewCommand =>
        _openStudentViewCommand ??= new RelayCommand(o => Navigator.NavigateTo<StudentViewModel>(), o => true);
    public ICommand OpenTeacherViewCommand =>
        _openTeacherViewCommand ??= new RelayCommand(o => Navigator.NavigateTo<TeacherViewModel>(), o => true);

    public SectionBarViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        
    }
}
