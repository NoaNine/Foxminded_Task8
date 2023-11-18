using Microsoft.Extensions.DependencyInjection;

namespace University.WPF.ViewModel.Registrator
{
    internal static class Registrator
    {
        public static IServiceCollection AddAllViewModels(this IServiceCollection services)
        {
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<GroupViewModel>();
            services.AddScoped<SectionBarViewModel>();
            services.AddScoped<CourseViewModel>();
            services.AddScoped<HomeViewModel>();
            services.AddScoped<StudentViewModel>();
            services.AddScoped<TeacherViewModel>();
            services.AddScoped<EditStudentViewModel>();
            return services;
        }
    }
}
