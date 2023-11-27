using System;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using University.DAL;
using University.DAL.UnitOfWork;
using University.WPF.ViewModel.Base;
using University.WPF.View;
using University.WPF.Infrastructure.Navigator;
using University.WPF.Infrastructure.MapperConfiguration;
using University.WPF.ViewModel;
using System.Collections.Generic;
using University.DAL.Models;
using System.Linq;

namespace University.WPF;

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

#if Development
        using (var scope = host.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<UniversityContext>();

            if (!context.Groups.Any() && !context.Teachers.Any() && !context.Students.Any() && !context.Courses.Any())
            {
                DataSeeder.SeedCourses(context);
                DataSeeder.SeedGroups(context);
                DataSeeder.SeedStudents(context);
                DataSeeder.SeedTeachers(context);
            }
        }
#endif
    }

    private static void ConfigureServices(IConfiguration configuration,
        IServiceCollection services)
    {
        services.AddDbContext<UniversityContext>(o => o.UseSqlServer(configuration.GetConnectionString("UniversityDatabase")));
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddScoped<INavigator, Navigator>();
        services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));

        services.AddAutoMapper(typeof(GenericMapperProfile));

        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<GroupViewModel>();
        services.AddScoped<SectionBarViewModel>();
        services.AddScoped<CourseViewModel>();
        services.AddScoped<HomeViewModel>();
        services.AddScoped<StudentViewModel>();
        services.AddScoped<TeacherViewModel>();
        services.AddScoped<AddStudentViewModel>();
        services.AddScoped<EditStudentViewModel>();

        services.AddScoped<MainWindow>();
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
