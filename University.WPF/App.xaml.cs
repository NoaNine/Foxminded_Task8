using System;
using System.IO;
using System.Windows;
using DesktopApp.View;
using DesktopApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using University.DAL;
using University.DAL.UnitOfWork;
using University.WPF.Core;
using University.WPF.Services.Navigator;
using University.WPF.View.Pages.Group;
using University.WPF.ViewModel;

namespace DesktopApp;

public partial class App : Application
{
    private readonly IHost host;
    public static IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.SetBasePath(Directory.GetCurrentDirectory());
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();

        ServiceProvider = host.Services;
    }

    private void ConfigureServices(IConfiguration configuration,
        IServiceCollection services)
    {
        services.AddDbContext<UniversityContext>(o => o.UseSqlServer(configuration.GetConnectionString("UniversityDatabase")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<INavigator, Navigator>();
        services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<GroupViewModel>();

        services.AddTransient<MainWindow>();
        services.AddTransient<GroupPage>();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        await host.StartAsync();
        var window = ServiceProvider.GetRequiredService<MainWindow>();
        window.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (host)
        {
            await host.StopAsync(TimeSpan.FromSeconds(5));
        }
        base.OnExit(e);
    }
}
