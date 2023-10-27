using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class TeacherViewModel : BaseViewModel
{
    private INavigator _navigator;
    private ObservableCollection<Teacher> _teachers;
    public INavigator Navigator
    {
        get => _navigator;
        private set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Teacher> Teachers
    {
        get => _teachers;
        private set
        {
            _teachers = value;
            OnPropertyChanged("Teachers");
        }
    }
    public RelayCommand OpenAddTeacherView { get; private set; }
    public RelayCommand OpenEditTeacherView { get; private set; }
    public RelayCommand DeleteTeacher { get; private set; }

    public TeacherViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
        Teachers = new ObservableCollection<Teacher>(unitOfWork.GetRepository<Teacher>().GetAll());
    }
}
