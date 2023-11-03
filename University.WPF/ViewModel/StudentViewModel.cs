using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class StudentViewModel : BaseViewModel
{
    private Student _student;
    public Student SelectedStudent 
    { 
        get => _student;
        set
        {
            _student = value;
            OnPropertyChanged("SelectedStudent");
        }
    }
    private RelayCommand addCommand;
    public RelayCommand AddCommand
    {
        get
        {
            return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    Student student = new Student();
                    Students.Insert(0, student);
                    SelectedStudent = student;
                }, o => true));
        }
    }
    public RelayCommand OpenAddStudentView { get; private set; }
    public RelayCommand OpenEditStudentView { get; private set; }
    public RelayCommand DeleteStudent { get; private set; }
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
