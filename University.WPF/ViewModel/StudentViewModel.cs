using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class StudentViewModel : BaseViewModel
{
    private INavigator _navigator;
    private ObservableCollection<Student> _students;

    public INavigator Navigator
    {
        get => _navigator;
        private set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Student> Students
    {
        get => _students;
        private set
        {
            _students = value;
            OnPropertyChanged("Students");
        }
    }
    public RelayCommand OpenAddStudentView { get; private set; }
    public RelayCommand OpenEditStudentView { get; private set; }
    public RelayCommand DeleteStudent { get; private set; }

    public StudentViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
        Students = new ObservableCollection<Student>(unitOfWork.GetRepository<Student>().GetAll());
    }
}
