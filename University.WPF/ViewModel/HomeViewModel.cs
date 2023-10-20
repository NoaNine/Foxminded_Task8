using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class HomeViewModel : BaseViewModel
{
    private readonly IUnitOfWork _unitOfWork;
    private ObservableCollection<Course> _courses;
    private ObservableCollection<Group> _groups;
    private ObservableCollection<Student> _students;
    private ObservableCollection<Teacher> _teachers;
    public ObservableCollection<Course> Courses
    {
        get => _courses;
        private set
        {
            _courses = value;
            OnPropertyChanged("Courses");
        }
    }
    public ObservableCollection<Group> Groups
    {
        get => _groups;
        private set
        {
            _groups = value;
            OnPropertyChanged("Groups");
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
    public ObservableCollection<Teacher> Teachers
    {
        get => _teachers;
        private set
        {
            _teachers = value;
            OnPropertyChanged("Teachers");
        }
    }
    public HomeViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _courses = new ObservableCollection<Course>(unitOfWork.GetRepository<Course>().GetAll());
    }
}
