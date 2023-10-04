using DesktopApp.ViewModel;
using System.Windows;

namespace DesktopApp.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
