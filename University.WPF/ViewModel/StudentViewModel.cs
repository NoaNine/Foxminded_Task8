using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
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
    }

    #endregion

    #region Command AddStudentCommand

    private ICommand _addStudentCommand;
    public ICommand AddStudentCommand => 
        _addStudentCommand ??= new RelayCommand(OnAddStudentCommandExecuted, CanAddStudentCommandExecute);

    private bool CanAddStudentCommandExecute(object o) => true;

    private void OnAddStudentCommandExecuted(object o)
    {
        Student student = new Student();
        Students.Insert(0, student);
        SelectedStudent = student;
    }

    #endregion

    #region Command EditStudentCommand

    private ICommand _editStudentCommand;
    public ICommand EditStudentCommand =>
        _editStudentCommand ??= new RelayCommand(OnEditStudentCommandExecuted, CanEditStudentCommandExecute);

    private bool CanEditStudentCommandExecute(object o) => true;

    private void OnEditStudentCommandExecuted(object o)
    {

    }

    #endregion

    #region Command DeleteStudentCommand

    private ICommand _deleteStudentCommand;
    public ICommand DeleteStudentCommand =>
        _deleteStudentCommand ??= new RelayCommand(OnDeleteStudentCommandExecuted, CanDeleteStudentCommandExecute);
    private bool CanDeleteStudentCommandExecute(object o) => true;

    private void OnDeleteStudentCommandExecuted(object o)
    {
        
    }

    #endregion

    public ObservableCollection<Student> Students { get; set; }

    public StudentViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        //LoadData();
    }

    //private void LoadData()
    //{
    //    Students = new ObservableCollection<Student>(UnitOfWork.GetRepository<Student>().GetAll());
    //    foreach (var student in Students)
    //    {
    //        student.Group = UnitOfWork.GetRepository<Group>().GetByID(student.GroupId);
    //        student.Group.Course = UnitOfWork.GetRepository<Course>().GetByID(student.Group.CourseId);
    //    }
    //}
}
