using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class TeacherViewModel : BaseViewModel
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
    public RelayCommand OpenAddTeacherView { get; private set; }
    public RelayCommand OpenEditTeacherView { get; private set; }
    public RelayCommand DeleteTeacher { get; private set; }

    public TeacherViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
    }
}
