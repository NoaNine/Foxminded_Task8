using System.Collections.ObjectModel;
using University.DAL.Models;
using University.WPF.Services.Command;
using University.WPF.Core;
using University.WPF.Services.Navigator;
using University.DAL.UnitOfWork;
using University.WPF.ViewModel;

namespace DesktopApp.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<Course> _courses;
    private ObservableCollection<Group> _groups;
    private ObservableCollection<Student> _students;
    private ObservableCollection<Teacher> _teachers;
    public ObservableCollection<Course> Courses
    {
        get { return _courses; }
        private set
        {
            _courses = value;
            OnPropertyChanged("Courses");
        }
    }
    public ObservableCollection<Group> Groups
    {
        get { return _groups; }
        private set
        {
            _groups = value;
            OnPropertyChanged("Groups");
        }
    }
    public ObservableCollection<Student> Students
    {
        get { return _students; }
        private set
        {
            _students = value;
            OnPropertyChanged("Students");
        }
    }
    public ObservableCollection<Teacher> Teachers
    { 
        get { return _teachers; } 
        private set
        {
            _teachers = value;
            OnPropertyChanged("Teachers");
        }
    }

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

    #region Command to open page
    public RelayCommand OpenGroupPage { get; private set; }
    #endregion

    public MainWindowViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
        OpenGroupPage = new RelayCommand(o => { Navigator.NavigateTo<GroupViewModel>(); }, o => true);
    }
}
