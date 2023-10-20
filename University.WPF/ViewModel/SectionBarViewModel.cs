using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class SectionBarViewModel : BaseViewModel
{
    private INavigator _navigator;
    public INavigator Navigator
    {
        get => _navigator;
        set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand OpenGroupView { get; private set; }
    public RelayCommand OpenHomeView { get; private set; }
    public RelayCommand OpenCourseView { get; private set; }
    public RelayCommand OpenStudentView { get; private set; }
    public RelayCommand OpenTeacherView { get; private set; }

    public SectionBarViewModel(INavigator navigator)
    {
        _navigator = navigator;
        OpenGroupView = new RelayCommand(o => { Navigator.NavigateTo<GroupViewModel>(); }, o => true);
        OpenHomeView = new RelayCommand(o => { Navigator.NavigateTo<HomeViewModel>(); }, o => true);
        OpenHomeView = new RelayCommand(o => { Navigator.NavigateTo<CourseViewModel>(); }, o => true);
        OpenHomeView = new RelayCommand(o => { Navigator.NavigateTo<StudentViewModel>(); }, o => true);
        OpenHomeView = new RelayCommand(o => { Navigator.NavigateTo<TeacherViewModel>(); }, o => true);
    }
}
