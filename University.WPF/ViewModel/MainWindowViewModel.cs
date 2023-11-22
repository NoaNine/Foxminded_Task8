using AutoMapper;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

public class MainWindowViewModel : BaseViewModel
{
    public MainWindowViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) : base(navigator, unitOfWork, mapper)
    {

    }
}
