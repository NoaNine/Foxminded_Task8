using Microsoft.Xaml.Behaviors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Course> Courses {  get; private set; }

    public HomeViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork) //TODO set a default page
    {
        LoadData();
    }

    private void LoadData() 
    {
        Courses = new ObservableCollection<Course>(UnitOfWork.GetRepository<Course>().GetAll());
        LoadDataCourse();
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
}
