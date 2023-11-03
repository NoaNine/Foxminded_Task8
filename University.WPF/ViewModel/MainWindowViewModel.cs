using University.DAL.UnitOfWork;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    public MainWindowViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {

    }
}
