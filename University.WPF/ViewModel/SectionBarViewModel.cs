using University.WPF.Services;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class SectionBarViewModel : BaseViewModel
{
    private INavigator _navigator;
    public INavigator Navigator
    {
        get => _navigator;
        set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand OpenGroupView { get; private set; }

    public SectionBarViewModel(INavigator navigator)
    {
        _navigator = navigator;
        OpenGroupView = new RelayCommand(o => { Navigator.NavigateTo<GroupViewModel>(); }, o => true);
    }
}
