using System;
using System.Collections.ObjectModel;
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
    private RelayCommand _addStudentCommand;
    public RelayCommand AddStudentCommand
    {
        get
        {
            return _addStudentCommand ??
                (_addStudentCommand = new RelayCommand(obj =>
                {
                    Student student = new Student();
                    Students.Insert(0, student);
                    SelectedStudent = student;
                }, o => true));
        }
    }
    private RelayCommand _editStudentCommand;
    public RelayCommand EditStudentCommand
    {
        get
        {
            return _editStudentCommand ??
                (_editStudentCommand = new RelayCommand(obj =>
                {

                }, o => true));
        }
    }
    private RelayCommand _deleteStudentCommand;
    public RelayCommand DeleteStudentCommand
    {
        get
        {
            return _deleteStudentCommand ??
                (_deleteStudentCommand = new RelayCommand(obj =>
                {
                    Student selectedStudent = obj as Student ?? throw new ArgumentNullException(nameof(obj));
                    Students.Remove(selectedStudent);
                },
                obj =>  Students.Count > 0));
        }
    }

    public ObservableCollection<Student> Students { get; private set; }

    public StudentViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        LoadData();
    }

    private void LoadData()
    {
        Students = new ObservableCollection<Student>(UnitOfWork.GetRepository<Student>().GetAll());
        foreach (var student in Students)
        {
            student.Group = UnitOfWork.GetRepository<Group>().GetByID(student.GroupId);
            student.Group.Course = UnitOfWork.GetRepository<Course>().GetByID(student.Group.CourseId);
        }
    }
}
