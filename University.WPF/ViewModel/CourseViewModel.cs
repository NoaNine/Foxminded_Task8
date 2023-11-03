using System.Collections.Generic;
using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

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
    public RelayCommand OpenCreateCourseView { get; private set; }
    public RelayCommand OpenEditCourseView { get; private set; }
    public RelayCommand DeleteCourse { get; private set; }
    public ObservableCollection<Course> Courses { get; private set; }

    public CourseViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
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
            }
        }
    }
}
