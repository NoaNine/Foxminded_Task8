using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class SectionBarViewModel : BaseViewModel
{
    public RelayCommand OpenGroupView { get; private set; }
    public RelayCommand OpenHomeView { get; private set; }
    public RelayCommand OpenCourseView { get; private set; }
    public RelayCommand OpenStudentView { get; private set; }
    public RelayCommand OpenTeacherView { get; private set; }

    public SectionBarViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        InitialCreateCommand();
    }

    private void InitialCreateCommand()
    {
        OpenGroupView = new RelayCommand(o => { Navigator.NavigateTo<GroupViewModel>(); }, o => true);
        OpenHomeView = new RelayCommand(o => { Navigator.NavigateTo<HomeViewModel>(); }, o => true);
        OpenCourseView = new RelayCommand(o => { Navigator.NavigateTo<CourseViewModel>(); }, o => true);
        OpenStudentView = new RelayCommand(o => { Navigator.NavigateTo<StudentViewModel>(); }, o => true);
        OpenTeacherView = new RelayCommand(o => { Navigator.NavigateTo<TeacherViewModel>(); }, o => true);
    }
}
