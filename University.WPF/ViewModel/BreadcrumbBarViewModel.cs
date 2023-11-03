using University.DAL.UnitOfWork;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel;

class BreadcrumbBarViewModel : BaseViewModel
{
    public BreadcrumbBarViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
    {
        
    }
}
