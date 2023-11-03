using System.Collections.Generic;
using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Course> Courses {  get; private set; }

    public HomeViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        LoadData();
    }

    private void LoadData() 
    {
        Courses = new ObservableCollection<Course>(UnitOfWork.GetRepository<Course>().GetAll());
        foreach (var course in Courses)
        {
            course.Groups = (ICollection<Group>)UnitOfWork.GetRepository<Group>().GetAll(g => g.CourseId == course.Id);
            foreach (var group in course.Groups)
            {
                group.Students = (ICollection<Student>)UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
                group.Course = UnitOfWork.GetRepository<Course>().GetByID(group.CourseId);
                group.Tutor = UnitOfWork.GetRepository<Teacher>().GetByID(group.Id);
            }
        }
    }
}
