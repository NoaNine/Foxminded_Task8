using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;
using AutoMapper;
using University.WPF.Models;
using System.Linq;

namespace University.WPF.ViewModel;

class GroupViewModel : BaseViewModel
{
    private GroupModel _group;
    public GroupModel SelectedGroup
    {
        get => _group;
        set
        {
            _group = value;
            OnPropertyChanged("SelectedGroup");
        }
    }
    public ObservableCollection<GroupModel> Groups { get; private set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Groups = Mapper.Map<ObservableCollection<GroupModel>>(UnitOfWork.GetRepository<Group>().GetAll());
        foreach (var group in Groups)
        {
            group.Students = Mapper.Map<ObservableCollection<StudentModel>>(UnitOfWork.GetRepository<Student>().GetAll(s => s.GroupId == group.Id));
            group.Course = Mapper.Map<CourseModel>(UnitOfWork.GetRepository<Course>().GetById(group.CourseId));
            group.Tutor = Mapper.Map<TeacherModel>(UnitOfWork.GetRepository<Teacher>().GetAll(t => t.GroupId == group.Id).FirstOrDefault());
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
        o is GroupModel group
        && Groups.Count > 0
        && Groups.Contains(group)
        && group.Students.Count == 0; 

    private void OnDeleteGroupCommandExecuted(object o)
    {
        Groups.Remove((GroupModel)o);
    }

    #endregion

    public GroupViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
    {

    }
}
