using System;
using System.Collections.ObjectModel;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class TeacherViewModel : BaseViewModel
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
    public RelayCommand OpenAddTeacherView { get; private set; }
    public RelayCommand OpenEditTeacherView { get; private set; }
    public RelayCommand DeleteTeacher { get; private set; }
    public ObservableCollection<Teacher> Teachers { get; private set; }

    public TeacherViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        _unitOfWork = unitOfWork;
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
        LoadData();
    }

    private void LoadData()
    {
        Teachers = new ObservableCollection<Teacher>(_unitOfWork.GetRepository<Teacher>().GetAll());
        foreach (var teacher in Teachers)
        {
            teacher.Group = _unitOfWork.GetRepository<Group>().GetByID(teacher.GroupId);
        }    
    }
}
