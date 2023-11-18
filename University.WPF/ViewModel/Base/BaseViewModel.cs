using System;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure;
using University.WPF.Infrastructure.Navigator;

namespace University.WPF.ViewModel.Base;

public abstract class BaseViewModel : ObservableObject
{
    private INavigator _navigator;
    public IUnitOfWork UnitOfWork {  get; private set; }
    public INavigator Navigator
    {
        get => _navigator;
        private set
        {
            _navigator = value;
            OnPropertyChanged();
        }
    }

    public BaseViewModel(INavigator navigator, IUnitOfWork unitOfWork) 
    {
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
        UnitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
    }
}
