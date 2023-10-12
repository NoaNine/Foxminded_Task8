using System.Collections.ObjectModel;
using University.DAL.Models;
using DesktopApp.View;
using System.Windows;
using University.Dal.UnitOfWork;
using University.WPF.Services.Command;
using University.WPF.Core;

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

    #region Command to open window
    private RelayCommand _openAddStudentWindow;
    public RelayCommand OpenAddStudentWindow
    {
        get 
        {
            return _openAddStudentWindow ?? new RelayCommand( obj =>
            {
                OpenAddStudentWindowMethod();
            }
            ); 
        }
    }
    #endregion

    public MainWindowViewModel(IUnitOfWork unitOfWork)
    {
        
    }

    #region Method to open window
    private void OpenAddStudentWindowMethod()
    {
        AddStudentWindow addStudentWindow = new AddStudentWindow();
        SetCenterPositionAndOpen(addStudentWindow);
    }

    private void SetCenterPositionAndOpen(Window window)
    {
        window.Owner = Application.Current.MainWindow;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        window.ShowDialog();
    }
    #endregion
}
