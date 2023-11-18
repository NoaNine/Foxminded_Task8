using University.DAL.UnitOfWork;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel.Base;

namespace University.WPF.ViewModel
{
    internal class EditStudentViewModel : BaseViewModel
    {
        public EditStudentViewModel(INavigator navigator, IUnitOfWork unitOfWork) : base(navigator, unitOfWork)
        {

        }
    }
}
