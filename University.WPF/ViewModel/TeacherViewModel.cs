using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class TeacherViewModel : BaseViewModel
{
    private Teacher _teacher;
    public Teacher SelectedTeacher
    {
        get => _teacher;
        set
        {
            _teacher = value;
            OnPropertyChanged("SelectedTeacher");
        }
    }
    public RelayCommand OpenAddTeacherView { get; private set; }
    public RelayCommand OpenEditTeacherView { get; private set; }
    public RelayCommand DeleteTeacher { get; private set; }
    public ObservableCollection<Teacher> Teachers { get; private set; }

    public TeacherViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        LoadData();
    }

    private void LoadData()
    {
        Teachers = new ObservableCollection<Teacher>(UnitOfWork.GetRepository<Teacher>().GetAll());
        foreach (var teacher in Teachers)
        {
            teacher.Group = UnitOfWork.GetRepository<Group>().GetByID(teacher.GroupId);
        }    
    }
}
