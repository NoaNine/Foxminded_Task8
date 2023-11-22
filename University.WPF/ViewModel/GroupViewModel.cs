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
    public ObservableCollection<Group> Groups { get; private set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Groups = new ObservableCollection<Group>(UnitOfWork.GetRepository<Group>().GetAll());
        foreach (var group in Groups)
        {
            group.Students = (ICollection<Student>)UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id);
            group.Course = UnitOfWork.GetRepository<Course>().GetByID(group.CourseId);
            group.Tutor = UnitOfWork.GetRepository<Teacher>().GetByID(group.Id); //TODO need fix. Not downloaded from BD
        }
        OnPropertyChanged("Groups");
    }

    #endregion

    #region Command AddGroupCommand

    private ICommand _addGroupCommand;
    public ICommand AddGroupCommand =>
        _addGroupCommand ??= new RelayCommand(OnAddGroupCommandExecuted, CanAddGroupCommandExecute);

    private bool CanAddGroupCommandExecute(object o) => true;

    private void OnAddGroupCommandExecuted(object o)
    {

    }

    #endregion

    #region Command EditGroupCommand

    private ICommand _editGroupCommand;
    public ICommand EditGroupCommand =>
        _editGroupCommand ??= new RelayCommand(OnEditGroupCommandExecuted, CanEditGroupCommandExecute);

    private bool CanEditGroupCommandExecute(object o) => true;

    private void OnEditGroupCommandExecuted(object o)
    {

    }

    #endregion

    #region Command DeleteGroupCommand

    private ICommand _deleteGroupCommand;
    public ICommand DeleteGroupCommand =>
        _deleteGroupCommand ??= new RelayCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);
    private bool CanDeleteGroupCommandExecute(object o) =>
        o is Group group
        && Groups.Count > 0
        && Groups.Contains(group)
        && group.Students.Count == 0; 

    private void OnDeleteGroupCommandExecuted(object o)
    {
        Groups.Remove((Group)o);
    }

    #endregion

    public GroupViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
    {

    }
}
