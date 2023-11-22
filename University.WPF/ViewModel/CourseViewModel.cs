using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;
using AutoMapper;

namespace University.WPF.ViewModel;

class CourseViewModel : BaseViewModel
{
    private Course _course;
    public Course SelectedCourse
    {
        get => _course;
        set
        {
            _course = value;
            OnPropertyChanged("SelectedCourse");
        }
    }
    public ObservableCollection<Course> Courses { get; private set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Courses = new ObservableCollection<Course>(UnitOfWork.GetRepository<Course>().GetAll());
        foreach (var course in Courses)
        {
            course.Groups = (ICollection<Group>)UnitOfWork.GetRepository<Group>().GetAll(g => g.CourseId == course.Id);
            foreach (var group in course.Groups)
            {
                group.Students = (ICollection<Student>)UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
            }
        }
        OnPropertyChanged("Courses");
    }

    #endregion

    #region Command AddCourseCommand

    private ICommand _addCourseCommand;
    public ICommand AddCourseCommand =>
        _addCourseCommand ??= new RelayCommand(OnAddCourseCommandExecuted, CanAddCourseCommandExecute);

    private bool CanAddCourseCommandExecute(object o) => true;

    private void OnAddCourseCommandExecuted(object o)
    {

    }

    #endregion

    #region Command EditCourseCommand

    private ICommand _editCourseCommand;
    public ICommand EditCourseCommand =>
        _editCourseCommand ??= new RelayCommand(OnEditCourseCommandExecuted, CanEditCourseCommandExecute);

    private bool CanEditCourseCommandExecute(object o) => true;

    private void OnEditCourseCommandExecuted(object o)
    {

    }

    #endregion

    #region Command DeleteCourseCommand

    private ICommand _deleteCourseCommand;
    public ICommand DeleteCourseCommand =>
        _deleteCourseCommand ??= new RelayCommand(OnDeleteCourseCommandExecuted, CanDeleteCourseCommandExecute);

    private bool CanDeleteCourseCommandExecute(object o) =>
        o is Course course
        && Courses.Count > 0
        && Courses.Contains(course)
        && course.Groups.Count == 0;

    private void OnDeleteCourseCommandExecuted(object o)
    {
        Courses.Remove((Course)o);
    }

    #endregion

    public CourseViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
    {

    }
}
