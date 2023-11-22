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

class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Course> Courses {  get; private set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Courses = new ObservableCollection<Course>(UnitOfWork.GetRepository<Course>().GetAll());
        LoadDataCourse();
        OnPropertyChanged("Courses");
    }

    private void LoadDataCourse()
    {
        foreach (var course in Courses)
        {
            course.Groups = (ICollection<Group>)UnitOfWork.GetRepository<Group>().GetAll(g => g.CourseId == course.Id);
            LoadDataGroup(course);
        }
    }

    private void LoadDataGroup(Course course)
    {
        foreach (var group in course.Groups)
        {
            group.Students = (ICollection<Student>)UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
            group.Course = UnitOfWork.GetRepository<Course>().GetByID(group.CourseId);
            group.Tutor = UnitOfWork.GetRepository<Teacher>().GetByID(group.Id);
        }
    }

    #endregion

    public HomeViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper) //TODO set a default page
    {

    }
}
