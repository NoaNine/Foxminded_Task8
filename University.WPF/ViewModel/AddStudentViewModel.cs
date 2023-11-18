using University.DAL.UnitOfWork;
using University.WPF.Infrastructure.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel
{
    internal class AddStudentViewModel : BaseViewModel
    {
        public AddStudentViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
        {
        }
    }
}
