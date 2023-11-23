using AutoMapper;
using System;
using University.DAL.UnitOfWork;
using University.WPF.Infrastructure;
using University.WPF.Infrastructure.Navigator;

namespace University.WPF.ViewModel.Base;

public abstract class BaseViewModel : ObservableObject
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
    public IUnitOfWork UnitOfWork { get; private set; }
    public IMapper Mapper { get; private set; }

    public BaseViewModel(INavigator navigator, IUnitOfWork unitOfWork, IMapper mapper) 
    {
        Navigator = navigator ?? throw new ArgumentNullException("navigator");
        UnitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
        Mapper = mapper ?? throw new ArgumentNullException("unitOfWork");
    }
}
