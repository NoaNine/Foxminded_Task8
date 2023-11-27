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
    internal class EditStudentViewModel : BaseViewModel
    {
        private ICommand _openStudentViewCommand;
        private GroupModel _selectedGroup;
        private GroupModel _selectedValueDefault;
        private StudentModel _editedStudent = new();
        private StudentModel _selectedStudents;
        public StudentModel InputStudent
        {
            get => _editedStudent;
            private set
            {
                _editedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        public GroupModel SelectedValueDefault
        {
            get => _selectedValueDefault;
            set
            {
                _selectedValueDefault = _selectedStudents.Group;
                OnPropertyChanged("SelectedGroup");
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
        private bool CanLoadDataCommandExecute(object o) => o is StudentModel;

        private void OnLoadDataCommandExecuted(object o)
        {
            Groups = Mapper.Map<ObservableCollection<GroupModel>>(UnitOfWork.GetRepository<Group>().GetAll());
            OnPropertyChanged("Groups");
            _selectedStudents = (StudentModel)o;
        }

        #endregion

        #region Command EditStudentCommand

        private ICommand _EditStudentCommand;
        public ICommand EditStudentCommand =>
            _EditStudentCommand ??= new RelayCommand(OnEditStudentCommandExecuted, CanEditStudentCommandExecute);

        private bool CanEditStudentCommandExecute(object o) => true;

        private void OnEditStudentCommandExecuted(object o)
        {
            //InputStudent.GroupId = SelectedGroup.Id;
            //InputStudent.Group = SelectedGroup;
            //_students.Insert(0, InputStudent);
            //InputStudent = new();
            //OpenStudentViewCommand.Execute(this);
        }

        #endregion

        public EditStudentViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
        {

        }
    }
}
