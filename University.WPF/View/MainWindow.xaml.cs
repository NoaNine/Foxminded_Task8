using DesktopApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace DesktopApp.View;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        InitializeComponent();
    }
}
