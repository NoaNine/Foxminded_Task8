using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class CourseViewModel : BaseViewModel
{
    private INavigator _navigator;
    public INavigator Navigator
    {
        get => _navigator;
        private set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }
    public RelayCommand OpenCreateCourseView { get; private set; }
    public RelayCommand OpenEditCourseView { get; private set; }
    public RelayCommand DeleteCourse { get; private set; }

    public CourseViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
    }
}
