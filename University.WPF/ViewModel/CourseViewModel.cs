using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;
using AutoMapper;
using University.WPF.Models;

namespace University.WPF.ViewModel;

class CourseViewModel : BaseViewModel
{
    private CourseModel _course;
    public CourseModel SelectedCourse
    {
        get => _course;
        set
        {
            _course = value;
            OnPropertyChanged("SelectedCourse");
        }
    }
    public ObservableCollection<CourseModel> Courses { get; private set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Courses = Mapper.Map<ObservableCollection<CourseModel>>(UnitOfWork.GetRepository<Course>().GetAll());
        LoadDataCourse();
        OnPropertyChanged("Courses");
    }

    private void LoadDataCourse()
    {
        foreach (var course in Courses)
        {
            course.Groups = Mapper.Map<ObservableCollection<GroupModel>>(UnitOfWork.GetRepository<Group>().GetAll(g => g.CourseId == course.Id));
            LoadDataGroup(course);
        }
    }

    private void LoadDataGroup(CourseModel course)
    {
        foreach (var group in course.Groups)
        {
            group.Students = Mapper.Map<ObservableCollection<StudentModel>>(UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id));
        }
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
        o is CourseModel course
        && Courses.Count > 0
        && Courses.Contains(course)
        && course.Groups.Count == 0;

    private void OnDeleteCourseCommandExecuted(object o)
    {
        Courses.Remove((CourseModel)o);
    }

    #endregion

    public CourseViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
    {

    }
}
