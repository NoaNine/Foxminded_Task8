using AutoMapper;
using System.Collections.ObjectModel;
using System.Windows.Input;
using University.DAL.Models;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Command;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Models;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel
{
    internal class AddStudentViewModel : BaseViewModel
    {
        private ICommand _openStudentViewCommand;
        private GroupModel _selectedGroup;
        private StudentModel _inputStudent = new();
        private ObservableCollection<StudentModel> _students;
        public StudentModel InputStudent
        {
            get => _inputStudent;
            private set
            {
                _inputStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        public GroupModel SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged("SelectedGroup");
            }
        }
        public ObservableCollection<GroupModel> Groups { get; set; }
        public ICommand OpenStudentViewCommand =>
            _openStudentViewCommand ??= new RelayCommand(o => Navigator.NavigateTo<StudentViewModel>(), o => true);

        #region Command LoadDataCommand

        private ICommand _loadDataCommand;
        public ICommand LoadDataCommand =>
            _loadDataCommand ??= new RelayCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);
        private bool CanLoadDataCommandExecute(object o) => true;

        private void OnLoadDataCommandExecuted(object o)
        {
            Groups = Mapper.Map<ObservableCollection<GroupModel>>(UnitOfWork.GetRepository<Group>().GetAll());
            OnPropertyChanged("Groups");
            _students = (ObservableCollection<StudentModel>)o;
        }

        #endregion

        #region Command AddStudentCommand

        private ICommand _addStudentCommand;
        public ICommand AddStudentCommand =>
            _addStudentCommand ??= new RelayCommand(OnAddStudentCommandExecuted, CanAddStudentCommandExecute);

        private bool CanAddStudentCommandExecute(object o) => true;

        private void OnAddStudentCommandExecuted(object o)
        {
            InputStudent.GroupId = SelectedGroup.Id;
            InputStudent.Group = SelectedGroup;
            _students.Insert(0, InputStudent);
            InputStudent = new();
            OpenStudentViewCommand.Execute(this);
        }

        #endregion

        public AddStudentViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
        {

        }
    }
}
