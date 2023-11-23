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

            var courses = new List<Course>
            {
                new Course { Name = "Прикладна математика", Description = "" },
                new Course { Name = "Комп`ютерна інженерія", Description = "" },
                new Course { Name = "Електроніка та електромеханіка", Description = "" },
                new Course { Name = "Юридичне право", Description = "" }
            };

            var groups = new List<Group>
            {
                new Group { Name = "SR-11" },
                new Group { Name = "SR-12" },
                new Group { Name = "SR-13" },
                new Group { Name = "PI-21" },
                new Group { Name = "EE-31" },
                new Group { Name = "YP-41" }
            };

            var students = new List<Student>
            {
                new Student { FirstName = "Ія", LastName = "Атрощенко" },
                new Student { FirstName = "Гаїна", LastName = "Троцька" },
                new Student { FirstName = "Устина", LastName = "Глущак" },
                new Student { FirstName = "Шанетта", LastName = "Морачевська" },
                new Student { FirstName = "Уляна", LastName = "Савула" },
                new Student { FirstName = "Глафира", LastName = "Шамрай" },
                new Student { FirstName = "Корнелія", LastName = "Магура" },
                new Student { FirstName = "Фелікса", LastName = "Коник" },
                new Student { FirstName = "Улита", LastName = "Фартушняк" },
                new Student { FirstName = "Ада", LastName = "Варивода" },
                new Student { FirstName = "Есфіра", LastName = "Мороз" },
                new Student { FirstName = "Йоган", LastName = "Рижук" },
                new Student { FirstName = "Вітан", LastName = "Боровий" },
                new Student { FirstName = "Яртур", LastName = "Жук" },
                new Student { FirstName = "Славобор", LastName = "Сливенко" },
                new Student { FirstName = "Кий", LastName = "Бузинний" },
                new Student { FirstName = "Дантур", LastName = "Горовенко" },
                new Student { FirstName = "Ярчик", LastName = "Чічка" },
                new Student { FirstName = "Матвій", LastName = "Білявський" },
                new Student { FirstName = "Недан", LastName = "Баліцький" },
                new Student { FirstName = "Щек", LastName = "Удовенко" },
                new Student { FirstName = "Орест", LastName = "Колосовський" },
                new Student { FirstName = "Йонас", LastName = "Вихрущ" },
                new Student { FirstName = "Наслав", LastName = "Прокопчук" },
                new Student { FirstName = "Куйбіда", LastName = "Лемешко" },
                new Student { FirstName = "Ліпослав", LastName = "Мовчан" },
                new Student { FirstName = "Снозір", LastName = "Назарук" },
                new Student { FirstName = "Дорогосил", LastName = "Тарасович" },
                new Student { FirstName = "Юхим", LastName = "Забродський" },
                new Student { FirstName = "Яртур", LastName = "Цвєк" },
                new Student { FirstName = "Лук`ян", LastName = "Григоренко" },
                new Student { FirstName = "Хорив", LastName = "Горбачевський" },
                new Student { FirstName = "Царко", LastName = "Киричук" },
                new Student { FirstName = "Творимир", LastName = "Яхненко" },
                new Student { FirstName = "Яснолик", LastName = "Рошко" },
                new Student { FirstName = "Живорід", LastName = "Керножицький" },
                new Student { FirstName = "Нестор", LastName = "Засядько" },
                new Student { FirstName = "Йомер", LastName = "Павличенко" },
                new Student { FirstName = "Малик", LastName = "Білоскурський" },
                new Student { FirstName = "Осемрит", LastName = "Синиця" },
                new Student { FirstName = "Явір", LastName = "Сливенко" },
                new Student { FirstName = "Колодар", LastName = "Гайдабура" },
                new Student { FirstName = "Макар", LastName = "Гембицький" },
                new Student { FirstName = "Радогоста", LastName = "Гаркуша" },
                new Student { FirstName = "Юдихва", LastName = "Степура" },
                new Student { FirstName = "Млада", LastName = "Сенько" },
                new Student { FirstName = "Римма", LastName = "Пашко" },
                new Student { FirstName = "Цвітана", LastName = "Могиленко" },
                new Student { FirstName = "Марта", LastName = "Кирей" },
                new Student { FirstName = "Глафіра", LastName = "Любенецька" },
                new Student { FirstName = "Віра", LastName = "Тарасовна" },
                new Student { FirstName = "Жадана", LastName = "Заяць" },
                new Student { FirstName = "Тава", LastName = "Андрусенко" },
                new Student { FirstName = "Ядвіга", LastName = "Воронюк" },
                new Student { FirstName = "Стелла", LastName = "Рибенчук" },
                new Student { FirstName = "Мокрина", LastName = "Трегуб" }
            };

            var teachers = new List<Teacher>
            {
                new Teacher { FirstName = "Олександр", LastName = "Полухін" },
                new Teacher { FirstName = "Василій", LastName = "Моржов" },
                new Teacher { FirstName = "Іван", LastName = "Куклінський" },
                new Teacher { FirstName = "Світлана", LastName = "Савченко" },
                new Teacher { FirstName = "Раїса", LastName = "Халявкіна" },
                new Teacher { FirstName = "Генадій", LastName = "Василенко" },
                new Teacher { FirstName = "Петро", LastName = "Моденов" },
                new Teacher { FirstName = "Ірина", LastName = "Чуба" },
                new Teacher { FirstName = "Анна", LastName = "Колісник" }
            };

            context.AddRange(courses);
            context.AddRange(groups);
            context.AddRange(students);
            context.AddRange(teachers);
            context.SaveChanges();
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
