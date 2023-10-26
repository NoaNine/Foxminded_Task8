using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class StudentViewModel : BaseViewModel
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
    public RelayCommand OpenAddStudentView { get; private set; }
    public RelayCommand OpenEditStudentView { get; private set; }
    public RelayCommand DeleteStudent { get; private set; }

    public StudentViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
    }
}
