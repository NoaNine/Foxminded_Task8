using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.Command;
using University.WPF.ViewModel.Base;
using AutoMapper;
using University.WPF.Models;

namespace University.WPF.ViewModel;

class TeacherViewModel : BaseViewModel
{
    private TeacherModel _teacher;
    public TeacherModel SelectedTeacher
    {
        get => _teacher;
        set
        {
            _teacher = value;
            OnPropertyChanged("SelectedTeacher");
        }
    }
    public ObservableCollection<TeacherModel> Teachers { get; private set; }

    #region Command LoadDataCommand

    private ICommand _loadDataCommand;
    public ICommand LoadDataCommand =>
        _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

    private bool CanLoadDataCommandExecute(object o) => true;

    private void OnLoadDataCommandExecuted(object o)
    {
        Teachers = Mapper.Map<ObservableCollection<TeacherModel>>(UnitOfWork.GetRepository<Teacher>().GetAll());
        foreach (var teacher in Teachers)
        {
            teacher.Group = Mapper.Map<GroupModel>(UnitOfWork.GetRepository<Group>().GetByID(teacher.GroupId));
        }
        OnPropertyChanged("Teachers");
    }

    #endregion

    #region Command AddTeacherCommand

    private ICommand _addTeacherCommand;
    public ICommand AddTeacherCommand =>
        _addTeacherCommand ??= new RelayCommand(OnAddTeacherCommandExecuted, CanAddTeacherCommandExecute);

    private bool CanAddTeacherCommandExecute(object o) => true;

    private void OnAddTeacherCommandExecuted(object o)
    {

    }

    #endregion

    #region Command EditTeacherCommand

    private ICommand _editTeacherCommand;
    public ICommand EditStudentCommand =>
        _editTeacherCommand ??= new RelayCommand(OnEditTeacherCommandExecuted, CanEditTeacherCommandExecute);

    private bool CanEditTeacherCommandExecute(object o) => true;

    private void OnEditTeacherCommandExecuted(object o)
    {

    }

    #endregion

    #region Command DeleteTeacherCommand

    private ICommand _deleteTeacherCommand;
    public ICommand DeleteTeacherCommand =>
        _deleteTeacherCommand ??= new RelayCommand(OnDeleteTeacherCommandExecuted, CanDeleteTeacherCommandExecute);

    private bool CanDeleteTeacherCommandExecute(object o) =>
        o is TeacherModel teacher
        && Teachers.Count > 0
        && Teachers.Contains(teacher);

    private void OnDeleteTeacherCommandExecuted(object o)
    {
        Teachers.Remove((TeacherModel)o);
    }

    #endregion

    public TeacherViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
    {

    }
}
