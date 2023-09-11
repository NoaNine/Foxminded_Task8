using Microsoft.Extensions.DependencyInjection;
using University.DAL.Models;
using University.DAL.Repositories;

namespace University.DAL.Extensions
{
    public static class DataDependenciesExtensions
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<Group>, Repository<Group>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<IRepository<Teacher>, Repository<Teacher>>();
            return services;
        }
    }
}
