using System;
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
    public RelayCommand OpenCreateCourseView { get; private set; }
    public RelayCommand OpenEditCourseView { get; private set; }
    public RelayCommand DeleteCourse { get; private set; }
    public ObservableCollection<Course> Courses { get; private set; }

    public CourseViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
        LoadData();
    }

    private void LoadData()
    {
        Courses = new ObservableCollection<Course>(_unitOfWork.GetRepository<Course>().GetAll());
        foreach (var course in Courses)
        {
            course.Groups = (ICollection<Group>)_unitOfWork.GetRepository<Group>().GetAll(g => g.CourseId == course.Id);
            foreach (var group in course.Groups)
            {
                group.Students = (ICollection<Student>)_unitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
            }
        }
    }
}
