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

class HomeViewModel : BaseViewModel
{
    public ObservableCollection<CourseModel> Courses {  get; private set; }

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
            group.Course = Mapper.Map<CourseModel>(UnitOfWork.GetRepository<Course>().GetByID(group.CourseId));
        }
    }

    #endregion

    public HomeViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper) //TODO set a default page
    {

    }
}
