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
    private Group _group;
    public Group SelectedGroup
    {
        get => _group;
        set
        {
            _group = value;
            OnPropertyChanged("SelectedGroup");
        }
    }
    public RelayCommand OpenCreateGroupView { get; private set; }
    public RelayCommand OpenEditGroupView { get; private set; }
    public RelayCommand DeleteGroup { get; private set; }
    public ObservableCollection<Group> Groups { get; private set; }

    public GroupViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        LoadData();
    }

    private void LoadData()
    {
        Groups = new ObservableCollection<Group>(UnitOfWork.GetRepository<Group>().GetAll());
        foreach (var group in Groups)
        {
            group.Students = (ICollection<Student>)UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
            group.Course = UnitOfWork.GetRepository<Course>().GetByID(group.CourseId);
            group.Tutor = UnitOfWork.GetRepository<Teacher>().GetByID(group.Id); //TODO fix
        }
    }
}
