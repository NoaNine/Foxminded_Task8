using System.Windows;
using System.Windows.Controls;
using University.WPF.Services.Command;
using University.WPF.Services.Navigator;
using University.WPF.ViewModel;

namespace University.WPF.View.Controls;

public partial class SectionBar : UserControl
{
    private INavigator _navigator;
    public INavigator Navigator
    {
        get => _navigator;
        set
        {
            _navigator = value;
        }
    }
    public RelayCommand OpenGroupPage { get; private set; }

    public SectionBar(INavigator navigator)
    {
        Navigator = navigator;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _navigator.NavigateTo<GroupViewModel>();
    }
}
