using University.DAL.UnitOfWork;
using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class GroupViewModel : BaseViewModel
{
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

    public GroupViewModel(IUnitOfWork unitOfWork, INavigator navigator)
    {
        Navigator = navigator;
    }
}
