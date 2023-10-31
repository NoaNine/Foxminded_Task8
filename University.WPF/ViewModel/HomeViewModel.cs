using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class HomeViewModel : BaseViewModel
{
    private readonly IUnitOfWork _unitOfWork;
    public ObservableCollection<Course> Courses {  get; private set; }

    public HomeViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
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
                group.Course = _unitOfWork.GetRepository<Course>().GetByID(group.CourseId);
                group.Tutor = _unitOfWork.GetRepository<Teacher>().GetByID(group.Id);
            }
        }
    }
}
