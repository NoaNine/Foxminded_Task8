using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class GroupViewModel : BaseViewModel
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
    public RelayCommand OpenCreateGroupView { get; private set; }
    public RelayCommand OpenEditGroupView { get; private set; }
    public RelayCommand DeleteGroup { get; private set; }
    public ObservableCollection<Group> Groups { get; private set; }

    public GroupViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
        LoadData();
    }

    private void LoadData()
    {
        Groups = new ObservableCollection<Group>(_unitOfWork.GetRepository<Group>().GetAll());
        foreach (var group in Groups)
        {
            group.Students = (ICollection<Student>)_unitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
            group.Course = _unitOfWork.GetRepository<Course>().GetByID(group.CourseId);
            group.Tutor = _unitOfWork.GetRepository<Teacher>().GetByID(group.Id);
        }
    }
}
