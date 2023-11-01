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
    private Student _student;
    private IUnitOfWork _unitOfWork;
    private INavigator _navigator;

    public INavigator Navigator
    {
        get => _navigator;
        private set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }
    public Student SelectedStudent 
    { 
        get => _student;
        set
        {
            _student = value;
            OnPropertyChanged("SelectedStudent");
        }
    }
    public RelayCommand OpenAddStudentView { get; private set; }
    public RelayCommand OpenEditStudentView { get; private set; }
    public RelayCommand DeleteStudent { get; private set; }
    public ObservableCollection<Student> Students { get; private set; }

    public StudentViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
        LoadData();
    }

    private void LoadData()
    {
        Students = new ObservableCollection<Student>(_unitOfWork.GetRepository<Student>().GetAll());
        foreach (var student in Students)
        {
            student.Group = _unitOfWork.GetRepository<Group>().GetByID(student.GroupId);
            student.Group.Course = _unitOfWork.GetRepository<Course>().GetByID(student.Group.CourseId);
        }
    }
}
