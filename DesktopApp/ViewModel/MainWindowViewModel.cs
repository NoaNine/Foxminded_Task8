using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using University.DAL.Models;
using DesktopApp.View;
using System.Windows;
using DesktopApp.Command;
using University.Dal.UnitOfWork;

namespace DesktopApp.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Course> _courses;
    private ObservableCollection<Group> _groups;
    private ObservableCollection<Student> _students;
    private ObservableCollection<Teacher> _teachers;
    public ObservableCollection<Course> Courses
    {
        get { return _courses; }
        set
        {
            _courses = value;
            OnPropertyChanged("Courses");
        }
    }
    public ObservableCollection<Group> Groups
    {
        get { return _groups; }
        set
        {
            _groups = value;
            OnPropertyChanged("Groups");
        }
    }
    public ObservableCollection<Student> Students
    {
        get { return _students; }
        set
        {
            _students = value;
            OnPropertyChanged("Students");
        }
    }
    public ObservableCollection<Teacher> Teachers
    { 
        get { return _teachers; } 
        set
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

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string property = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(property));
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
