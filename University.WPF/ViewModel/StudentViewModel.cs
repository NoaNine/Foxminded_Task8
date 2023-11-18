using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class StudentViewModel : BaseViewModel
{
    private Student _selectedStudent;
    public Student SelectedStudent 
    { 
        get => _selectedStudent;
        set
        {
            _selectedStudent = value;
            OnPropertyChanged("SelectedStudent");
        }
    }
    public ObservableCollection<Student> Students { get; set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);
    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Students = new ObservableCollection<Student>(UnitOfWork.GetRepository<Student>().GetAll());
        foreach (var student in Students)
        {
            student.Group = UnitOfWork.GetRepository<Group>().GetByID(student.GroupId);
            student.Group.Course = UnitOfWork.GetRepository<Course>().GetByID(student.Group.CourseId);
        }
        OnPropertyChanged("Students");
    }

    #endregion

    #region Command OpenAddStudentViewCommand

    private ICommand _openAddStudentViewCommand;
    public ICommand OpenAddStudentViewCommand => 
        _openAddStudentViewCommand ??= new RelayCommand(OnOpenAddStudentViewCommandExecuted, CanOpenAddStudentViewCommandExecute);

    private bool CanOpenAddStudentViewCommandExecute(object o) => true;

    private void OnOpenAddStudentViewCommandExecuted(object o) => Navigator.NavigateTo<AddStudentViewModel>();

    #endregion

    #region Command OpenEditStudentViewCommand

    private ICommand _openEditStudentViewCommand;
    public ICommand OpenEditStudentViewCommand =>
        _openEditStudentViewCommand ??= new RelayCommand(OnOpenEditStudentViewCommandExecuted, CanOpenEditStudentViewCommandExecute);

    private bool CanOpenEditStudentViewCommandExecute(object o) => true;

    private void OnOpenEditStudentViewCommandExecuted(object o) => Navigator.NavigateTo<EditStudentViewModel>();

    #endregion

    #region Command DeleteStudentCommand

    private ICommand _deleteStudentCommand;
    public ICommand DeleteStudentCommand =>
        _deleteStudentCommand ??= new RelayCommand(OnDeleteStudentCommandExecuted, CanDeleteStudentCommandExecute);

    private bool CanDeleteStudentCommandExecute(object o) => 
        o is Student student 
        && Students.Count > 0 
        && Students.Contains(student);

    private void OnDeleteStudentCommandExecuted(object o)
    {
        Students.Remove((Student)o);
    }

    #endregion

    public StudentViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        
    }
}
